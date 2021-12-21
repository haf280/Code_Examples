using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotLibrary
{
    [DataContract]
    public class DialogueCorpus
    {
        private List<DialogueCorpusItem> itemList;
        private DialogueCorpusVocabulary vocabulary;
        private List<Tuple<string, string, double>> matchScoreTupleList;

        private char[] interpunctionList = new char[] { ' ', ',', '.', '?', '!', ';'};
        private char[] endOfSentenceCharList = new char[] { '.', '!', '?' };
        private const char WILDCARD_LEFT = '<';
        private const char WILDCARD_RIGHT = '>';
        private const char MULTIPLE_WILDCARD_INDICATOR = '+';

        public DialogueCorpus()
        {
            itemList = new List<DialogueCorpusItem>();
        }

        public void GenerateVocabulary()
        {
            HashSet<string> corpusWordList = new HashSet<string>();
            foreach (DialogueCorpusItem item in itemList)
            {
                List<string> sentence = item.GetQueryAsSentence();
                foreach (string word in sentence)
                {
                    corpusWordList.Add(word.ToLower());
                }
            }
            vocabulary = new DialogueCorpusVocabulary();
            foreach (string word in corpusWordList)
            {
                WordData wordData = new WordData();
                wordData.Word = word;
                vocabulary.WordDataList.Add(wordData);
            }
            vocabulary.Initialize();
        }


        // Assumes that GenerateVocabulary() has been executed first.
        public void ComputeIDFs()
        {
            foreach (DialogueCorpusItem item in itemList)
            {
                List<string> sentence = item.GetQueryAsSentence();
                foreach (string word in sentence)
                {
                    int index = vocabulary.GetWordIndex(word.ToLower());
                    if (index >= 0)
                    {
                        vocabulary.WordDataList[index].IDF += 1;
                    }
                }
            }

            foreach (WordData wordData in vocabulary.WordDataList)
            {
                wordData.IDF = Math.Log10((double)itemList.Count / wordData.IDF);
            }
        }

        public void ComputeVectorRepresentations()
        {
            foreach (DialogueCorpusItem item in itemList)
            {
                item.ComputeVectorRepresentation(vocabulary);
            }
        }

        // Used when running the chatbot. 
        //
        // query = the input sentence, 
        // numberOfMatches = the number of matching sentences returned, sorted in descending score order.
        public RetrievalResult Match(string query, int numberOfMatches)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            RetrievalResult result = new RetrievalResult();
            matchScoreTupleList = new List<Tuple<string, string, double>>(); // query, response, score
            List<string> queryAsSentence = query.ToLower().Split(new char[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            
            // Each word should just be considered once here.
            // (The TFs will be considered when forming the vector representation).
            queryAsSentence = queryAsSentence.Distinct().ToList(); 
            // Generate TF-IDF for the query (using the IDFs defined in the corpus)
            DialogueCorpusItem queryItem = new DialogueCorpusItem(query, ""); // Ignore the second input here ...
            queryItem.ComputeVectorRepresentation(vocabulary);
            
            double maxScore = 0;
            int indexOfMaxScore = -1;
            for (int ii = 0; ii < itemList.Count; ii++)
            {
                DialogueCorpusItem item = itemList[ii];
                double score = 0;
                foreach (string queryWord in queryAsSentence)
                {
                    int index = vocabulary.GetWordIndex(queryWord);
                    if (index >= 0)
                    {
                        score += queryItem.VectorRepresentation[index]*item.VectorRepresentation[index];
                    }
                }
                matchScoreTupleList.Add(new Tuple<string, string, double>(item.Query, item.Response, score));
                if (score > maxScore)
                {
                    maxScore = score;
                    indexOfMaxScore = ii;
                }
            }

            matchScoreTupleList.Sort((a, b) => b.Item3.CompareTo(a.Item3));
            int actualNumberOfResults = (int)Math.Min(matchScoreTupleList.Count, numberOfMatches);
            for (int jj = 0; jj < actualNumberOfResults; jj++)
            {
                RetrievalResultItem resultItem = new RetrievalResultItem(matchScoreTupleList[jj].Item2, matchScoreTupleList[jj].Item3);
                result.ItemList.Add(resultItem);
            }
            sw.Stop();
            double elapsedTime = sw.ElapsedTicks / (double)Stopwatch.Frequency;
            return result;
        }

        // (This method is not really used as the moment, since the data processing is (now)
        // carried out in the DataProcessingApplication instead; see also the comment
        // in the MainForm of the IRChatbotApplication).
        //
        // The data must be provided in a plain text file, with the (case-sensitive) format
        // Q: <sentence1> R: <sentence2>
        // Q: <sentence3> R: <sentence4>
        // ...
        //
        // i.e. one sentence-pair on each row, preceded by Q: and R:, respectively
        //
        public void ImportDialogueData(string fileName, out string outputMessage)
        {
            outputMessage = "";
            List<string> rawDataList = new List<string>();
            using (StreamReader dataReader = new StreamReader(fileName))
            {
                while (!dataReader.EndOfStream)
                {
                    string rawDataItem = dataReader.ReadLine();
                    if (rawDataItem != "")
                    {
                        if (!rawDataItem.StartsWith("%"))
                        {
                            rawDataList.Add(rawDataItem);
                        }
                    }
                }
                dataReader.Close();
            }
            int index = 0;
            int numberOfDiscardedItems = 0;
            int numberOfAddedItems = 0;
            while (index < rawDataList.Count)
            {
                string rawDataItem = rawDataList[index];
                List<string> rawDataItemSplit = rawDataItem.Split(new string[] { "Q:", "R:" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (rawDataItemSplit.Count == 2)
                {
                    DialogueCorpusItem item = new DialogueCorpusItem(rawDataItemSplit[0].Trim(new char[] { ' ', '\t' }), 
                                                                     rawDataItemSplit[1].Trim(new char[] { ' ', '\t' }));
                    itemList.Add(item);
                    numberOfAddedItems++;
                }
                else
                {
                    numberOfDiscardedItems++;
                }
                index++;
            }
            if (numberOfDiscardedItems > 0)
            {
                outputMessage = "Added " + numberOfAddedItems.ToString() + " items, discarding " +
                    numberOfDiscardedItems.ToString() + " items.";
            }
            GenerateVocabulary();
            ComputeIDFs();
            ComputeVectorRepresentations();
        }

        public List<Tuple<string, string, double>> MatchScoreTupleList
        {
            get { return matchScoreTupleList; }
        }

        [DataMember]
        public List<DialogueCorpusItem> ItemList
        {
            get { return itemList; }
            set { itemList = value; }
        }

        public DialogueCorpusVocabulary Vocabulary
        {
            get { return vocabulary; }
            set { vocabulary = value; }
        }
    }
}

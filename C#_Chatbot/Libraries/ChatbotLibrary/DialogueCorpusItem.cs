using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotLibrary
{
    [DataContract]
    public class DialogueCorpusItem
    {
        private string query; // Note that the "query" need not necessarily be a question
        private string response;
        private List<double> vectorRepresentation;

        public string AsString()
        {
            string itemAsString = "Q: " + query + " R: " + response;
            return itemAsString;
        }

        public DialogueCorpusItem(string query, string response)
        {
            this.query = query;
            this.response = response;
        }

        public void ComputeVectorRepresentation(DialogueCorpusVocabulary dictionary)
        {
            int numberOfAvailableWords = dictionary.WordDataList.Count;
            vectorRepresentation = new double[numberOfAvailableWords].ToList();
            List<string> queryAsSentence = GetQueryAsSentence();
            foreach (string word in queryAsSentence)
            {
                int index = dictionary.GetWordIndex(word);
                if (index >= 0)
                {
                    WordData wordData = dictionary.WordDataList[index];
                    vectorRepresentation[index] += wordData.IDF;  // Add the IDF, once for each instance of the word.
                }
            }
            double magnitude = 0;
            for (int ii = 0; ii < vectorRepresentation.Count; ii++)
            {
                magnitude += vectorRepresentation[ii] * vectorRepresentation[ii];
            }
            magnitude = Math.Sqrt(magnitude);
            for (int ii = 0; ii < vectorRepresentation.Count; ii++)
            {
                vectorRepresentation[ii] /= magnitude; //  (double)(queryAsSentence.Count);
            }
        }

        public List<string> GetQueryAsSentence()
        {
            List<string> sentence = query.ToLower().Split(new char[] { ' ', '\t', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return sentence;
        }
        public List<double> VectorRepresentation
        {
            get { return vectorRepresentation; }
            set { vectorRepresentation = value; }
        }

        [DataMember]
        public string Query
        {
            get { return query; }
            set { query = value; }
        }

        [DataMember]
        public string Response
        {
            get { return response; }
            set { response = value; }
        }
    }
}

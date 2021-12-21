using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotLibrary
{
    [DataContract]
    public class DialogueCorpusVocabulary
    {
        private List<WordData> wordDataList;
        private List<string> wordList;

        public DialogueCorpusVocabulary()
        {
            wordDataList = new List<WordData>();
        }

        public void Initialize()
        {
            wordDataList.Sort((a, b) => a.Word.CompareTo(b.Word));
            wordList = new List<string>();
            foreach (WordData wordData in wordDataList)
            {
                wordList.Add(wordData.Word);
            }
        }

        public int GetWordIndex(string word)
        {
            int index = wordList.BinarySearch(word);
            return index;
        }

        public Boolean ContainsWord(string word)
        {
            int index = wordList.BinarySearch(word);
            if (index >= 0) { return true; }
            else { return false; }
        }

        [DataMember]
        public List<WordData> WordDataList
        {
            get { return wordDataList; }
            set { wordDataList = value; }
        }
    }
}

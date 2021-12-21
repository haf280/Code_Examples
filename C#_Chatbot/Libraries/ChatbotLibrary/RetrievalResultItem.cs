using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotLibrary
{
    public class RetrievalResultItem
    {
        private string sentence { get; set; }
        private double score { get; set; }

        public RetrievalResultItem(string sentence, double score)
        {
            this.sentence = sentence;
            this.score = score;
        }

        public string Sentence
        {
            get { return sentence; }
            set { sentence = value; }
        }
        public double Score
        {
            get { return score; }
            set { score = value; }
        }
    }
}

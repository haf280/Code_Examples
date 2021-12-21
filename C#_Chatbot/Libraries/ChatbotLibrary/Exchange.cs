using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotLibrary
{
    public class Exchange
    {
        public string Sentence1 { get; set; }
        public string Sentence2 { get; set; }

        public Exchange(string sentence1, string sentence2)
        {
            Sentence1 = sentence1;
            Sentence2 = sentence2;
        }
    }
}

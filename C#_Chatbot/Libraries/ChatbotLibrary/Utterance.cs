using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotLibrary
{
    public class Utterance
    {
        public Speaker Speaker { get; set; }
        public string Sentence { get; set; }

        public Utterance(Speaker speaker, string sentence)
        {
            Speaker = speaker;
            Sentence = sentence;
        }
    }
}

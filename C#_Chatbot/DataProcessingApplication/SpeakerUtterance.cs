using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingApplication
{
    public class SpeakerUtterance
    {
        public string Speaker { get; set; }
        public string Utterance { get; set; }

        public SpeakerUtterance(string speaker, string utterance)
        {
            Speaker = speaker;
            Utterance = utterance;
        }

    }
}

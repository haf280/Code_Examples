using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotLibrary
{
    public class Chatbot
    {
        protected const int DEFAULT_NUMBER_OF_MATCHES = 5; // See Lines 47-49 below.
        protected const double DEFAULT_SCORE_THRESHOLD = 0.001; // NOTE: You may change this value.
        protected const string STANDARD_RESPONSE_0 = "I'm sorry, I don't understand.";
        // NOTE: You may add more standard responses.

        protected DialogueCorpus dialogueCorpus;
        protected int numberOfMatches = DEFAULT_NUMBER_OF_MATCHES;
        protected double scoreThreshold = DEFAULT_SCORE_THRESHOLD;
        protected List<string> standardResponseList = new List<string>() { STANDARD_RESPONSE_0 };
        protected Random randomNumberGenerator;
        protected List<Utterance> utteranceList;

        public virtual void Initialize()
        {
            randomNumberGenerator = new Random();
            utteranceList = new List<Utterance>();
        }

        public void SetDialogueCorpus(DialogueCorpus dialogueCorpus)
        {
            this.dialogueCorpus = dialogueCorpus;
        }

        public virtual RetrievalResultItem GenerateResponse(string query)
        {
            Utterance userUtterance = new Utterance(Speaker.User, query);
            utteranceList.Add(userUtterance);
            RetrievalResult result = dialogueCorpus.Match(query, numberOfMatches);
            RetrievalResultItem responseItem = null;
            if (result.ItemList.Count > 0)
            {
                if (result.ItemList[0].Score >= scoreThreshold)
                {
                    // The code below randomizes among the responses in the case where several query
                    // sentences provide the same (top) match score. This can happen if the query
                    // is very short (e.g. "no", "yes" and so on).
                    int lastIncludedIndex = 0;
                    int index = 1;
                    while (index < result.ItemList.Count)
                    {
                        if (Math.Abs(result.ItemList[index].Score - result.ItemList[0].Score) < double.Epsilon)
                        {
                            lastIncludedIndex = index;
                            index++;
                        }
                        else { break; }
                    }
                    if (lastIncludedIndex == 0) { responseItem = result.ItemList[0]; }
                    else
                    {
                        int responseIndex = randomNumberGenerator.Next(0, lastIncludedIndex + 1); // Exclusive upper bound
                        responseItem = result.ItemList[responseIndex];
                    }
                }
                else
                {
                    int randomResponseIndex = randomNumberGenerator.Next(0, standardResponseList.Count); // Exclusive upper bound.
                    string responseSentence = standardResponseList[randomResponseIndex];
                    responseItem = new RetrievalResultItem(responseSentence, 0);
                }
            }
            else // Should not happen normally. Just a precaution...
            {
                int randomResponseIndex = randomNumberGenerator.Next(0, standardResponseList.Count); // Exclusive upper bound.
                string responseSentence = standardResponseList[randomResponseIndex];
                responseItem = new RetrievalResultItem(responseSentence, 0);
                return responseItem;
            }
            Utterance agentUtterance = new Utterance(Speaker.Agent, responseItem.Sentence);
            utteranceList.Add(agentUtterance);
            return responseItem;
        }

        public List<Utterance> UtteranceList
        {
            get { return utteranceList; }
        }
    }
}

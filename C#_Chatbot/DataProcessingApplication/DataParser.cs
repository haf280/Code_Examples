using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataProcessingApplication
{
    public class DataParser
    {
        public static List<string> ExtractAllByStartString(List<string> inputDataList, string startString)
        {
            List<string> outputDataList = inputDataList.FindAll(s => s.StartsWith(startString));
            return outputDataList;
        }

        public static List<string> TrimWhiteSpace(List<string> inputDataList)
        {
            List<string> outputDataList = new List<string>();
            for (int ii = 0; ii < inputDataList.Count; ii++)
            {
                string outputDataString = inputDataList[ii].Trim();
                outputDataList.Add(outputDataString);
            }
            return outputDataList;
        }

        public static List<string> RemoveSubstrings(List<string> inputDataList, List<string> removalStringList)
        {
            List<string> outputDataList = new List<string>();
            for (int ii = 0; ii < inputDataList.Count; ii++)
            {
                string outputDataString = inputDataList[ii];
                for (int jj = 0; jj < removalStringList.Count; jj++)
                {
                    outputDataString = outputDataString.Replace(removalStringList[jj], "");
                }
                outputDataList.Add(outputDataString);
            }
            return outputDataList;
        }

        public static List<string> RemoveBetweenStrings(List<string> inputDataList, string startString, string endString)
        {
            List<string> outputDataList = new List<string>();
            for (int ii = 0; ii < inputDataList.Count; ii++)
            {
                string outputDataString = inputDataList[ii];
                while (outputDataString.Contains(startString) && outputDataString.Contains(endString))
                {
                    int firstStartStringIndex = outputDataString.IndexOf(startString);
                    int firstEndStringIndex = outputDataString.IndexOf(endString);
                    string beforeString = "";
                    if (firstStartStringIndex > 0)
                    {
                        beforeString = outputDataString.Substring(0, firstStartStringIndex);
                    }
                    string afterString = "";
                    if (firstEndStringIndex < outputDataString.Length - 1)
                    {
                        afterString = outputDataString.Substring(firstEndStringIndex + endString.Length, outputDataString.Length - firstEndStringIndex - endString.Length);
                    }
                    outputDataString = beforeString + afterString;
                    outputDataString.Trim();
                }
                outputDataList.Add(outputDataString);
            }
            return outputDataList;
        }

        public static List<SpeakerUtterance> GetSpeakerUtteranceList(List<string> inputDataList, List<string> splitStringList)
        {
            List<SpeakerUtterance> speakerUtteranceList = new List<SpeakerUtterance>();
            for (int ii = 0; ii < inputDataList.Count; ii++)
            {
                string inputDataString = inputDataList[ii];
                List<string> inputDataStringSplit = inputDataString.Split(splitStringList.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                if (inputDataStringSplit.Count == 2)
                {
                    SpeakerUtterance speakerUtterance = new SpeakerUtterance(inputDataStringSplit[0].Trim(), inputDataStringSplit[1].Trim());
                    speakerUtteranceList.Add(speakerUtterance);
                }
            }
            return speakerUtteranceList;
        }



        // A new method to delete statements that contains names or are longer than 12 words 
        public static List<SpeakerUtterance> DeleteExchangesWithNames(List<SpeakerUtterance> inputDataList)
        {
            //List<SpeakerUtterance> speakerUtteranceList = new List<SpeakerUtterance>();
            //speakerUtteranceList = inputDataList;
            HashSet<String> names = new HashSet<string>();

            for (int i = 0; i < inputDataList.Count; i++)
            {
                SpeakerUtterance su = inputDataList[i];
                names.Add(su.Speaker);

            }

            for (int ii = 0; ii < inputDataList.Count; ii++)
            {
                SpeakerUtterance su = inputDataList[ii];
                string[] sentences = su.Utterance.Split(new Char[] { '.', '!', '?' });
                int numberOfSentences = sentences.Length-1;
                if (numberOfSentences > 2)
                {
                    inputDataList.RemoveAt(ii);
                    ii--;
                    continue;
                }

                string[] words = su.Utterance.Split(new Char[] { ' ','.', '!', '?' });

                foreach (string word in words)
                {
                    int sentenceLength = words.Length;
                    if (sentenceLength >= 12)
                    {
                        inputDataList.RemoveAt(ii);
                        ii--;
                        break;
                    }
                    string trimedWord = word.Trim(new Char[] { ' ', ',', '!', '.' });
                    if (names.Contains(trimedWord) || trimedWord == "Dr")
                    {
                        inputDataList.RemoveAt(ii);
                        ii--;
                        break;
                    }  
                    
                }

            }

            return inputDataList;
        }


        public static List<SpeakerUtterance> RemoveUnknownCharacters(List<SpeakerUtterance> inputDataList)
        {
         
            string allowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789! ?:,.\"";
           
            for (int j = 0; j < inputDataList.Count; j++)
            {
                SpeakerUtterance su = inputDataList[j];

                string[] words = su.Utterance.Split(' ');

                string [] modifiedWords = new string [words.Length];
                int jj = 0;
                foreach (string word in words)
                {
                    
                    string modifiedString = "";
                    int ii = 0;
                    while (ii < word.Length)
                    {
                        Char c = word[ii];
                        if (allowedCharacters.Contains(c)) { modifiedString += word[ii]; }
                        else { modifiedString += "\'";}
                        ii++;
                    }
                    modifiedWords[jj] = modifiedString;
                    jj++;
                }
                string modifiedSentence = string.Join(" ", modifiedWords);
                su.Utterance = modifiedSentence;
            }

            return inputDataList;
        }

    }
}

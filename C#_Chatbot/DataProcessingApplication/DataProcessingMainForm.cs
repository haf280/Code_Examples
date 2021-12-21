using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AuxiliaryLibrary;
using ChatbotLibrary;
using ObjectSerializerLibrary;

namespace DataProcessingApplication
{
    public partial class DataProcessingMainForm : Form
    {
        #region Constants
        private const int PADDING = 22;
        #endregion

        #region Fields
        private List<string> rawDataList;
        private List<SpeakerUtterance> speakerUtteranceList;
        private DialogueCorpus dialogueCorpus;
        #endregion

        public DataProcessingMainForm()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                settingsComboBox.SelectedIndex = 0;
            }
        }

        private void ShowDialogueCorpus(ListBox listBox)
        {
            listBox.Items.Clear();
            if (dialogueCorpus == null) { return; }
            foreach (DialogueCorpusItem item in dialogueCorpus.ItemList)
            {
                string exchangeAsString = item.AsString();
                listBox.Items.Add(exchangeAsString);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loadRawDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = DialogFilters.Text;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader rawDataReader = new StreamReader(openFileDialog.FileName))
                    {
                        rawDataList = new List<string>();
                        while (!rawDataReader.EndOfStream)
                        {
                            string rawDataItem = rawDataReader.ReadLine();
                            rawDataList.Add(rawDataItem);
                        }
                    }
                }
            }
        }

        private void ShowSpeakerUtteranceList(ListBox listBox)
        {
            listBox.Items.Clear();
            foreach (SpeakerUtterance speakerUtterance in speakerUtteranceList)
            {
                listBox.Items.Add(speakerUtterance.Speaker.PadRight(PADDING) + "  " + speakerUtterance.Utterance);
            }
        }

        private void processRawDataButton_Click(object sender, EventArgs e)
        {

            // ( Step (1) = download HTML source and save to text file; see Assignment 1.3.)

            // Step (2)

            // 2.1: Preliminary processing:
            //
            // Note: You may have to modify a bit below if, for example, you are using a non-English OS.
            // Easiest solution: Set Windows10 to English-US
            //
            Encoding targetEncoding = Encoding.GetEncoding(1252);
            for (int ii = 0; ii < rawDataList.Count; ii++)
            {
                Byte[] encodedBytes = targetEncoding.GetBytes(rawDataList[ii]);
                string decodedString = Encoding.UTF8.GetString(encodedBytes);
                rawDataList[ii] = decodedString;
            }
            rawDataList = DataParser.TrimWhiteSpace(rawDataList);

            // Step 2.2: Extracting the speaker-utterance set:
            //
            // NOTE: The settings below work for SOME files, not all. You must
            // (as part of assigment 1.3) modify (or extend, rather) below so that the user is
            // allowed to select a particular setting (via the GUI) and then parse the HTML file.
            //
            // All raw data files (= HTML pages source saved as plain text) for a given
            // setting should be placed in the folder with the same name. For example,
            // the ParsingTest.txt file can be parsed with "Settings1" below, and
            // should therefore be placed in the Settings1/ folder.
            //
            // When you add more settings (Settings2, Settings3 etc.), make sure to
            // add an item in the settingsComboBox as well, so that the user can
            // select the corresponding settings.
            //
            // You may also wish to add a "Process batch" button, for which the
            // corresponding event handler would parse the entire set of raw
            // data files (all settings) that you have defined (the appropriate
            // settings for any given file can be inferred from the folder name
            // in which the file is placed, e.g. "Settings1". If so, you
            // may then wish to place the code in this method (processRawDataButton_Click)
            // in a separate method that takes as input a List<string> (i.e. the raw data)
            // and then call that method once for each data file.
            //

            // Values for these 5 parameters are set below
            string extractionString = null;
            List<string> tagRemovalList = null;
            string rangeRemovalStartString = null;
            string rangeRemovalEndString = null;
            List<string> speakerUtteranceSplitStringList = null;

            string settingsSpecification = settingsComboBox.SelectedItem.ToString();
            if (settingsSpecification == settingsComboBox.Items[0].ToString())
            {
                // Example of a page that can be parsed using the settings below:
                // https://tvshowtranscripts.ourboard.org/viewtopic.php?f=11&t=6738

                extractionString = "<p><strong>";
                tagRemovalList = new List<string>() { "<p>", "</p>", ":", "<em>", "</em>","#","/","&" ,"%"};
                rangeRemovalStartString = "(";
                rangeRemovalEndString = ")";
                speakerUtteranceSplitStringList = new List<string>() { "<strong>", "</strong>" };
            }
            // === ADD CODE HERE, for defining additional settings (Assignment 1.3) ===

            // Sequence of operations for extracting speaker-utterance items.
            //
            // NOTE: You may need to add more steps below, and possibly additional
            // methods in the DataParser!

            else if (settingsSpecification == settingsComboBox.Items[1].ToString())
            {
                // Example of a page that can be parsed using the settings below:
                // https://fangj.github.io/friends/season/0501.html

                extractionString = "<p><b>";
                tagRemovalList = new List<string>() { "<p>", "</p>", ":", "<em>", "</em>", "#", "/", "&", "%" };
                rangeRemovalStartString = "(";
                rangeRemovalEndString = ")";
                speakerUtteranceSplitStringList = new List<string>() { "<b>", "</b>" };
            }

            else if (settingsSpecification == settingsComboBox.Items[2].ToString())
            {
                // Example of a page that can be parsed using the settings below:
                // https://bigbangtrans.wordpress.com/series-1-episode-1-pilot-episode/

                extractionString = "<p class";
                //extractionString = "Calibri;"; <p class=\"MsoNormal\" style=\"margin:0 0 10pt; \"><span style=\"font - size:small; font - family:Calibri; \">"
                tagRemovalList = new List<string>() { "<p>", "</p>", "<em>", "</em>", "#", "/", "&", "%" };
                rangeRemovalStartString = "(";
                rangeRemovalEndString = ")";

                speakerUtteranceSplitStringList = new List<string>() { "", ": " };
            }

            // Step 2.2.1: Extract all strings beginning with a certain start string:
            List<string> dialogueDataList = DataParser.ExtractAllByStartString(rawDataList, extractionString);

            // Step 2.2.2: Remove (some) HTML tags and other unwanted strings:
            dialogueDataList = DataParser.RemoveSubstrings(dialogueDataList, tagRemovalList);

            // Step 2.2.3: Remove information (such as comments) that is not part of the dialogue:
            dialogueDataList = DataParser.RemoveBetweenStrings(dialogueDataList, rangeRemovalStartString, rangeRemovalEndString);

            if (settingsSpecification == settingsComboBox.Items[2].ToString())
            {
                rangeRemovalStartString = "<";
                rangeRemovalEndString = ">";
                dialogueDataList = DataParser.RemoveBetweenStrings(dialogueDataList, rangeRemovalStartString, rangeRemovalEndString);
                //  "<p class=\"MsoNormal\" style=\"margin0 0 10pt;\"><span style=\"font-sizesmall;font-familyCalibri;\">Leonard Uh, I�m not sure, everyone keep an eye on Howard in case he starts to swell up.</span>"
            }
            // Step 2.2.4: Extract the speaker-utterance list (set) using the remaining HTML tsga
            speakerUtteranceList = DataParser.GetSpeakerUtteranceList(dialogueDataList, speakerUtteranceSplitStringList);
            speakerUtteranceList = DataParser.DeleteExchangesWithNames(speakerUtteranceList);
            speakerUtteranceList = DataParser.RemoveUnknownCharacters(speakerUtteranceList);
            Console.WriteLine(speakerUtteranceList.Count);

            ShowSpeakerUtteranceList(speakerUtteranceListBox);

            // Step (3): To be written by you, as part of Assignment 1.3
            // 
            // 
            List<DialogueCorpusItem> addedItemsList = new List<DialogueCorpusItem>(); // You may change here, if you wish ...

            List<SpeakerUtterance> dialogueSequence = new List<SpeakerUtterance>();
            List<List<SpeakerUtterance>> sequenceList = new List<List<SpeakerUtterance>>();
            for (int i = 0; i < speakerUtteranceList.Count - 2; i++)
            {
                SpeakerUtterance s = (SpeakerUtterance)speakerUtteranceList[i];
                SpeakerUtterance s2 = (SpeakerUtterance)speakerUtteranceList[i + 1];
                String speaker1 = s.Speaker;
                String speaker2 = s2.Speaker;

                SpeakerUtterance s3 = (SpeakerUtterance)speakerUtteranceList[i + 2];
                Boolean sequence = false;
                int j = 0;
                dialogueSequence = new List<SpeakerUtterance>();
                if (!speaker1.Equals(speaker2))
                {
                    if (speaker1.Equals(s3.Speaker))
                    {
                        dialogueSequence.Add(s);
                        dialogueSequence.Add(s2);
                        dialogueSequence.Add(s3);
                        // SpeakerUtterance s4 = (SpeakerUtterance)speakerUtteranceList[i+3];
                        sequence = true;
                        j = i + 3;
                        i += 2;
                        while (sequence)
                        {
                            SpeakerUtterance sj;
                            if (j < speakerUtteranceList.Count)
                            {
                                sj = speakerUtteranceList[j];
                            }
                            else { break; }
                            if (sj.Speaker.Equals(speakerUtteranceList[j - 2].Speaker))
                            {
                                i++; j++;
                                dialogueSequence.Add(sj);
                            }
                           
                            else { sequence = false; }
                        }
                        sequenceList.Add(dialogueSequence); // for debuging

                    }
                }
                if (dialogueSequence != null)
                {
                    AddExchanges(dialogueSequence);
                }
            }
            


            // Then add the exchanges to the dialogue corpus ...
            void AddExchanges(List<SpeakerUtterance> suList)
            {
                if (suList != null)
                {

                    for (int i = 0; i < suList.Count - 1; i += 2)
                    {
                        SpeakerUtterance s1 = (SpeakerUtterance)suList[i];
                        SpeakerUtterance s2 = (SpeakerUtterance)suList[i + 1];
                        String query = s1.Utterance;
                        String response = s2.Utterance;
                        addedItemsList.Add(new DialogueCorpusItem(query, response));
                    }
                }
            }
            if (dialogueCorpus == null) { dialogueCorpus = new DialogueCorpus(); }
            dialogueCorpus.ItemList.AddRange(addedItemsList);  // You may change here too, if you wish ...

            // ...and finally display the entire dialogue data list
            //
            // Note: Since Step (3) is not yet implemented here, nothing will be shown in the
            // dialogueCorpusListBox - you must arrange this, by implementing Step (3) above!
            //
            ShowDialogueCorpus(dialogueCorpusListBox);
            Console.WriteLine(dialogueCorpus.ItemList.Count);
        }

        private void newDialogueCorpusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogueCorpus = new DialogueCorpus();
        }

        private void loadDialogueCorpusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = DialogFilters.XML;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    dialogueCorpus = (DialogueCorpus)ObjectXmlSerializer.ObtainSerializedObject(openFileDialog.FileName, typeof(DialogueCorpus));
                    ShowDialogueCorpus(dialogueCorpusListBox);
                }
            }
        }

        private void saveDialogueCorpusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dialogueCorpus == null) { return; }
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = DialogFilters.XML;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ObjectXmlSerializer.SerializeObject(saveFileDialog.FileName, dialogueCorpus);
                }
            }
        }


    }
}


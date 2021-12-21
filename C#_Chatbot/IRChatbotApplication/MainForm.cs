using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AuxiliaryLibrary;
using ChatbotLibrary;
using ObjectSerializerLibrary;

namespace IRChatbotApplication
{
    public partial class MainForm : Form
    {
        private const string USER_INPUT_PREFIX = "USER: ";
        private const string AGENT_OUTPUT_PREFIX = "AGENT: ";
        private const string DATE_TIME_FORMAT = "[yyyyMMdd HHmmss.fff] ";
        private const string SCORE_PREFIX = " (Score = ";
        private const string SCORE_FORMAT = "0.0000";
        private const string SCORE_SUFFIX = ")";
        private const string IDF_FORMAT_STRING = "0.0000";
        private const string ERROR_STRING = "ERROR";
        private const string ERROR_MESSAGE = "There was an error opening the file";
        private const string WARNING_STRING = "Warning";

        private Chatbot chatbot;
        private DialogueCorpus dialogueCorpus;
        private Boolean showScore = false;

        public MainForm()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                Initialize();
            }
        }

        private void Initialize()
        {
            dialogueListView.View = View.Details;
            dialogueListView.HeaderStyle = ColumnHeaderStyle.None;
            dialogueListView.FullRowSelect = true;
            dialogueListView.Columns.Add("", 1500); //  -2);
            inputTextBox.InputReceived -= new EventHandler<StringEventArgs>(HandleInputReceived);
            inputTextBox.InputReceived += new EventHandler<StringEventArgs>(HandleInputReceived);
            chatbot = new Chatbot();
            showScore = showScoreToolStripMenuItem.Checked;
        }

        private void HandleInputReceived(object sender, StringEventArgs e)
        {
            string query = e.StringValue;
            string userQueryDisplayString = DateTime.Now.ToString(DATE_TIME_FORMAT) + USER_INPUT_PREFIX + query;
            dialogueListView.Items.Insert(0, userQueryDisplayString).ForeColor = Color.Lime;

            // Generate agent output:
            RetrievalResultItem responseItem = chatbot.GenerateResponse(query);
            string agentResponseDisplayString = DateTime.Now.ToString(DATE_TIME_FORMAT) + AGENT_OUTPUT_PREFIX + responseItem.Sentence;
            if (showScore) { agentResponseDisplayString += SCORE_PREFIX + responseItem.Score.ToString(SCORE_FORMAT) + SCORE_SUFFIX; }
            dialogueListView.Items.Insert(0, agentResponseDisplayString).ForeColor = Color.Yellow;
        }

        private void ShowCorpus(DialogueCorpus corpus, ListBox listBox)
        {
            listBox.Items.Clear();
            foreach (DialogueCorpusItem item in corpus.ItemList)
            {
                listBox.Items.Add(item.AsString());
            }
        }

        private void ShowVocabulary(DialogueCorpus corpus, ListBox listBox)
        {
            listBox.Items.Clear();
            foreach (WordData wordData in corpus.Vocabulary.WordDataList)
            {
                listBox.Items.Add(wordData.AsString(IDF_FORMAT_STRING));
            }
        }

        private void loadDialogueCorpusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = DialogFilters.XML;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        dialogueCorpus =
                            (DialogueCorpus)ObjectXmlSerializer.ObtainSerializedObject(openFileDialog.FileName, typeof(DialogueCorpus));
                    }
                    catch
                    {
                        dialogueCorpus = null;
                        MessageBox.Show(ERROR_MESSAGE, ERROR_STRING);
                    }
                    if (dialogueCorpus != null)
                    {
                        dialogueCorpus.GenerateVocabulary();
                        dialogueCorpus.ComputeIDFs();
                        dialogueCorpus.ComputeVectorRepresentations();
                        ShowCorpus(dialogueCorpus, corpusItemsListBox);
                        ShowVocabulary(dialogueCorpus, corpusVocabularyListBox);
                        chatbot = new Chatbot();
                        chatbot.SetDialogueCorpus(dialogueCorpus);
                        chatbot.Initialize();
                        inputTextBox.Enabled = true;
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showScore = showScoreToolStripMenuItem.Checked;
        }

        // This method is not really used here (since the processing of data is instead
        // carried out in the DataProcessingMethod). Anyway, the method allows the user to
        // import a text file with additional exchanges (see also 
        // the ImportDialogueData() method in DialogueCorpus.
        private void importButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = DialogFilters.Text;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string outputMessage;
                    try
                    {
                        if (dialogueCorpus == null) { dialogueCorpus = new DialogueCorpus(); }
                        dialogueCorpus.ImportDialogueData(openFileDialog.FileName, out outputMessage);
                        if (outputMessage != "")
                        {
                            MessageBox.Show(outputMessage, WARNING_STRING);
                        }
                        if (dialogueCorpus.ItemList.Count > 0)
                        {
                            ShowCorpus(dialogueCorpus, corpusItemsListBox);
                            ShowVocabulary(dialogueCorpus, corpusVocabularyListBox);
                            inputTextBox.Enabled = true;
                            chatbot = new Chatbot();
                            chatbot.SetDialogueCorpus(dialogueCorpus);
                            chatbot.Initialize();
                        }
                    }
                    catch
                    {
                        MessageBox.Show(ERROR_MESSAGE, ERROR_STRING);
                    }
                }
            }
        }

        private void saveDialogueCorpusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Not implemented since the corpus instead is generated in the
            // DataProcessingApplication - no need to save the corpus here,
            // but this skeleton code has been left here for possible future use.
        }
    }
}

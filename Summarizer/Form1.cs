using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Summarizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSummarize_Click(object sender, EventArgs e)
        {
            List<Sentence> lstSentence = new List<Sentence>();
            if (rtxtInput.Text != null)
            {
                string strText = null;
                rtxtInput.Text = strText;
                lstSentence = SeparateSentences(strText);
                lstSentence = DetermineLengthFillDictionary(lstSentence);
                lstSentence = DetermineScore(lstSentence);
            }
        }

        public List<Sentence> SeparateSentences(string text)
        {
            List<Sentence> sentences = new List<Sentence>();
            string[] strSentences = Regex.Split(text, @"(?<=[\.!\?])\s+");
            string[] strDictionary = null;

            for (int i = 0; i < strSentences.Length; i++)
            {
                Sentence newSentence = new Sentence(i, 0, 0, strSentences[i], strDictionary);
                sentences.Add(newSentence);
            }

            return sentences;
        }

        public List<Sentence> DetermineLengthFillDictionary(List<Sentence> sentences)
        {
            List<Sentence> newSentences = new List<Sentence>(sentences);

            for (int i = 0; i < newSentences.Count(); i++)
            {
                for (int j = 0; j < newSentences[i].strSentence.Length; j++)
                {
                    string[] strDictionary = newSentences[i].strSentence.Split(' ');
                    newSentences[i].intAmountWords = strDictionary.Length;
                }
            }

            return newSentences;
        }

        public List<Sentence> DetermineScore(List<Sentence> sentences)
        {
            List<Sentence> newSentences = new List<Sentence>(sentences);

            return newSentences;
        }
    }
}

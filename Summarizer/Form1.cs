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
                lstSentence = DetermineLengthSentences(lstSentence);
            }
        }

        public List<Sentence> SeparateSentences(string text)
        {
            List<Sentence> sentences = new List<Sentence>();
            string[] strSentences = Regex.Split(text, @"(?<=[\.!\?])\s+");

            for (int i = 0; i < strSentences.Length; i++)
            {
                Sentence newSentence = new Sentence(i, 0, 0, strSentences[i]);
                sentences.Add(newSentence);
            }

            return sentences;
        }

        public List<Sentence> DetermineLengthSentences(List<Sentence> sentences)
        {
            List<Sentence> newSentences = new List<Sentence>(sentences);

            for (int i = 0; i < newSentences.Count(); i++)
            {
                for (int j = 0; j < newSentences[i].strSentence.Length; j++)
                {
                    int intAmountWords = 0;
                }
            }

            return newSentences;
        }
    }
}

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
                //sentence formatting and stuff
                string strText = null;
                strText = rtxtInput.Text.Trim();
                lstSentence = SeparateSentences(strText);
                lstSentence = DetermineLengthFillDictionary(lstSentence);
                lstSentence = DetermineScore(lstSentence);

                //sentence rank
                double dblCutdown = 0;
                try
                {
                    dblCutdown = double.Parse(txtNumInput.Text);

                    if (dblCutdown > lstSentence.Count())
                    {
                        dblCutdown = lstSentence.Count();
                    }

                    lstSentence = RankSentences(lstSentence);
                    lstSentence = CutSentences(lstSentence, dblCutdown);
                }
                catch
                {
                    Console.WriteLine("Invalid percentage or sentence input");
                }

                //output
                OutputSentences(lstSentence);
            }
        }

        #region Sentence formatting and stuff
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
                    newSentences[i].strDictionary = strDictionary;
                    newSentences[i].intAmountWords = strDictionary.Length;
                }
            }

            return newSentences;
        }

        public List<Sentence> DetermineScore(List<Sentence> sentences)
        {
            List<Sentence> newSentences = new List<Sentence>(sentences);
            List<Word> dictionary = new List<Word>();

            for(int i = 0; i < newSentences.Count(); i++)
            {
                for (int j = 0; j < newSentences[i].strDictionary.Length; j++)
                {
                    Word word = new Word(newSentences[i].intID, newSentences[i].strDictionary[j]);
                    dictionary.Add(word);
                }
            }

            //for quotes + 2
            for (int i = 0; i < dictionary.Count(); i++)
            {
                if (dictionary[i].strWord.Contains("\""))
                {
                    newSentences[dictionary[i].intID].intScore += 2;
                }
            }

            //for numbers + 10
            for (int i = 0; i < dictionary.Count(); i++)
            {
                if (dictionary[i].strWord.Any(char.IsDigit))
                {
                    newSentences[dictionary[i].intID].intScore += 10;
                }
            }

            //for common non repeated words
            string[] strCommonWords = new string[] { "the", "be", "to", "of", "and", "a", "in", "that", "have", "I", "it", "for", "not", "on", "with", "he", "as", "you", "do", "at", "this", "but", "his", "by", "from", "they", "we", "say", "her", "she", "or", "an", "will", "my", "one", "all", "would", "there", "their", "what", "so", "up", "out", "if", "about", "who", "get", "which", "go", "me", "when", "make", "can", "like", "time", "no", "just", "him", "know", "take", "people", "into", "year", "your", "good", "some", "could", "them", "see", "other", "than", "then", "now", "look", "only", "come", "its", "over", "think", "also", "back", "after", "use", "two", "how", "our", "work", "first", "well", "way", "even", "new", "want", "because", "any", "these", "give", "day", "most", "us"};
            List<string> lstCommonWords = new List<string>(strCommonWords);
            List<DictionaryWord> lstDictWord = new List<DictionaryWord>();

            //adds all common unique words to a single list
            for (int i = 0; i < dictionary.Count(); i++)
            {
                if (!lstCommonWords.Contains(dictionary[i].strWord))
                {
                    List<int> wordids = new List<int>(dictionary[i].intID);
                    DictionaryWord newDictWord = new DictionaryWord(wordids, dictionary[i].strWord, 1);
                    lstDictWord.Add(newDictWord);
                }
                else
                {
                    for (int j = 0; j < lstDictWord.Count(); j++)
                    {
                        if (lstDictWord[j].strWord == dictionary[i].strWord)
                        {
                            lstDictWord[j].intCount++;
                            lstDictWord[j].lstIntSentencesContaining.Add(dictionary[i].intID);
                        }
                    }
                }
            }

            //removes all common english words from the list
            for (int i = 0; i < lstDictWord.Count(); i++)
            {
                for (int j = 0; j < lstCommonWords.Count(); j++)
                {
                    if (lstDictWord[i].strWord == lstCommonWords[j])
                    {
                        lstDictWord.RemoveAt(i);
                    }
                }
            }

            //adds score to the sentences
            for (int i = 0; i < lstDictWord.Count(); i++)
            {
                for (int j = 0; j < lstDictWord[i].lstIntSentencesContaining.Count; j++)
                {
                    int intPlace = lstDictWord[i].lstIntSentencesContaining[j];
                    newSentences[dictionary[intPlace].intID].intScore += lstDictWord[i].intCount;
                }
            }

            return newSentences;
        }
        #endregion

        #region Sentence ranking
        public List<Sentence> RankSentences(List<Sentence> sentences)
        {
            List<Sentence> rankedSentences = sentences.OrderByDescending(score => score.intScore).ToList();
            return rankedSentences;
        }

        public List<Sentence> CutSentences(List<Sentence> sentences, double dblPercentOrValue)
        {
            List<Sentence> cutSentences = new List<Sentence>();

            int intAmount = sentences.Count();

            if (radPercentage.Checked)
            {
                double dblPercentage = intAmount * dblPercentOrValue;
                for (int i = 0; i < dblPercentage; i++)
                {
                    cutSentences.Add(sentences[i]);
                }
            }
            else
            {
                double dblSentences = dblPercentOrValue;
                for (int i = 0; i < dblSentences; i++)
                {
                    cutSentences.Add(sentences[i]);
                }
            }

            List<Sentence> rankedSentences = cutSentences.OrderBy(id => id.intID).ToList();

            return rankedSentences;
        }
        #endregion

        #region Output
        public void OutputSentences(List<Sentence> sentences)
        {
            string text = null;
            for (int i = 0; i < sentences.Count; i++)
            {
                text += sentences[i].strSentence + " \n";
            }

            rtxtOutput.Text = text;
        }
        #endregion
    }
}

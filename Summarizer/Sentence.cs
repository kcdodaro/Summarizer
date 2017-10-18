using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summarizer
{
    class Sentence
    {
        public int intID { get; set; }
        public int intAmountWords { get; set; }
        public int intScore { get; set; }
        public string strSentence { get; set; }

        public Sentence(int id, int amountwords, int score, string sentence)
        {
            try
            {
                intID = id;
                intAmountWords = amountwords;
                intScore = score;
            }
            catch
            {
                Console.WriteLine("Invalid data type in Sentence Class.");
            }
            strSentence = sentence;
        }
    }
}

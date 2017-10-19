using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summarizer
{
    class DictionaryWord
    {
        public List<int> lstIntSentencesContaining { get; set; }
        public string strWord { get; set; }
        public int intCount { get; set; }

        public DictionaryWord(List<int> sentences, string word, int count)
        {
            lstIntSentencesContaining = sentences;
            strWord = word;
            intCount = count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summarizer
{
    class Word
    {
        public int intID { get; set; }
        public string strWord { get; set; }

        public Word(int id, string word)
        {
            intID = id;
            strWord = word;
        }
    }
}

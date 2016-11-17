using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace epam2
{
    class FingerPrint : IAlgorythm
    {
        AttributeParser parser = new AttributeParser();
        public bool IsTheSame(string str1, string str2)
        {
            string toCompare1, toCompare2;
            toCompare1 = parser.SortAttributeByAlphabet(parser.RemovePunctuationInString(str1.ToLower()));
            toCompare2 = parser.SortAttributeByAlphabet(parser.RemovePunctuationInString(str2.ToLower()));
            return toCompare1 == toCompare2;
        }
    }
}

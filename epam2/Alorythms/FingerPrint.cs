using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clusterizer
{
    public class FingerPrint : IAlgorythm
    {
        AttributeParser parser = new AttributeParser();
        public bool IsTheSame(string str1, string str2)
        {
            string toCompare1, toCompare2;
            toCompare1 = parser.SortWordsByAlphabet(parser.NormalizeString(str1));
            toCompare2 = parser.SortWordsByAlphabet(parser.NormalizeString(str1));
            return toCompare1 == toCompare2;
        }
    }
}

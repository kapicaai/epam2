using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clusterizer
{
    public class NgramFingerPrint : IAlgorythm
    {
        int n;
        AttributeParser parser = new AttributeParser();

        public NgramFingerPrint(int n)
        {
            this.n = n;
        }

        public bool IsTheSame(string str1, string str2)
        {
            string toCompare1, toCompare2;
            toCompare1 = parser.GetNgramString(str1, n);
            toCompare2 = parser.GetNgramString(str2, n);
            return toCompare1 == toCompare2;
        }
    }

}

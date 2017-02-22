using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clusterizer
{
    public class StringPreparer
    {
        private AttributeParser parser = new AttributeParser();
        public string PrepareToFingerPrint(string str)
        {
            return parser.SortWordsByAlphabet(parser.NormalizeString(str));
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam2
{
    class AttributeParsing
    {
        public IList<string> RemovePunctuation(IList<string> source)
        {
            List<string> toProcessList = source.ToList();

            foreach(string attribute in toProcessList)
            {
                RemovePunctuationInString(attribute);
            }

            return toProcessList;
        }

        private void RemovePunctuationInString(string str)
        {
            StringBuilder toReturn = new StringBuilder();
            for(int i = 0; i < str.Length; i++)
            {
                if (!char.IsPunctuation(str, i))
                {
                     toReturn.Append(str[i]);
                }
            }
            str = toReturn.ToString();
        }
    }
}

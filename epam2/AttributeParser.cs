using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam2
{
    class AttributeParser
    {
        public IList<string> RemovePunctuation(IList<string> source)
        {
            List<string> toProcessList = source.ToList();

            for(int i = 0; i < toProcessList.Count; i++)
            {
                toProcessList[i] = RemovePunctuationInString(toProcessList[i]);
                toProcessList[i] = SortByAlphabet(toProcessList[i]);
            }

            return toProcessList;
        }

        private string RemovePunctuationInString(string str)
        {
            StringBuilder toReturn = new StringBuilder();
            for(int i = 0; i < str.Length; i++)
            {
                if (!char.IsPunctuation(str, i))
                {
                     toReturn.Append(str[i]);
                }
            }
            return toReturn.ToString();
        }

        private List<string> SplitIntoWords(string str)
        {
            string[] splitted = str.Split(' ', '\t', '\n');
            return splitted.ToList();
        }

        private string SortByAlphabet(string str)
        {
            List<string> strList = SplitIntoWords(str);
            strList.Sort();
            StringBuilder builder = new StringBuilder();
            foreach (string word in strList)
            {
                builder.Append(word);
            }
            return builder.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam2
{
    class AttributeParser
    {
        public IEnumerable<string> RemovePunctuation(IEnumerable<string> source)
        {
            List<string> toProcessList = source.ToList();

            for(int i = 0; i < toProcessList.Count; i++)
            {
                toProcessList[i] = RemovePunctuationInString(toProcessList[i]); ;
            }

            return toProcessList;
        }

        public IEnumerable<string> SortByAlphabet(IEnumerable<string> source)
        {
            List<string> toProcessList = source.ToList();

            for (int i = 0; i < toProcessList.Count; i++)
            {
                
                toProcessList[i] = SortAttributeByAlphabet(toProcessList[i]);
            }

            return toProcessList;
        }

        //public IList<string> GetNgrams(IList<string> source, int n)
        //{
        //    for(int i = 0; i < source.Count; i++)
        //    {
        //        source[i] = RemoveWhiteSpaces(source[i]);
        //        List<string> ngrams = GetNgramString(source[i], n);
                
        //    }
        //}

        public string RemovePunctuationInString(string str)
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


        public string RemoveWhiteSpaces(string str)
        {
            return str.Replace(" ", "");
        }
        public  string NormalizeString(string str)
        {
            return RemoveWhiteSpaces(RemovePunctuationInString(str.ToLower()));
        }
        

        public List<string> SplitIntoWords(string str)
        {
            string[] splitted = str.Split(' ', '\t', '\n');
            return splitted.ToList();
        }

        public string GetNgramString(string source, int n)
        {
            string str = NormalizeString(source);
            StringBuilder builder = new StringBuilder();
            
            for (int i = 0; i <= str.Length - n; i++)
            {
                builder.Append(new string(str.Substring(i, n).OrderBy(ch => ch).ToArray()));
            }
            return builder.ToString();
        }

        public string SortAttributeByAlphabet(string str)
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

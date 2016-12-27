using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clusterizer
{
    public class Levenstein : IAlgorythm
    {
        private int level;

        public Levenstein(int level)
        {
            this.level = level;
        }

        public bool IsTheSame(string str1, string str2)
        {
            AttributeParser parser = new AttributeParser();   
            return ComputeDistance(parser.NormalizeString(str1), parser.NormalizeString(str2)) < level;
        }

        private int ComputeDistance(string str1, string str2)
        {
            if (str1.Length == 0)
                return str2.Length;
            if (str2.Length == 0)
                return str1.Length;

            int[,] distTable = new int[str1.Length + 1, str2.Length + 1];

            for (int i = 0; i <= str1.Length; i++)
            {
                distTable[i, 0] = i;
            }
            for (int j = 0; j <= str2.Length; j++)
            {
                distTable[0, j] = j;
            }

            for (int i = 1; i <= str1.Length; i++)
            {
                for (int j = 1; j <= str2.Length; j++)
                {
                    if (str1[i - 1] == str2[j - 1])
                    {
                        distTable[i, j] = distTable[i - 1, j - 1];
                        continue;
                    }

                    distTable[i, j] = Math.Min(Math.Min(distTable[i - 1, j], distTable[i, j - 1]), distTable[i - 1, j - 1]) + 1;
                }
            }

            return (distTable[str1.Length, str2.Length]);
        }
    }
}

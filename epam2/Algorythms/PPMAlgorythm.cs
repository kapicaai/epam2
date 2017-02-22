using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

namespace Clusterizer
{
    public class PPMAlgorythm : IAlgorythm
    {
        float level;

        public PPMAlgorythm(float level)
        {
            this.level = level;
        }


        public bool IsTheSame(string str1, string str2)
        {
            float diff = (CompressLenght(str1 + str2) + CompressLenght(str2 + str1)) /
                (CompressLenght(str1 + str1) + CompressLenght(str2 + str2));
            return diff < level;
        }

        private long CompressLenght(string str)
        {
            
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (GZipStream gZip = new GZipStream(memoryStream, CompressionMode.Compress))
                {
                    using (MemoryStream stringStream = new MemoryStream(Encoding.UTF8.GetBytes(str)))
                    {
                        stringStream.CopyTo(gZip);
                    }
                }
                    memoryStream.Flush();
                return memoryStream.Position;
            }
        }
        
    }
}

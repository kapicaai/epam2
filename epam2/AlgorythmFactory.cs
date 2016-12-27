using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clusterizer
{
    class AlgorythmFactory
    {
        public IAlgorythm CreateAlgorythm(string algName)
        {
            IAlgorythm algorythm = new FingerPrint();
            switch (algName)
            {
                case "finger":
                    {
                        algorythm = new FingerPrint();
                        break;
                    }
                case "ngram":
                    {
                        algorythm = new NgramFingerPrint(3);
                        break;
                    }
                case "lev":
                    {
                        algorythm = new Levenstein(3);
                        break;
                    }
                case "ppm":
                    {
                        algorythm = new PPMAlgorythm(0.7f);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return algorythm;
        }
    }
}

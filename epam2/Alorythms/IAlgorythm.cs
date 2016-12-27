using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clusterizer
{
    public interface IAlgorythm
    {
        bool IsTheSame(string str1, string str2);
    }
}

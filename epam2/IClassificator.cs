using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clusterizer
{
    public interface IClassificator
    {
        IList<DataTable> Classify(DataTable table, string nameOfAttribute);
    }
}

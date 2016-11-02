using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam2
{
    public class SimpleAlgorithm : IClassificationAlgorithm
    {
        public IList<DataTable> Classify(DataTable table, string nameOfAttribute)
        {
            List<DataTable> tables = new List<DataTable>();
            for(int i = 0; i < 2; i++)
                tables.Add(new DataTable());

            for(int i = 0; i < table.Data.Count/2; i++)
            {
                tables[0].Data.Add(table.Data[i]);
                tables[1].Data.Add(table.Data[table.Data.Count / 2+i]);
            }
            return tables;
        }
    }
}

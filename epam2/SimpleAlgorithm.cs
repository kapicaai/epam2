using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam2
{
    public class SimpleAlgorithm : IClassificationAlgorithm
    {
        public IList<DataTable> Classify(DataTable table)
        {
            List<DataTable> tables = new List<DataTable>();
            for(int i = 0; i < 2; i++)
                tables.Add(new DataTable());

            for(int i = 0; i < table.table.Count/2; i++)
            {
                tables[0].table.Add(table.table[i]);
                tables[1].table.Add(table.table[table.table.Count / 2+i]);
            }
            return tables;
        }
    }
}

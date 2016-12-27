using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clusterizer
{
    class Classificator : IClassificator
    {
        IAlgorythm algo;
        AttributeParser parser = new AttributeParser();

        public Classificator(IAlgorythm algorythm)
        {
            algo = algorythm;
        }

        public IList<DataTable> Classify(DataTable mainTable, string nameOfAttribute)
        {
            DataTable mainTableCopy = mainTable.Clone();
            int numberOfColumn = mainTable.GetNumberOfAttribute(nameOfAttribute);
            IEnumerable<string> clasterizeColumn = mainTable.GetColumn(numberOfColumn);

            IList<DataTable> resultTables = new List<DataTable>();
            int count = 0;

            foreach (var attribute in clasterizeColumn)
            {
                DataTable temp = new DataTable(mainTable.Header);
                DataTable x = (resultTables as List<DataTable>).
                    Find(t => algo.IsTheSame(attribute, t.GetColumn(numberOfColumn).First()));                
                if (x != null)
                {
                    x.Rows.Add(mainTable.GetRow(count));
                }
                else
                {
                    temp.Rows.Add(mainTable.GetRow(count));
                    resultTables.Add(temp);
                }
                
                count++;
            }

            return resultTables;
        }
    }
}

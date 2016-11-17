using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam2
{
    class Classificator : IClassificationAlgorithm
    {
        IAlgorythm algo;
        AttributeParser parser = new AttributeParser();

        public Classificator(IAlgorythm algorythm)
        {
            algo = algorythm;
        }

        public IList<DataTable> Classify(DataTable mainTable, string nameOfAttribute)
        {

            int numberOfColumn = mainTable.GetNumberOfAttribute(nameOfAttribute);
            IEnumerable<string> clasterizeColumn = mainTable.GetColumn(numberOfColumn);

            IList<DataTable> resultTables = new List<DataTable>();
            int count = 0;
            foreach (var attribute in clasterizeColumn)
            {
                DataTable temp = new DataTable(mainTable.Header);
                DataTable x = AimCluster(resultTables, attribute, numberOfColumn);                
                if (x != null)
                {
                    x.Data.Add(mainTable.GetRow(count));
                }
                else
                {
                    temp.Data.Add(mainTable.GetRow(count));
                    resultTables.Add(temp);
                }
                
                count++;
            }

            return resultTables;
        }

        private DataTable AimCluster(IList<DataTable> resultTables, string attribute, int numbOfColumn)
        {
            return (resultTables as List<DataTable>).Find(x => algo.IsTheSame(attribute, x.GetColumn(numbOfColumn).First()));
        }
    }
}

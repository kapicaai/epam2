using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam2
{
    class SimpleFingerPrint : IClassificationAlgorithm
    {
        AttributeParser parser = new AttributeParser();
        public IList<DataTable> Classify(DataTable mainTable, string nameOfAttribute)
        {
            IList<DataTable> resultTables = new List<DataTable>();

            IList<string> attributesList = mainTable.GetColumn(nameOfAttribute);

            attributesList = parser.RemovePunctuation(attributesList);
            int count = 0;
            foreach (var attribute in attributesList)
            {
                DataTable temp = new DataTable(mainTable.Header);

                if ((resultTables as List<DataTable>).Exists
                    (x => x.GetColumn(nameOfAttribute).Contains(attribute)))
                {
                    resultTables.First(x => x.GetColumn(nameOfAttribute).Contains(attribute)).Data.
                        Add(mainTable.GetRow(count));
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
    }
}

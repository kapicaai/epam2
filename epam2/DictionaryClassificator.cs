using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clusterizer
{
    class DictionaryClassificator : IClassificator
    {
        private IDictionary<string, IList<int>> clusters = new Dictionary<string, IList<int>>();

        private IAlgorythm algo;
        private StringPreparer stringPreparer = new StringPreparer();
        private int numberOfColumn;

        public DictionaryClassificator(IAlgorythm algorythm, int numOfColumn)
        {
            algo = algorythm;
            numberOfColumn = numOfColumn;
        }

        public IList<DataTable> Classify(DataTable mainTable, string nameOfAttribute)
        {
            DataTable mainTableCopy = mainTable.Clone();
            numberOfColumn = mainTable.GetNumberOfAttribute(nameOfAttribute);
            IList<string> clasterizeColumn = (IList<string>)mainTable.GetColumn(numberOfColumn);

            IList<DataTable> resultTables = new List<DataTable>();
            int count = 0;

            foreach (var attribute in clasterizeColumn)
            {
                string key = clusters.Keys.FirstOrDefault
                    (k => algo.IsTheSame(attribute, k));
                if (key == null)
                {                 
                    clusters.Add(stringPreparer.PrepareToFingerPrint(attribute), new List<int>());
                }
                clusters[key].Add(clasterizeColumn.IndexOf(attribute));
                count++;
            }

            resultTables = MakeTablesFromDictionaries(clusters, mainTable);

            return resultTables;
        }

        private IList<DataTable> MakeTablesFromDictionaries(IDictionary<string, IList<int>> dict, DataTable mainTable)
        {
            IList<DataTable> tables = new List<DataTable>();
            foreach(string key in dict.Keys)
            {
                var data = dict[key];
                DataTable table = new DataTable(mainTable.Header);
                table.Rows = mainTable.Rows.Where(x => data.Contains(mainTable.Rows.IndexOf(x))).ToList();
            }
            return tables;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace epam2
{
    class Program
    {
        static void Main(string[] args)
        {
            //string filename = args[0];
            DataTable table = new DataTable();
            MyCsvParser parser = new MyCsvParser();
            table.table = parser.GetCsvData("simpsons_characters.csv");
            FileInfo fileInfo = new FileInfo("simpsons_characters.csv");
            IClassificationAlgorithm algo = new SimpleAlgorithm();
            List<DataTable> newTables = algo.Classify(table);

            MyCsvWriter writer = new MyCsvWriter();
            for(int i = 0; i < newTables.Count; i++)
            {
                writer.Write(newTables[i].table, fileInfo.DirectoryName+ "\\" + i + "claster.csv");
            }

        }
    }
}

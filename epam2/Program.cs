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
            string fileName = "Contarcts.csv";
            DataTable table;
            MyCsvParser parser = new MyCsvParser();
            table = new DataTable(parser.GetCsvData(fileName), parser.GetCsvHeader(fileName));
            FileInfo fileInfo = new FileInfo(fileName);

            IClassificationAlgorithm algo = new Classificator(new FingerPrint());
            List<DataTable> newTables = (List<DataTable>) algo.Classify(table, "Contract Description (USAspending)");

            MyCsvWriter writer = new MyCsvWriter();
            IEnumerable<DataTable> toWrite = newTables.Where(x => x.Data.Count() > 1);
            int count = 0;
            string outputFileFormat = "{0}\\output\\{1}-Contracts.csv";
            foreach(DataTable t in toWrite)
            {
                writer.Write(t.Data, string.Format(outputFileFormat, fileInfo.DirectoryName, count));
                count++;
            }

        }
    }
}

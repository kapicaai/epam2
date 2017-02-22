using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


//Investment title, Investment Description, Vender Name
namespace Clusterizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = args[0];
            //string fileName = "Contarcts.csv";
            DataTable table;
            MyCsvParser parser = new MyCsvParser();
            table = new DataTable(parser.GetCsvData(fileName), parser.GetCsvHeader(fileName));
            FileInfo fileInfo = new FileInfo(fileName);
            
            string columnName = "Vendor Name(USAspending)";

            string alg = Console.ReadLine();
            IAlgorythm algorythm;

            algorythm = new AlgorythmFactory().CreateAlgorythm(alg);
            
            IClassificator classificator = new Classificator(new FingerPrint());
            List<DataTable> newTables = (List<DataTable>) classificator.Classify(table, columnName);
            
            IEnumerable<DataTable> toWrite = newTables.Where(x => x.Rows.Count() > 1);
            WriteClusters(toWrite, fileInfo);
                        
        }

        static void WriteClusters(IEnumerable<DataTable> toWrite, FileInfo fileInfo)
        {
            MyCsvWriter writer = new MyCsvWriter();
            int count = 0;
            string outputFileFormat = "{0}\\output\\{1}-Contracts.csv";
            foreach (DataTable t in toWrite)
            {
                writer.Write(t.Rows, string.Format(outputFileFormat, fileInfo.DirectoryName, count));
                count++;
            }
        }

        static void WriteMain(IEnumerable<DataTable> toWrite, FileInfo fileInfo)
        {
            MyCsvWriter writer = new MyCsvWriter();
            int count = 0;
            string outputFileFormat = "ContractsNew.csv";
            foreach (DataTable t in toWrite)
            {
                writer.Write(t.Rows, string.Format(outputFileFormat, fileInfo.DirectoryName, count));
                count++;
            }
        }

        static DataTable ReplaceTheSame(DataTable table, int columnNumber)
        {
            string toReplace = table.Rows.FirstOrDefault()[columnNumber];
            foreach(IList<string> row in table.Rows)
            {
                row[columnNumber] = toReplace;
            }
            return table;
        }
    }
}

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
            string fileName = "simpsons_characters.csv";
            DataTable table;
            MyCsvParser parser = new MyCsvParser();
            table = new DataTable(parser.GetCsvData(fileName), parser.GetCsvHeader(fileName));
            FileInfo fileInfo = new FileInfo(fileName);

            IClassificationAlgorithm algo = new SimpleFingerPrint();
            List<DataTable> newTables = (List<DataTable>) algo.Classify(table, "gender");

            MyCsvWriter writer = new MyCsvWriter();
            for(int i = 0; i < newTables.Count; i++)
            {
                writer.Write(newTables[i].Data, fileInfo.DirectoryName+ "\\" + i + "claster.csv");
            }

        }
    }
}

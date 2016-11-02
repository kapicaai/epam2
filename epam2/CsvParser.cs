using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CsvHelper;

namespace epam2
{
    class MyCsvParser
    {
        StreamReader reader;

        public IList<IList<string>> GetCsvData(string filename)
        {
            reader = new StreamReader(filename);
            
            var parser = new CsvParser(reader);
            IList<IList<string>> records = new List<IList<string>>();
            var row = new string[2];
            row = parser.Read();
            while (true)
            {
                row = parser.Read();
                if (row == null)
                    break;
                
                records.Add(row.ToList());
            }
            reader.Close();
            return records;
        }

        public IList<string> GetCsvHeader(string filename)
        {
            reader = new StreamReader(filename);

            var parser = new CsvParser(reader);
            var row = new string[2];
            row = parser.Read();
            reader.Close();
            return row.ToList();
        }
    }
}

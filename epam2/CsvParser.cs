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

        public List<List<string>> GetCsvData(string filename)
        {
            reader = new StreamReader(filename);
            
            var parser = new CsvParser(reader);
            var records = new List<List<string>>();
            var row = new string[2];
            while(true)
            {
                row = parser.Read();
                if (row == null)
                    break;
                
                records.Add(row.ToList());
            }
            reader.Close();
            return records as List<List<string>>;
        }
    }
}

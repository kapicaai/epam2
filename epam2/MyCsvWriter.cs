using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using CsvHelper;

namespace epam2
{
    public class MyCsvWriter
    {
        public void Write(IList<IList<string>> list, string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);
            var csvWriter = new CsvWriter(writer);
            foreach(var el in list)
            {
                foreach(var field in el)
                    csvWriter.WriteField(field);
                csvWriter.NextRecord();
            }
            writer.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam2
{
    public class DataTable
    {
        public IList<IList<string>> table { get; set; }

        public DataTable()
        {
            
        }

        public IList<string> GetRow(int number)
        {
            if (table != null && table.Count > number)
                return table[number];
            return null;
        }

        public List<string> GetColumn(string name)
        {
            int number = table.First().IndexOf(name);
            if (table != null && (table.Count > 0) && table.First().Count > number)
            {
                List<string> column = table.Select(x => x[number]).ToList();
                return column;
            }
            return null;
        }
    }
}

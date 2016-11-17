using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam2
{
    public class DataTable
    {
        public IList<string> Header { get; private set; }
        IList<IList<string>> table;
        public IList<IList<string>> Data
        {
            get
            {
                if(table != null)
                    return table;
                return null;
            }
            set
            {
                table = value;
            }
        }

        public DataTable()
        {
            table = new List<IList<string>>();
        }

        public DataTable(IList<IList<string>> tableList)
        {
            table = tableList;
        }

        public DataTable(IList<string> headers) : this()
        {
            Header = headers;
        }

        public DataTable(IList<IList<string>> tableList, IList<string> headers) : this(tableList)
        {
            Header = headers;
        }

        public IList<string> GetRow(int number)
        {
            if (Data != null && Data.Count > number)
                return Data[number];
            return null;
        }

        public IEnumerable<string> GetColumn(int number)
        {
            if (Data != null && (Data.Count > 0))
            {
                if (Data.First().Count > number)
                {
                    return Data.Select(x => x[number]);                    
                }
            }
            return null;
        }

        public List<string> GetColumn(string name)
        {
            if (Data != null && (Data.Count > 0))
            {
                int number = (Header as List<string>).FindIndex(x => x.Contains(name));
                if (Data.First().Count > number)
                {
                    List<string> column = Data.Select(x => x[number]).ToList();
                    return column;
                }
            }
            return null;
        }

        public int GetNumberOfAttribute(string name)
        {
            if (Data != null && (Data.Count > 0))
            {
                return Header.IndexOf(name);
            }
            return -1;
        }
    }
}

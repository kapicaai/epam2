﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clusterizer
{
    public class DataTable
    {
        public IList<string> Header { get; private set; }
        IList<IList<string>> table;
        public IList<IList<string>> Rows
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
            if (Rows != null && Rows.Count > number)
                return Rows[number];
            return null;
        }

        public IEnumerable<string> GetColumn(int number)
        {
            if (Rows != null && (Rows.Count > 0))
            {
                if (Rows.First().Count > number)
                {
                    return Rows.Select(x => x[number]);                    
                }
            }
            return null;
        }

        public List<string> GetColumn(string name)
        {
            if (Rows != null && (Rows.Count > 0))
            {
                int number = (Header as List<string>).FindIndex(x => x.Contains(name));
                if (Rows.First().Count > number)
                {
                    List<string> column = Rows.Select(x => x[number]).ToList();
                    return column;
                }
            }
            return null;
        }

        public int GetNumberOfAttribute(string name)
        {
            if (Rows != null && (Rows.Count > 0))
            {
                return Header.IndexOf(name);
            }
            return -1;
        }

        public DataTable Clone()
        {
            return new DataTable
            { Rows = this.Rows.ToList(), Header = this.Header.ToList(), table = this.table.ToList() };
        }

        public bool IsColumnBoring(int numberOfColumn)
        {
            IEnumerable<string> column = GetColumn(numberOfColumn);
            string first = column.First();
            if (first != null && first.Length > 0)
            {
                return column.All(x => string.Equals(x, first));
            }
            return true;
        }
    }
}

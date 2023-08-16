using System;

namespace Retrieval.SDK
{
    public class DataTable
    {
        public class DataRow
        {
            public int Count;
        }

        public class DataColumn
        {
            public int Count;
        }
        public IList<DataRow> Rows { get; private set; } 
    }
}
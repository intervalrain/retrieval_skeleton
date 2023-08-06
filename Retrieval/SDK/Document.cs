using System;
using DataTable = Retrieval.SDK.DataTable;

namespace Retrieval.SDK
{
    public class Document
    {
        private DataManager data;
        public class DataManager
        {
            private IList<DataTable> tables;
            public  IList<DataTable> Tables;
        }

        public DataManager Data => data;

        public DataTable DataTableReference => Data.Tables.FirstOrDefault();
    }
}
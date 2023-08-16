using System;
using Retrieval.SDK;
using System.Data;
using Retrieval.RetrievalForms.Container;
using DataTable = Retrieval.SDK.DataTable;

namespace Retrieval.DataLoader
{
    public static class DataLoder
    {
        public static DataTable Load( string sql, string text)
        {
            IDBConnect connection = default;
            DataTable table = connection.ExecuteIntoTable(sql, text);
            return table;
        }

        public static void Visualize(DataTable table)
        {
        }
    }
}
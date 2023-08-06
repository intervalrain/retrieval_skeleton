using System;
using System.Data;
using DataTable = System.Data.DataTable;

namespace Retrieval.SDK
{
    public interface IDBConnect
    {
        public void ExecuteIntoTable(string sql, DataTable table);
        
        public DataTable ExecuteIntoTable(string sql, string title);

        public IDataReader ExecuteQuery(string sql);
        
        public IDataReader ExecuteQuery(string sql, IDataParameter parameter);
        
        public IDataReader ExecuteQuery(string sql, List<IDataParameter> parameter);
    }
}
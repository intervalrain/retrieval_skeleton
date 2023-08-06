using System;
using System.ComponentModel;
using Retrieval.RetrievalForms.Controls.Enumerates;

namespace Retrieval.RetrievalForms.Controls.Container
{
    public class Field
    {
        private DataIndex _dataIndex;
        private string _tableName;
        private string _fieldName;
        private string _alias;

        public DataIndex DataIndex => _dataIndex;
        public string TableName => _tableName;
        public string FieldName => _fieldName;
        public string Alias => _alias;

        private Field(DataIndex dataIndex, string tableName, string fieldName, string alias)
        {
            _dataIndex = dataIndex;
            _tableName = tableName;
            _fieldName = fieldName;
            _alias = alias;
        }

        public static Field CreateField(DataIndex dataIndex, string tableName, string fieldName, string alias)
        {
            return new Field(dataIndex, tableName, fieldName, alias);
        }
        
        public static Field CreateField(DataIndex dataIndex, string tableName, string fieldName)
        {
            return new Field(dataIndex, tableName, fieldName, fieldName);
        }

        public string GetQuery(bool AddAlias = false)
        {
            string prefix = _tableName + ".";
            string postfix = AddAlias ? (" As " + _alias) : string.Empty;
            return prefix + _fieldName + postfix;
        }

        public string GetQuery(char prefix, bool AddAlias = false)
        {
            string postfix = AddAlias ? (" As " + _alias) : string.Empty;
            return prefix + "." + _fieldName + postfix;
        }
    }
}
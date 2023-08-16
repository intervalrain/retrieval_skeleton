using System;
using Retrieval.SDK;
using System.Data;
using System.Diagnostics;
using Retrieval.RetrievalForms.Container;
using DataTable = System.Data.DataTable;
using System.Numerics;

namespace Retrieval.DataCore.Container
{
    public abstract class Field<T> : IField
    {
        public string TableName { get; private set; }
        public string FieldName { get; private set; }
        public string Alias { get; private set; }

        public Field(string tableName, string fieldName, string alias)
        {
            this.TableName = tableName;
            this.FieldName = fieldName;
            this.Alias = alias;
        }
        
        public Field(string tableName, string fieldName)
        {
            this.TableName = tableName;
            this.FieldName = fieldName;
        }

        public virtual string GetQuery(bool addAlias = false)
        {
            return TableName + "." + FieldName + (addAlias ? (" As " + Alias) : string.Empty);
        }
    }
}
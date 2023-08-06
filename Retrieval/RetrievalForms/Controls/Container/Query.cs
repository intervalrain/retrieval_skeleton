using System;
using System.Text;
using System.Collections.Generic;

namespace Retrieval.RetrievalForms.Controls.Container
{
    public class Query
    {
        private Field[] _fields;
        private Filter[] _filters;
        
        public Query(Field[] fields, Filter[] filters)
        {
            _fields = fields;
            _filters = filters;
        }
        
        public string GetQuery()
        {
            StringBuilder fieldBuilder = new StringBuilder("Select\n");
            StringBuilder tableBuilder = new StringBuilder("From\n");
            StringBuilder filterBuilder = new StringBuilder("Where\n");
            Dictionary<string, char> tableAlias = new Dictionary<string, char>();
            foreach (Field field in _fields)
            {
                string tableName = field.TableName;
                char prefix = default;
                if (tableAlias.ContainsKey(tableName))
                {
                    prefix = tableAlias[tableName];
                }
                else
                {
                    tableAlias.Add(tableName, (char)('a' + tableAlias.Count));
                }
                fieldBuilder.AppendLine("\r" + field.GetQuery(prefix, true));
            }


            return fieldBuilder.ToString() + tableBuilder.ToString() + filterBuilder.ToString();
        }
    }
}
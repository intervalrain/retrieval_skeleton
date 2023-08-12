using System;
using Retrieval.SDK;
using System.Data;
using Retrieval.RetrievalForms.Container;
using DataTable = System.Data.DataTable;

namespace Retrieval.DataCore.Container
{
    public class Query
    {
        private IEnumerable<IField> fields;
        private IEnumerable<IFilter> filters;
        public virtual string GetQuery()
        {
            return "";
        }
    }
}
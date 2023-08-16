using System;
using Retrieval.SDK;
using System.Data;
using Retrieval.RetrievalForms.Container;
using DataTable = System.Data.DataTable;
using System.Numerics;

namespace Retrieval.DataCore.Container
{
    public abstract class Filter<T> : IFilter
    {
        private IField field;
        private T value;

        public Filter(IField field, T value)
        {
            this.field = field;
            this.value = value;
        }
        
        public virtual IField GetField()
        {
            return field;
        }

        public virtual string GetQuery()
        {
            Type? type = typeof(T);
            string target = Utility.IsNumeric(type) ? value.ToString() : ("'" + value + "'");
            return field.GetQuery() + " = " + target;
        }
    }
}
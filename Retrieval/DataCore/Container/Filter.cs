using System;
using Retrieval.SDK;
using System.Data;
using Retrieval.RetrievalForms.Container;
using DataTable = System.Data.DataTable;
using System.Numerics;

namespace Retrieval.DataCore.Container
{
    public abstract class Filter<T>
    {
        private IField field;
        private T value;

        // public Filter<T>(IField field, T value)
        // {
        //     this.field = field;
        //     this.value = value;
        // }
        
        public virtual IField GetField()
        {
            return field;
        }

        // public string GetQuery()
        // {
        //     if (typeof(T) is typeof(INumber))
        //     return field.GetQuery() + " = " + value;
        // }
    }
}
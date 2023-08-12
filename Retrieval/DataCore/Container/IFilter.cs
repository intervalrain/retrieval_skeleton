using System;
using Retrieval.SDK;
using System.Data;
using Retrieval.RetrievalForms.Container;
using DataTable = System.Data.DataTable;

namespace Retrieval.DataCore.Container
{
    public interface IFilter
    {
        IField GetField();

        string GetQuery();
    }
}
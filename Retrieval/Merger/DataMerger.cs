using System;
using Retrieval.SDK;

namespace Retrieval.Merger
{
    public class DataMerger
    {
        public DataTable MasterTable { get; private set; }

        public DataMerger(DataTable masterTable)
        {
            this.MasterTable = masterTable;
        }
        public DataTable Merge(DataTable table)
        {
            return table;
        }
    }
}
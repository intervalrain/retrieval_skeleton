using System;
using System.ComponentModel;
using Retrieval.RetrievalForms.Controls.Enumerates;
using Retrieval.RetrievalForms.Enumerates;

namespace Retrieval.RetrievalForms.Container
{
    public class MetaInfo
    {
        public bool IsAccomplished { get; private set; }
        public FilterScheme FilterScheme { get; private set; }
        public uint LastNLots { get; private set; }
        public TableFormat TableFormat { get; private set; }
        public JoinType JoinType { get; private set; }
        public LoadLevel LoadLevel { get; private set; }
        public DataCombinationClass DataCombinationClass { get; private set; }
        public List<string> DataCombinations { get; private set; }
        public List<string> Lots { get; private set; }
        public List<string> Wafers { get; private set; }
        public List<string> Parameters { get; private set; }
        public List<string> Statistics { get; private set; }
        public DateType DateType { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public List<DataIndex> DataIndices { get; private set; }
        
        public MetaInfo()
        {
        }
    }
}
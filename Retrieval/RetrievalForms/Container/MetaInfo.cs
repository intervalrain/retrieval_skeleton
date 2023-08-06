using System;
using Retrieval.RetrievalForms.Enumerates;

namespace Retrieval.RetrievalForms.Container
{
    public class MetaInfo
    {
        public TableFormat TableFormat { get; private set; }
        
        public JoinType JoinType { get; private set; }
        
        public MetaInfo()
        {
            
        }
    }
}
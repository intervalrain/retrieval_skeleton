using System;
using Retrieval.SDK;

namespace Retrieval.Tools
{
    public sealed class DataOnDemandRetrievalTool : CustomTool<Document>
    {
        public DataOnDemandRetrievalTool()
            : base("DataOnDemandRetrievalTool") {}

        protected override void ExecuteCore(Document document)
        {
            
        }

        protected override bool IsEnabledCore(Document document)
        {
            return document.Data.Tables != null && document.Data.Tables.Count > 0;
        }
        
        protected override bool IsVisibleCore(Document document)
        {
            return document.Data.Tables != null && document.Data.Tables.Count > 0;
        }
    }
}
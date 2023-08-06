using System;
using Retrieval.SDK;

namespace Retrieval.Tools
{
    public class DataRetrievalTool : CustomTool<AnalysisApplication>
    {
        public DataRetrievalTool()
            : base("DataRetrievalTool")
        {
        }

        protected static void ExecuteTool(AnalysisApplication application)
        {
            
        }

        protected override void ExecuteCore(AnalysisApplication application)
        {
            if (IsEnabledCore(application))
            {
                ExecuteTool(application);
            }
        }

        protected override bool IsEnabledCore(AnalysisApplication application)
        {
            return application != null;
        }
        
        protected override bool IsVisibleCore(AnalysisApplication application)
        {
            return application != null;
        }
    }
}
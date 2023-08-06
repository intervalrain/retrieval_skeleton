using System;

namespace Retrieval.SDK
{
    public class AnalysisApplication
    {
        private string applicationName; 
        internal string ApplicationName => applicationName;
        
        public AnalysisApplication(string applicationName)
        {
            this.applicationName = applicationName;
        }
    }
}
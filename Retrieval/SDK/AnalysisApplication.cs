using System;

namespace Retrieval.SDK
{
    public class AnalysisApplication
    {
        private string applicationName; 
        internal string ApplicationName => applicationName;
        
        public Document Document { get; set; }
        
        public AnalysisApplication(string applicationName)
        {
            this.applicationName = applicationName;
        }
    }
}
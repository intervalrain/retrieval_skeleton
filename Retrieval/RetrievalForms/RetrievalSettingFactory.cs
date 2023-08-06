using System;
using Retrieval.RetrievalForms.Forms;

namespace Retrieval.RetrievalForms
{
    public static class RetrievalSettingFactory
    {
        public static IRetrievalSetting DataRetrievalSetting => GetDataRetrievalSetting();
        
        public static IRetrievalSetting BringInDataRetrievalSetting => GetBringInDataRetrievalSetting();
        
        public static IRetrievalSetting DataOnDemandRetrievalSetting => GetDataOnDemandRetrievalSetting();

        private static DataRetrievalSetting GetDataRetrievalSetting()
        {
            return new DataRetrievalSetting();
        }
        
        private static BringInDataRetrievalSetting GetBringInDataRetrievalSetting()
        {
            return new BringInDataRetrievalSetting();
        }
        
        private static DataOnDemandRetrievalSetting GetDataOnDemandRetrievalSetting()
        {
            return new DataOnDemandRetrievalSetting();
        }
    }
}
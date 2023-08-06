using System;
using Retrieval.RetrievalForms.Forms;
using Retrieval.SDK;

namespace Retrieval.RetrievalForms
{
    public static class RetrievalFactory
    {
        public static IRetrievalForm CreateRetrievalForm(IRetrievalSetting setting, DataTable masterTable)
        {
            switch (setting)
            {
                case DataRetrievalSetting:
                    return new DataRetrievalForm((DataRetrievalSetting)setting);
                case BringInDataRetrievalSetting:
                    return new BringInDataRetrievalForm((BringInDataRetrievalSetting)setting, masterTable);
                case DataOnDemandRetrievalSetting:
                    return new DataOnDemandRetrievalForm((DataOnDemandRetrievalSetting)setting, masterTable);
                default:
                    throw new Exception();
            }
        }
    }
}
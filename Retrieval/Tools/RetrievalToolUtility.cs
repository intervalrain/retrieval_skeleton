using System;
using Retrieval.RetrievalForms;
using Retrieval.RetrievalForms.Container;
using Retrieval.RetrievalForms.Forms;
using Retrieval.SDK;

namespace Retrieval.Tools
{
    public class RetrievalToolUtility
    {
        public static MetaInfo DataRetrieve(IRetrievalSetting setting, DataTable table)
        {
            MetaInfo metaInfo = default;
            try
            {
                using (IRetrievalForm form =
                       RetrievalFactory.CreateRetrievalForm(RetrievalSettingFactory.DataRetrievalSetting, null))
                {
                    if (form.Dialog_OK())
                    {
                        metaInfo = form.CreateMetaInfo();
                    }
                    else
                    {
                        throw new Exception("Fail to retrieve data.");
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return metaInfo;
        }

    }
}
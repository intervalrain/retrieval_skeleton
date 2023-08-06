using System;
using Retrieval.SDK;
using Retrieval.RetrievalForms.Container;

namespace Retrieval.RetrievalForms.Forms
{
    public partial class DataRetrievalForm : IRetrievalForm
    {
        public DataRetrievalForm(DataRetrievalSetting setting)
        {
        }

        public void RetrievalForm_Load(object sender, EventArgs e)
        {
        }

        public bool Dialog_OK()
        {
            return true;
        }
        
        public MetaInfo CreateMetaInfo()
        {
            return new MetaInfo();
        }
        
        public void Dispose()
        {
        }
    }
}
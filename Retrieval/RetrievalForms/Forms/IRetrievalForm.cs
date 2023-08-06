using System;
using Retrieval.SDK;
using Retrieval.RetrievalForms.Container;

namespace Retrieval.RetrievalForms.Forms
{
    public interface IRetrievalForm : Form, IDisposable
    {
        void RetrievalForm_Load(object sender, EventArgs e)
        {
        }

        bool Dialog_OK();

        MetaInfo CreateMetaInfo();
        
    }
}
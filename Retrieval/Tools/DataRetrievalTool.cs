using System;
using Retrieval.RetrievalForms;
using Retrieval.RetrievalForms.Container;
using Retrieval.RetrievalForms.Forms;
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
            MetaInfo metaInfo = default;
            using (IRetrievalForm form = RetrievalFactory.CreateRetrievalForm(RetrievalSettingFactory.DataRetrievalSetting, null))
            {
                if (form.Dialog_OK())
                {
                    metaInfo = form.CreateMetaInfo();
                }
            }
            string sql = DataCore.DataCore.GetQuery(metaInfo);
            Retrieval.SDK.DataTable val = DataLoader.DataLoder.Load(sql, "title");
            DataTransformer.PivotTransformer.Transform(val, metaInfo.TableFormat);
            PropertyManager.PropertyManager.SetProperty(val);
            DataLoader.DataLoder.Visualize(val);
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
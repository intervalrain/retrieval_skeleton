using System.Data;
using Retrieval.SDK;
using Retrieval.RetrievalForms;
using Retrieval.RetrievalForms.Forms;
using Retrieval.Services.Anova;
using Retrieval.RetrievalForms.Container;
using Retrieval.DataCore;
using Retrieval.Merger;

namespace Retrieval
{
    public class Program
    {
        private Document document;

        public Program()
        {
            document = new Document();
        }
        
        public void Sample()
        {
            
            MetaInfo metaInfo = default;
            
            // if there's bring-in or data-on-demand table
            Retrieval.SDK.DataTable masterTable = document.DataTableReference;
            
            // the MetaData derived from Retrieval Form
            using (IRetrievalForm form = RetrievalFactory.CreateRetrievalForm(RetrievalSettingFactory.DataRetrievalSetting, null))
            {
                if (form.Dialog_OK())
                {
                    metaInfo = form.CreateMetaInfo();
                }
            }
            
            // derive sql from Data Core Service
            string sql = DataCore.DataCore.GetQuery(metaInfo);
            
            // derive spotfire's table by Data Loader
            Retrieval.SDK.DataTable val = DataLoader.DataLoder.Load(sql, "title");
            
            // to process necessary transformation(wide, tall, flow)
            DataTransformer.PivotTransformer.Transform(val, metaInfo.TableFormat);
            
            // to merge two tables
            DataMerger merger = new DataMerger(masterTable);
            Retrieval.SDK.DataTable val2 = merger.Merge(val);
            
            // to set up properties for further functions
            PropertyManager.PropertyManager.SetProperty(val);
            
            // visualize spotfire's table as TablePlot
            DataLoader.DataLoder.Visualize(val);
        }
        
        public void DataRetrieval_Execute()
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

        public void BringInDataRetrieval_Execute()
        {
            MetaInfo metaInfo = default;
            Retrieval.SDK.DataTable masterTable = document.DataTableReference;
            using (IRetrievalForm form = RetrievalFactory.CreateRetrievalForm(RetrievalSettingFactory.BringInDataRetrievalSetting, masterTable))
            {
                if (form.Dialog_OK())
                {
                    metaInfo = form.CreateMetaInfo();
                }
            }
            string sql = DataCore.DataCore.GetQuery(metaInfo);
            Retrieval.SDK.DataTable val = DataLoader.DataLoder.Load(sql, "title");
            DataMerger merger = new DataMerger(masterTable);
            Retrieval.SDK.DataTable val2 = merger.Merge(val);
            PropertyManager.PropertyManager.SetProperty(val);
            DataLoader.DataLoder.Visualize(val);
        }

        public void DataOnDemandRetrieval_Execute()
        {
            MetaInfo metaInfo = default;
            Retrieval.SDK.DataTable masterTable = document.DataTableReference;
            using (IRetrievalForm form = RetrievalFactory.CreateRetrievalForm(RetrievalSettingFactory.DataOnDemandRetrievalSetting, masterTable))
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

        public void Phase3FunctionExample_Execute()
        {
            MetaInfo metaInfo = default;
            Retrieval.SDK.DataTable masterTable = document.DataTableReference;
            using (IRetrievalForm form = RetrievalFactory.CreateRetrievalForm(new AnovaRetrievalSetting(), masterTable))
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
    }
}
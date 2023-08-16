using System;
using NUnit;
using NUnit.Framework;
using Retrieval.RetrievalForms;
using Retrieval.RetrievalForms.Container;
using Retrieval.RetrievalForms.Enumerates;
using Retrieval.SDK;
using Retrieval.Tools;

namespace Retrieval
{
    [TestFixture]
    public class RetrievalTest
    {
        [Test]
        public void Acceptance_Test_DataRetrieval()
        {
            // Assure metaInfo has output after opening the retrieval form.
            AnalysisApplication app = new AnalysisApplication("application");
            MetaInfo metaInfo = RetrievalToolUtility.DataRetrieve(RetrievalSettingFactory.DataRetrievalSetting, null);

            Assert.IsTrue(metaInfo.IsAccomplished);
            
            if (metaInfo.FilterScheme == FilterScheme.ByDates)
            {
                Assert.IsNotNull(metaInfo.StartTime);
                Assert.IsNotNull(metaInfo.EndTime);
            }
            else if (metaInfo.FilterScheme == FilterScheme.ByLotsAndDates)
            {
                Assert.Greater(metaInfo.Lots.Count, 1);
                Assert.IsNotNull(metaInfo.StartTime);
                Assert.IsNotNull(metaInfo.EndTime);
                if (metaInfo.LoadLevel != LoadLevel.Lot && metaInfo.LoadLevel != LoadLevel.SourceLot)
                {
                    Assert.Greater(metaInfo.Wafers.Count, 1);
                }
            }
            else if (metaInfo.FilterScheme == FilterScheme.ByLots)
            {
                Assert.Greater(metaInfo.Lots.Count, 1);
                if (metaInfo.LoadLevel != LoadLevel.Lot && metaInfo.LoadLevel != LoadLevel.SourceLot)
                {
                    Assert.Greater(metaInfo.Wafers.Count, 1);
                }
            }
            else if (metaInfo.FilterScheme == FilterScheme.ByLastNLots)
            {
                Assert.Greater(metaInfo.LastNLots, 1);
            }
            
            Assert.Greater(metaInfo.DataCombinations.Count, 1);
            Assert.Greater(metaInfo.Parameters.Count, 1);
            Assert.Greater(metaInfo.Statistics.Count, 1);
            Assert.Greater(metaInfo.DataIndices.Count, 1);
            
            
            // Assure MetaInfo could be translated to sql
            string sql = DataCore.DataCore.GetQuery(metaInfo);
            Assert.IsNotEmpty(sql);
            
            // Assure the connection is ok and the sql is valid
            DataTable val = DataLoader.DataLoder.Load(sql, "Acceptance Test");
            Assert.NotNull(val);
            Assert.Greater(val.Rows.Count, 0);
            
            // Assert Pivot transformation is performed, and table is still valid
            DataTransformer.PivotTransformer.Transform(val, metaInfo.TableFormat);
            Assert.NotNull(val);
            Assert.Greater(val.Rows.Count, 0);

            // Assert properties are inserted
            PropertyManager.PropertyManager.SetProperty(val);
            
            // Assert TablePlot is created
            DataLoader.DataLoder.Visualize(val);
        }
        
        
  
        // string sql = DataCore.DataCore.GetQuery(metaInfo);
        // Retrieval.SDK.DataTable val = DataLoader.DataLoder.Load(sql, "title");
        // DataTransformer.PivotTransformer.Transform(val, metaInfo.TableFormat);
        // PropertyManager.PropertyManager.SetProperty(val);
        // DataLoader.DataLoder.Visualize(val);
    }
    
}
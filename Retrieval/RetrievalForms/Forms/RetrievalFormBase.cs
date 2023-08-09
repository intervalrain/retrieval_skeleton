using System;
using System.Runtime.InteropServices;
using Retrieval.SDK;
using Retrieval.RetrievalForms.Container;
using Retrieval.RetrievalForms.Preferences;

namespace Retrieval.RetrievalForms.Forms
{
    public abstract class RetrievalFormBase : IRetrievalForm
    {
        private IRetrievalSetting _retrievalSetting;
        public RetrievalFormBase(IRetrievalSetting setting)
        {
            _retrievalSetting = setting;
        }
        
        public void RetrievalForm_Load(object sender, EventArgs e)
        {
            Dictionary<string, object> DatabaseConnectionInfo = GetPreference(GlobalRetrievalPreferences.DatabaseConnectionPreference);
            Dictionary<string, object> DataCoreInfo = GetPreference(GlobalRetrievalPreferences.DataCoreServicePreference);
            Dictionary<string, object> DataQueryInfo = GetPreference(GlobalRetrievalPreferences.DataQueryServicePreference);
            Dictionary<string, object> TracingInfo = GetPreference(LocalRetrievalPreferences.TracingRetrievalPreference);
            Dictionary<string, object> LoginInfo = GetPreference(LocalRetrievalPreferences.UserLoginPreference);

            IDBConnect connection = AutoConnect(DatabaseConnectionInfo);
        }

        private Dictionary<string, object> GetRetrievalSetting(IRetrievalSetting setting)
        {
            return new Dictionary<string, object>();
        }
        
        private Dictionary<string, object> GetPreference(CustomPreference preference)
        {
            return new Dictionary<string, object>();
        }

        private static IDBConnect AutoConnect(Dictionary<string, object> databaseConnectionInfo)
        {
            throw new NotImplementedException();
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
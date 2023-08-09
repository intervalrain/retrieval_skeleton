using System;
using Retrieval.RetrievalForms.Forms;

namespace Retrieval.RetrievalForms
{
    public static class RetrievalSettingFactory
    {
        private static DataRetrievalSetting _dataRetrievalSetting = null;
        private static BringInDataRetrievalSetting _bringInDataRetrievalSetting = null;
        private static DataOnDemandRetrievalSetting _dataOnDemandRetrievalSetting = null;
        private static readonly object lock1 = new object();
        private static readonly object lock2 = new object();
        private static readonly object lock3 = new object();
        public static IRetrievalSetting DataRetrievalSetting
        {
            get
            {
                if (_dataRetrievalSetting == null)
                {
                    lock (lock1)
                    {
                        if (_dataRetrievalSetting == null)
                        {
                            _dataRetrievalSetting = new DataRetrievalSetting();
                        }
                    }
                }
                return _dataRetrievalSetting;
            }
        }
        public static IRetrievalSetting BringInDataRetrievalSetting
        {
            get
            {
                if (_bringInDataRetrievalSetting == null)
                {
                    lock (lock2)
                    {
                        if (_bringInDataRetrievalSetting == null)
                        {
                            _bringInDataRetrievalSetting = new BringInDataRetrievalSetting();
                        }
                    }
                }
                return _bringInDataRetrievalSetting;
            }
        }
        public static IRetrievalSetting DataOnDemandRetrievalSetting
        {
            get
            {
                if (_dataOnDemandRetrievalSetting == null)
                {
                    lock (lock3)
                    {
                        if (_dataOnDemandRetrievalSetting == null)
                        {
                            _dataOnDemandRetrievalSetting = new DataOnDemandRetrievalSetting();
                        }
                    }
                }
                return _dataOnDemandRetrievalSetting;
            }
        }
    }
}
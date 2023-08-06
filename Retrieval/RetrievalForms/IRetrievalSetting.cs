using System;
using Retrieval.RetrievalForms.Enumerates;

namespace Retrieval.RetrievalForms
{
    public interface IRetrievalSetting
    {
        public List<DataCombinationClass> GetDataCombinationClass();

        public List<LoadLevel> GetLoadLevels();

        public List<DataTypeOption> GetDataTypeOptions();

    }
}
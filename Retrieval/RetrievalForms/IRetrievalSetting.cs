using System;
using System.Data;
using Retrieval.RetrievalForms.Controls.Enumerates;
using Retrieval.RetrievalForms.Enumerates;

namespace Retrieval.RetrievalForms
{
    public interface IRetrievalSetting
    {
        // Data Combination Class
        public List<DataCombinationClass> GetDataCombinationClassOptions();
        public DataCombinationClass GetDataCombinationClassSelection();
        public bool IsDataCombinationClassEnabled();

        // Table Format
        public List<TableFormat> GetTableFormatOptions();
        public TableFormat GetTableFormatSelection();
        public bool IsTableFormatEnabled();
        
        // Grouped Parameter
        // Parameter Type
        public List<ParameterType> GetParameterTypeOptions();
        public List<ParameterType> GetParameterTypeSelection();
        public bool IsParameterTypeEnabled();
        
        // Data Type (ComboBox)
        public List<DataTypeOption> GetDataType1ComboBoxOptions();
        public List<DataTypeOption> GetDataType2ComboBoxOptions();
        public DataTypeOption GetDataType1ComboBoxSelection();
        public DataTypeOption GetDataType2ComboBoxSelection();
        public bool IsDataType1ComboBoxEnabled();
        public bool IsDataType2ComboBoxEnabled();
        
        // Data Type (ListBox)
        public List<string> GetDataType1Options();
        public List<string> GetDataType2Options();
        public List<string> GetDataType1Selections();
        public List<string> GetDataType2Selections();
        public bool IsDataType1Enabled();
        public bool IsDataType2Enabled();
        
        // Load Level
        public List<LoadLevel> GetLoadLevelOptions();
        public LoadLevel GetLoadLevelSelection();
        public bool IsLoadLevelEnabled();
        
        // Date
        public List<DateType> GetDateTypeOptions();
        public DateType GetDateTypeSelection();
        public bool IsRelativeDate();
        public bool IsDateTypeEnabled();
        
        // Data Combination
        public List<string> GetDataCombinationOptions();
        public List<string> GetDataCombinationSelections();
        public bool IsDataCombinationEnabled();
        
        // Lot
        public List<string> GetLotOptions();
        public List<string> GetLotSelections();
        public bool IsLotEnabled();
        
        // Wafer
        public List<string> GetWaferOptions();
        public List<string> GetWaferSelections();
        public bool IsWaferEnabled();
        
        // Parameter
        public DataTable GetParameterOptions();
        public List<string> GetParameterSelections();
        public bool IsParameterEnabled();
        
        // Statistics
        public List<string> GetStatisticOptions();
        public List<string> GetStatisticSelections();
        public bool IsStatisticEnabled();
        
        // DataIndex
        public List<DataIndex> GetDataIndexOptions();
        public List<DataIndex> GetDataIndexSelections();
        public List<DataIndex> EnabledDataIndices();
        
        // Stack or Compressed
        public StackMode GetStackMode();
        public bool IsStackModeEnabled();
        
        // MergeType
        public List<MergeType> GetMergeTypeOptions();
        public MergeType GetMergeTypeSelection();
        public bool IsMergeTypeEnabled();
        
        // Auto Format
        public bool GetAutoFormatSelection();
        public bool IsAutoFormatEnabled();

    }
}
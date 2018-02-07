using System.Collections.Generic;
using System.Data;
using EWAV.Web.EpiDashboard;
using EWAV.DTO;

namespace EWAV.BAL
{
    public class FrequencyManager
    {
        public static Dictionary<List<EWAVFrequencyControlDto>, List<DescriptiveStatistics>>
        ConvertDatatableToList(Dictionary<DataTable, List<DescriptiveStatistics>> dataTableDictionary, 
            GadgetParameters gadgetParameters)

        {
            Dictionary<List<EWAVFrequencyControlDto>, List<DescriptiveStatistics>> DtoDictionary =
                new Dictionary<List<EWAVFrequencyControlDto>, List<DescriptiveStatistics>>();

            EWAVGadgetParameters g = new EWAVGadgetParameters()
            {
                CrosstabVariableName = gadgetParameters.CrosstabVariableName,
                CustomFilter = gadgetParameters.CustomFilter,
                CustomSortColumnName = gadgetParameters.CustomSortColumnName,
                InputVariableList = gadgetParameters.InputVariableList,
                MainVariableName = gadgetParameters.MainVariableName,
                MainVariableNames = gadgetParameters.MainVariableNames,
                ShouldIncludeFullSummaryStatistics = gadgetParameters.ShouldIncludeFullSummaryStatistics,
                ShouldIncludeMissing = gadgetParameters.ShouldIncludeMissing,
                ShouldShowCommentLegalLabels = gadgetParameters.ShouldSortHighToLow,
                ShouldUseAllPossibleValues = gadgetParameters.ShouldUseAllPossibleValues,
                StrataVariableNames = gadgetParameters.StrataVariableNames,
                WeightVariableName = gadgetParameters.WeightVariableName,
                NameOfDtoList = gadgetParameters.MainVariableName
            };
            
            foreach (KeyValuePair<DataTable, List<DescriptiveStatistics>> khp in dataTableDictionary)
            {
                DataTable dt = khp.Key;    
                List<EWAVFrequencyControlDto> ewavFrequencyControlDto = Mapper.FrequencyOutputList(dt, g);
                DtoDictionary.Add(ewavFrequencyControlDto, khp.Value);
            }

            return DtoDictionary;
        }

        public static Dictionary<List<EWAVFrequencyControlDto>, List<DescriptiveStatistics>>
            ConvertPivotDatatableToList(Dictionary<DataTable, List<DescriptiveStatistics>> dataTableDictionary,
                GadgetParameters gadgetParameters)    

        {
            Dictionary<List<EWAVFrequencyControlDto>, List<DescriptiveStatistics>> DtoDictionary =
                new Dictionary<List<EWAVFrequencyControlDto>, List<DescriptiveStatistics>>();

            EWAVGadgetParameters g = new EWAVGadgetParameters()
            {
                CrosstabVariableName = gadgetParameters.CrosstabVariableName,
                CustomFilter = gadgetParameters.CustomFilter,
                CustomSortColumnName = gadgetParameters.CustomSortColumnName,
                InputVariableList = gadgetParameters.InputVariableList,
                MainVariableName = gadgetParameters.MainVariableName,
                MainVariableNames = gadgetParameters.MainVariableNames,
                ShouldIncludeFullSummaryStatistics = gadgetParameters.ShouldIncludeFullSummaryStatistics,
                ShouldIncludeMissing = gadgetParameters.ShouldIncludeMissing,
                ShouldShowCommentLegalLabels = gadgetParameters.ShouldSortHighToLow,
                ShouldUseAllPossibleValues = gadgetParameters.ShouldUseAllPossibleValues,
                StrataVariableNames = gadgetParameters.StrataVariableNames,
                WeightVariableName = gadgetParameters.WeightVariableName,
                NameOfDtoList = gadgetParameters.MainVariableName
            };

            foreach (KeyValuePair<DataTable, List<DescriptiveStatistics>> khp in dataTableDictionary)
            {
                DataTable dt = EWAV.Web.Utilities.Pivot(khp.Key, "Frequency", "MainVarname", "totals");
                List<EWAVFrequencyControlDto> ewavFrequencyControlDto = Mapper.FrequencyOutputList(dt, g);
                DtoDictionary.Add(ewavFrequencyControlDto, khp.Value);
            }

            return DtoDictionary;
        }
    }
}
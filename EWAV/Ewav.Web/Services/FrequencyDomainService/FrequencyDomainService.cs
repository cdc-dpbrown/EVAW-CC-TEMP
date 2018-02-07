namespace EWAV.Web.Services
{
    using System.Collections.Generic;
    using System.Data;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using EpiDashboard;
    using EWAV.BAL;
    using EWAV.DTO;

    /// <summary>
    /// Frequency Domain Service functions  
    /// </summary>
    [EnableClientAccess()]
    public class FrequencyDomainService : DomainService
    {
        #region  "These are here to force the proxy classes to be created.  "
        //public void PortClassToClient(ColumnDataType d)
        //{
        //}
        public void PortClassToClient777(DescriptiveStatistics ds)
        {
        }

        public void PortClassToClient49491(EWAVRule_Base gs)
        {


        }


        public void PortClassToClient494914(EWAVRule_ExpressionAssign xx)
        {


        }


        public void PortClassToClient494941(Class1 xx)
        {


        }


        public void PortClassToClient494911(EWAVRule_Recode gs)
        {


        }





























        public void PortClassToClient49491111(EWAVRule_SimpleAssignment gs)
        {


        }


        public void PortClassToClient4(GadgetParameters gp)
        {
        }

        public void PortClassToClient7(EWAVFrequencyControlDto gp)
        {
        }

        public void PortClassToClient77(EWAVColumn gp)
        {
        }

        //public void PortClassToClient(EWAVColumnsMetaData wcmd) { }
        public void PortClassToClient79(EWAVConnectionString aa)
        {

        }
        #endregion

        [Query(IsComposable = false)]
        public EWAVRule_Base Getrule(int id)
        {
            return new EWAVRule_Base();

        }

      /// <summary>
        /// DashboardHelper    
        /// </summary>
        private DashboardHelper dh;


        /// <summary>
        /// Get a list of columns    
        /// </summary>
        /// <param name="DataSourceName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public List<EWAVColumn> GetColumns(string DataSourceName, string TableName)
        {
            return BAL.Common.GetColumns(DataSourceName, TableName);
        }

        public List<int> GenerateTestResults(int intValue)
        {
            List<int> collectionOfInt = new List<int>();

            for (int i = 0; i < 1000; i++)
            {
                collectionOfInt.Add(intValue + i);
            }

            return collectionOfInt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gadgetParameters"></param>
        /// <param name="DatasourceName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>

        [Invoke]
        public List<FrequencyResultData> GenerateFrequencyTable(GadgetParameters gadgetParameters,
               IEnumerable<EWAVDataFilterCondition> ewavDataFilters, List<EWAVRule_Base> rules, string filterString = "")
        {
            if (gadgetParameters.UseAdvancedDataFilter)
            {
                dh = new DashboardHelper(gadgetParameters, filterString, rules);
                gadgetParameters.UseAdvancedDataFilter = true;
                gadgetParameters.AdvancedDataFilterText = filterString;
            }
            else
            {
                dh = new DashboardHelper(gadgetParameters, ewavDataFilters, rules);
            }

            Dictionary<DataTable, List<DescriptiveStatistics>> dataTableDictionary;
            dataTableDictionary = dh.GenerateFrequencyTable(gadgetParameters, gadgetParameters.DatasourceName, gadgetParameters.TableName);

            Dictionary<List<EWAVFrequencyControlDto>, List<DescriptiveStatistics>> dtoDictionary;
            dtoDictionary = FrequencyManager.ConvertDatatableToList(dataTableDictionary, gadgetParameters);

            List<FrequencyResultData> outputList = new List<FrequencyResultData>();

            foreach (KeyValuePair<List<EWAVFrequencyControlDto>, List<DescriptiveStatistics>> khp in dtoDictionary)
            {
                List<EWAVFrequencyControlDto> outFreqList = new List<EWAVFrequencyControlDto>();
                List<DescriptiveStatistics> outDscStat = new List<DescriptiveStatistics>();

                foreach (EWAVFrequencyControlDto freqDto in khp.Key)
                {
                    outFreqList.Add(freqDto);
                }
                foreach (DescriptiveStatistics descStat in khp.Value)
                {
                    outDscStat.Add(descStat);
                }

                var frequencyResultData = new FrequencyResultData()
                {
                    FrequencyControlDtoList = outFreqList,
                    DescriptiveStatisticsList = outDscStat
                };
                outputList.Add(frequencyResultData);
            }

            return outputList;
        }
    }















































































}
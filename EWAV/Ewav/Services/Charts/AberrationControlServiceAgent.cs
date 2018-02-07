using System;
using System.Collections.Generic;
using EWAV.Web.Services;
using System.ServiceModel.DomainServices.Client;
using EWAV.Web.EpiDashboard;
using EWAV.BAL;
using EWAV.Web.Services;

namespace EWAV.Services
{
    public class AberrationControlServiceAgent : IAberrationControlServiceAgent
    {
        #region Variables
        AberrationDomainContext freqCtx;
        private Action<List<EWAVColumn>, Exception> _completed;
        private Action<List<FrequencyResultData>, Exception> _freqCompleted;
        #endregion

        #region Constructor
        public AberrationControlServiceAgent()
        {
        }
        #endregion

        #region Helper Method

        public string CheckColumnType(string p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// GetColumns Method that calls the method in Domain Service
        /// </summary>
        /// <param name="DataSourceName"></param>
        /// <param name="TableName"></param>
        /// <param name="completed"></param>
        //public void GetColumns(string DataSourceName, string TableName, Action<List<EWAVColumn>, Exception> completed)
        //{
        //    _completed = completed;
        //    AberrationDomainContext abrCtx = new AberrationDomainContext();
        //    InvokeOperation<List<EWAVColumn>> freqColumnResults = abrCtx.GetColumns(DataSourceName, TableName);
        //    freqColumnResults.Completed += new EventHandler(freqColumnResults_Completed);
        //}

        /// <summary>
        /// GetFrequencyResults method that calls Domain Service Method.
        /// </summary>
        /// <param name="DataSourceName"></param>
        /// <param name="TableName"></param>
        /// <param name="gadgetParameters"></param>
        /// <param name="completed"></param>
        void IAberrationControlServiceAgent.GetFrequencyResults(GadgetParameters gadgetParameters, Action<List<FrequencyResultData>, Exception> completed)
        {
            _freqCompleted = completed;
            freqCtx = new AberrationDomainContext();
            InvokeOperation<List<FrequencyResultData>> freqResults =
                freqCtx.GenerateFrequencyTable(gadgetParameters, EWAV.ViewModels.ApplicationViewModel.Instance.EWAVDatafilters,
                EWAV.ViewModels.ApplicationViewModel.Instance.EWAVDefinedVariables,
            EWAV.ViewModels.ApplicationViewModel.Instance.AdvancedDataFilterString);

            Dictionary<List<DTO.EWAVFrequencyControlDto>, List<DescriptiveStatistics>> freqTableResults = new Dictionary<List<DTO.EWAVFrequencyControlDto>, List<DescriptiveStatistics>>();
            freqResults.Completed += new EventHandler(freqTableResults_Completed);
        }
        #endregion

        #region Completion Callbacks

        void freqTableResults_Completed(object sender, EventArgs e)
        {
            InvokeOperation<List<FrequencyResultData>> result =
                (InvokeOperation<List<FrequencyResultData>>)sender;

           Exception ex = null;
            if (result.HasError)
            {
                result.MarkErrorAsHandled();
                //throw new GadgetException(result.Error.Message);
                ex = result.Error;
            }
            //else
            //{
                List<FrequencyResultData> returnedData = ((InvokeOperation<List<FrequencyResultData>>)sender).Value;
                _freqCompleted(returnedData, ex);
            //}
        }
        #endregion

    }
}
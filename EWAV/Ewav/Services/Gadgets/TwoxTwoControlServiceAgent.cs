using System;
using System.Collections.Generic;
using System.ServiceModel.DomainServices.Client;
using EWAV.Web.EpiDashboard;
using EWAV.BAL;
using EWAV.Web.Services;
using EWAV.ViewModels;

namespace EWAV.Services
{
    public class TwoxTwoControlServiceAgent : ITwoxTwoControlServiceAgent
    {
        private Action<List<EWAVColumn>, Exception> _completed;
        private Action<List<FrequencyResultData>, Exception> _frequencyResultsCompleted;
        private Action<TwoxTwoAndMxNResultsSet, Exception> _setupCompleted;
        Exception ex = null;
        public void GetFrequencyResults(string DataSourceName, string TableName,
            EWAV.Web.EpiDashboard.GadgetParameters gadgetParameters,
            IEnumerable<EWAVDataFilterCondition> ewavDataFilters,
            Action<List<FrequencyResultData>, Exception> completed)
        {
            _frequencyResultsCompleted = completed;
            FrequencyDomainContext freqCtx = new FrequencyDomainContext();
            InvokeOperation<List<FrequencyResultData>> freqDataResults = freqCtx.GenerateFrequencyTable(gadgetParameters, ewavDataFilters,
                ApplicationViewModel.Instance.EWAVDefinedVariables,             
                ApplicationViewModel.Instance.AdvancedDataFilterString);   ////  DataSourceName, TableName);

            freqDataResults.Completed += new EventHandler(freqDataResults_Completed);
        }

        void freqDataResults_Completed(object sender, EventArgs e)
        {
            InvokeOperation<List<FrequencyResultData>> result = (InvokeOperation<List<FrequencyResultData>>)sender;
            if (result.HasError)
            {
                ex = result.Error;
                result.MarkErrorAsHandled();
            }

            List<FrequencyResultData> returnedData = ((InvokeOperation<List<FrequencyResultData>>)sender).Value;
            _frequencyResultsCompleted(returnedData, null);
        }

        public string CheckColumnType(string p)
        {
            throw new NotImplementedException();
        }

        public void GetColumns(string DataSourceName, string TableName, Action<List<BAL.EWAVColumn>, Exception> completed)
        {
            _completed = completed;
            FrequencyDomainContext freqCtx = new FrequencyDomainContext();
            InvokeOperation<List<EWAVColumn>> freqColumnResults = freqCtx.GetColumns(DataSourceName, TableName);
            freqColumnResults.Completed += new EventHandler(freqColumnResults_Completed);
        }

        public void GetCrossTabResults(string DataSourceName, string TableName, EWAV.Web.EpiDashboard.GadgetParameters gadgetParameters, Action<System.Collections.Generic.List<Web.Services.CrossTabResponseObjectDto>, Exception> completed)
        {
        }

        void freqColumnResults_Completed(object sender, EventArgs e)
        {
            InvokeOperation<List<EWAVColumn>> result = (InvokeOperation<List<EWAVColumn>>)sender;
            if (result.HasError)
            {
                ex = result.Error;
                result.MarkErrorAsHandled();
            }
            //else
            //{
                List<EWAVColumn> returnedData = ((InvokeOperation<List<EWAVColumn>>)sender).Value;
                _completed(returnedData, null);
            //}
        }

        public void SetupGadget(GadgetParameters gadgetParameters, Action<TwoxTwoAndMxNResultsSet, Exception> completed)
        {
            _setupCompleted = completed;
            TwoByTwoDomainContext twoxTwoCtx = new TwoByTwoDomainContext();
            InvokeOperation<TwoxTwoAndMxNResultsSet> resultSet = twoxTwoCtx.SetupGadget(gadgetParameters,
                ViewModels.ApplicationViewModel.Instance.EWAVDatafilters,
                ViewModels.ApplicationViewModel.Instance.EWAVDefinedVariables);

            resultSet.Completed += new EventHandler(resultSet_Completed);
            //  AAAA   
        }

        void resultSet_Completed(object sender, EventArgs e)
        {
            InvokeOperation<TwoxTwoAndMxNResultsSet> result = (InvokeOperation<TwoxTwoAndMxNResultsSet>)sender;
            if (result.HasError)
            {
                ex = result.Error;
                result.MarkErrorAsHandled();
            }
            //else
            //{
                TwoxTwoAndMxNResultsSet returnedData = ((InvokeOperation<TwoxTwoAndMxNResultsSet>)sender).Value;
                _setupCompleted(returnedData, null);
            //}
        }
    }
}
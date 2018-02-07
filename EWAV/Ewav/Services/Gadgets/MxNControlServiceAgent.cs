using System;
using System.Collections.Generic;
using EWAV.Web.Services;
using System.ServiceModel.DomainServices.Client;
using EWAV.Web.EpiDashboard;
using EWAV.BAL;
using EWAV.ViewModels;


namespace EWAV.Services
{
    public class MxNControlServiceAgent
    {

        FrequencyDomainContext freqCtx;
        MxNDomainContext mxntx;


        private Action<List<EWAVColumn>, Exception> _completed;
        private Action<List<FrequencyResultData>, Exception> _frequencyResultsCompleted;
        private Action<TwoxTwoAndMxNResultsSet, Exception> _setupCompleted;
        Exception ex = null;

        public void GetFrequencyResults(
            EWAV.Web.EpiDashboard.GadgetParameters gadgetParameters,
                 List<EWAVDataFilterCondition> ewavDataFilters,
            Action<List<FrequencyResultData>, Exception> completed)
        {
            _frequencyResultsCompleted = completed;
            FrequencyDomainContext freqCtx = new FrequencyDomainContext();
            InvokeOperation<List<FrequencyResultData>> freqDataResults = freqCtx.GenerateFrequencyTable(gadgetParameters, ewavDataFilters, ApplicationViewModel.Instance.EWAVDefinedVariables,   ApplicationViewModel.Instance.AdvancedDataFilterString);//  , DataSourceName, TableName);
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
            //else
            //{
                List<FrequencyResultData> returnedData = ((InvokeOperation<List<FrequencyResultData>>)sender).Value;
                _frequencyResultsCompleted(returnedData, null);
            //}
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
            MxNDomainContext mxntx = new MxNDomainContext();
            InvokeOperation<TwoxTwoAndMxNResultsSet> resultSet = mxntx.SetupGadget(gadgetParameters,
                     ViewModels.ApplicationViewModel.Instance.EWAVDatafilters, ViewModels.ApplicationViewModel.Instance.EWAVDefinedVariables);    


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
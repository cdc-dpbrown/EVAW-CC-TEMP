using System;
using System.Collections.Generic;
using EWAV.Web.Services;
using System.ServiceModel.DomainServices.Client;
using EWAV.Web.EpiDashboard;
using EWAV.BAL;
using EWAV.ViewModels;

namespace EWAV.Services
{
    public class MeansControlServiceAgent : IMeansControlServiceAgent
    {
        MeansDomainContext meansCtx;
        private Action<List<EWAVColumn>, Exception> _completed;
        private Action<List<FrequencyResultData>, Exception> _freqCompleted;
        private Action<List<CrossTabResponseObjectDto>, Exception> _meansCompleted;
        private Action<FrequencyAndCrossTable, Exception> _crossandfreqCompleted;

        public void GetCrossTableAndFreq(GadgetParameters gadgetParameters, Action<FrequencyAndCrossTable, Exception> completed)
        {
            _crossandfreqCompleted = completed;
            meansCtx = new MeansDomainContext();
            InvokeOperation<FrequencyAndCrossTable> crossFreqResults =
                meansCtx.GenerateCrossTableWithFrequencyTable(gadgetParameters,
                ApplicationViewModel.Instance.EWAVDatafilters,
                  ApplicationViewModel.Instance.EWAVDefinedVariables,
                ApplicationViewModel.Instance.AdvancedDataFilterString);

            crossFreqResults.Completed += new EventHandler(crossFreqResults_Completed);
        }

        void crossFreqResults_Completed(object sender, EventArgs e)
        {
            InvokeOperation<FrequencyAndCrossTable> result =
                (InvokeOperation<FrequencyAndCrossTable>)sender;
            Exception ex = null;
            if (result.HasError)
            {
                result.MarkErrorAsHandled();
                ex = result.Error;
            }
            //else
            //{
                FrequencyAndCrossTable returnedData = ((InvokeOperation<FrequencyAndCrossTable>)sender).Value;
                _crossandfreqCompleted(returnedData, ex);
            //}
        }

        public void GetCrossTabResults(GadgetParameters gadgetParameters, Action<List<CrossTabResponseObjectDto>, Exception> completed)
        {
            _meansCompleted = completed;
            meansCtx = new MeansDomainContext();
            InvokeOperation<List<CrossTabResponseObjectDto>> meanResults = meansCtx.GenerateCrossTabFrequency(gadgetParameters);
            meanResults.Completed += new EventHandler(meanResults_Completed);
        }

        void meanResults_Completed(object sender, EventArgs e)
        {
            InvokeOperation<List<CrossTabResponseObjectDto>> result =
                (InvokeOperation<List<CrossTabResponseObjectDto>>)sender;
            Exception ex = null;
            if (result.HasError)
            {
                result.MarkErrorAsHandled();
                ex = result.Error;
            }
            //else
            //{
                List<CrossTabResponseObjectDto> returnedData = ((InvokeOperation<List<CrossTabResponseObjectDto>>)sender).Value;
                _meansCompleted(returnedData, ex);
            //}
        }

        public void GetFrequencyResults(GadgetParameters gadgetParameters, Action<List<FrequencyResultData>, Exception> completed)
        {
            _freqCompleted = completed;
            meansCtx = new MeansDomainContext();
            InvokeOperation<List<FrequencyResultData>> meanResults =
                meansCtx.GenerateFrequencyTable(gadgetParameters,
                ApplicationViewModel.Instance.EWAVDatafilters,
                ApplicationViewModel.Instance.EWAVDefinedVariables,
                ApplicationViewModel.Instance.AdvancedDataFilterString); 


            Dictionary<List<DTO.EWAVFrequencyControlDto>, List<DescriptiveStatistics>> freqTableResults = new Dictionary<List<DTO.EWAVFrequencyControlDto>, List<DescriptiveStatistics>>();
            meanResults.Completed += new EventHandler(freqTableResults_Completed);
        }

        void freqTableResults_Completed(object sender, EventArgs e)
        {
            InvokeOperation<List<FrequencyResultData>> result =
                (InvokeOperation<List<FrequencyResultData>>)sender;

           Exception ex = null;
            if (result.HasError)
            {
                result.MarkErrorAsHandled();
                ex = result.Error;
            }
            //else
            //{
                List<FrequencyResultData> returnedData = ((InvokeOperation<List<FrequencyResultData>>)sender).Value;
                _freqCompleted(returnedData, ex);
            //}
        }
    }
}
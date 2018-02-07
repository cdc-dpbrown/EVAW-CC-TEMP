using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using EWAV.Web.EpiDashboard;
using EWAV.Web.Services;
using EWAV.BAL;
using System.ServiceModel.DomainServices.Client;
using EWAV.ViewModels;

namespace EWAV.Services
{
    public class XYChartServiceAgent : IXYChartServiceAgent
    {
        #region Variables
        XYChartDomainContext freqCtx;
        private Action<List<EWAVColumn>, Exception> _completed;
        private Action<List<FrequencyResultData>, Exception> _freqCompleted;
        #endregion

        #region Constructor
        public XYChartServiceAgent()
        {
        }
        #endregion

        /// <summary>
        /// Gets the frequency results.
        /// </summary>
        /// <param name="gadgetParameters">The gadget parameters.</param>
        /// <param name="completed">The completed.</param>
        void IXYChartServiceAgent.GetFrequencyResults(GadgetParameters gadgetParameters, Action<List<FrequencyResultData>, Exception> completed)
        {
            _freqCompleted = completed;











            freqCtx = new XYChartDomainContext();
            InvokeOperation<List<FrequencyResultData>> freqResults = freqCtx.GenerateFrequencyTable(gadgetParameters, ApplicationViewModel.Instance.EWAVDatafilters,    
                ApplicationViewModel.Instance.EWAVDefinedVariables,            
                 ApplicationViewModel.Instance.AdvancedDataFilterString);

            Dictionary<List<DTO.EWAVFrequencyControlDto>, List<DescriptiveStatistics>> freqTableResults = new Dictionary<List<DTO.EWAVFrequencyControlDto>, List<DescriptiveStatistics>>();
            freqResults.Completed += new EventHandler(freqTableResults_Completed);
        }



        void freqTableResults_Completed(object sender, EventArgs e)
        {
            InvokeOperation<List<FrequencyResultData>> result =
                (InvokeOperation<List<FrequencyResultData>>)sender;
            Exception ex = null;
            if (result.HasError)
            {
                ex = result.Error;
                result.MarkErrorAsHandled();
            }
            //else
            //{
                List<FrequencyResultData> returnedData = ((InvokeOperation<List<FrequencyResultData>>)sender).Value;
                _freqCompleted(returnedData, null);
            //}
        }
    }
}
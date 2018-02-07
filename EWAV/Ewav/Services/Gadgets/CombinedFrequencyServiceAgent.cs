using System;
using System.Collections.Generic;
using EWAV.Web.Services;
using System.ServiceModel.DomainServices.Client;
using EWAV.Web.EpiDashboard;
using EWAV.BAL;
using EWAV.ViewModels;
using EWAV.Web.Services.CombinedFrequencyDomainService;

namespace EWAV.Services
{
    public class CombinedFrequencyServiceAgent : ICombinedFrequencyServiceAgent
    {
        #region Variables
        CombinedFrequencyDomainContext freqCtx;
        private Action<DatatableBag, Exception> _freqCompleted;

        #endregion

        #region Constructor
        public CombinedFrequencyServiceAgent()
        {
            
        }
        #endregion


        #region Completion Callbacks

        void freqTableResults_Completed(object sender, EventArgs e)
        {
            InvokeOperation<DatatableBag> result =
                (InvokeOperation<DatatableBag>)sender;
            Exception ex = null;
            if (result.HasError)
            {
                result.MarkErrorAsHandled();
                ex = result.Error;
            }
            DatatableBag returnedData = ((InvokeOperation<DatatableBag>)sender).Value;
            _freqCompleted(returnedData, ex);
        }
        #endregion


        public void GetCombinedFrequencyResults(EWAVCombinedFrequencyGadgetParameters combinedParameters, string groupVar, GadgetParameters gadgetParameters, IEnumerable<EWAVDataFilterCondition> ewavDataFilters, List<EWAVRule_Base> rules, string filterString, Action<DatatableBag, Exception> completed)
        {
            _freqCompleted = completed;
            freqCtx = new CombinedFrequencyDomainContext();
            InvokeOperation<DatatableBag> freqResults = freqCtx.GenerateCombinedFrequency(combinedParameters, groupVar, gadgetParameters, ewavDataFilters, rules, filterString);

            freqResults.Completed += new EventHandler(freqTableResults_Completed);
        }
    }
}
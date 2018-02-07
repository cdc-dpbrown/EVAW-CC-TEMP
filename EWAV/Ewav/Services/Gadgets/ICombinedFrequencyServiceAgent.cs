using System;
using EWAV.DTO;
using System.Collections.Generic;
using EWAV.Web.EpiDashboard;
using EWAV.Web.Services;
using EWAV.BAL;

namespace EWAV.Services
{
    public interface ICombinedFrequencyServiceAgent
    {
        /// <summary>
        /// GetCombinedFrequencyResults method that will be implemented in the ServiceAgentClass
        /// </summary>
        /// <param name="DataSourceName"></param>
        /// <param name="TableName"></param>
        /// <param name="gadgetParameters"></param>
        /// <param name="completed"></param>
        void GetCombinedFrequencyResults(EWAVCombinedFrequencyGadgetParameters combinedParameters, string groupVar, GadgetParameters gadgetParameters,
            IEnumerable<EWAVDataFilterCondition> ewavDataFilters, List<EWAVRule_Base> rules, string filterString,
             Action<DatatableBag, Exception> completed);
    }
}
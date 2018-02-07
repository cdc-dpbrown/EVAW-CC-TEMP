using System;
using EWAV.DTO;
using System.Collections.Generic;
using EWAV.Web.EpiDashboard;
using EWAV.Web.Services;
using EWAV.BAL;


namespace EWAV.Services
{
    public interface IMeansControlServiceAgent
    {
        void GetFrequencyResults(GadgetParameters gadgetParameters, Action<List<FrequencyResultData>, Exception> completed);

      //    void GetColumns(Action<List<EWAVColumn>, Exception> completed);

        void GetCrossTabResults(GadgetParameters gadgetParameters, Action<List<CrossTabResponseObjectDto>, Exception> completed);

        void GetCrossTableAndFreq(GadgetParameters gadgetParameters, Action<FrequencyAndCrossTable, Exception> completed);
    }
}
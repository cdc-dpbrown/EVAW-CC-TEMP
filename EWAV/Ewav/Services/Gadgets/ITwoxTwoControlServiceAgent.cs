using System;
using EWAV.DTO;
using System.Collections.Generic;
using EWAV.Web.EpiDashboard;
using EWAV.Web.Services;
using EWAV.BAL;


namespace EWAV.Services
{
    public interface ITwoxTwoControlServiceAgent
    {
        void GetFrequencyResults(string DataSourceName, string TableName, GadgetParameters gadgetParameters,
                IEnumerable<EWAVDataFilterCondition> ewavDataFilters, 
            Action<List<FrequencyResultData>, Exception> completed);

        string CheckColumnType(string p);

        void GetColumns(string DataSourceName, String TableName, Action<List<EWAVColumn>, Exception> completed);

        void GetCrossTabResults(string DataSourceName, string TableName, GadgetParameters gadgetParameters, Action<List<CrossTabResponseObjectDto>, Exception> completed);
    }
}
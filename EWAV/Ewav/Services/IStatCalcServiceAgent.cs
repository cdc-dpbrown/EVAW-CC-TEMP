using System;
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
using System.Collections.Generic;

namespace EWAV.Services
{
    public interface IStatCalcServiceAgent
    {
        /// <summary>
        /// GetStatCalc method that will be implemented in the ServiceAgentClass
        /// </summary>
        /// <param name="DataSourceName"></param>
        /// <param name="TableName"></param>
        /// <param name="gadgetParameters"></param>
        /// <param name="completed"></param>
        void GetStatCalc(int ytVal, int ntVal, int tyVal, int tnVal, int yyVal, int ynVal, int nyVal, int nnVal,List<DictionaryDTO> strataActive,
            List<DictionaryDTO> strataVals, Action<StatCalcDTO, Exception> completed);
    }
}
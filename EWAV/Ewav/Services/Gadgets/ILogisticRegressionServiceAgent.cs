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
using EWAV.BAL;
using System.Collections.Generic;
using EWAV.Web.Services;
using EWAV.Web.EpiDashboard;

namespace EWAV.Services
{
    public interface ILogisticRegressionServiceAgent
    {
        /// <summary>
        /// GetColumnsMethod that needs to be implemented in the ServiceAgentClass
        /// </summary>
        /// <param name="DataSourceName"></param>
        /// <param name="TableName"></param>
        /// <param name="completed"></param>
      //  void GetColumns(string DataSourceName, String TableName, Action<List<EWAVColumn>, Exception> completed);


        void GenerateTable(string DataSourceName, String TableName, List<string> columnNames, string customFilter, Action<List<ListOfStringClass>, Exception> completed);

        void GetRegressionResults(GadgetParameters gadgetOptions, List<string> columnNames, string customFilter, List<DictionaryDTO> inputDtoList, Action<LogRegressionResults, Exception> completed);
    }
}
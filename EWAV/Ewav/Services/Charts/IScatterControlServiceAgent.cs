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
    public interface IScatterControlServiceAgent
    {
        void GetColumns(string DataSourceName, String TableName, Action<List<EWAVColumn>, Exception> completed);

        void GenerateTable(GadgetParameters gadgetOptions, IEnumerable<EWAVDataFilterCondition> ewavDataFilters,
            string filterString, Action<ScatterDataDTO, Exception> completed);
    }
}
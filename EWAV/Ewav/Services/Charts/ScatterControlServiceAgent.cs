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
using System.Collections.Generic;
using EWAV.Web.Services;
using EWAV.BAL;
using System.ServiceModel.DomainServices.Client;
using EWAV.Web.EpiDashboard;
using EWAV.ViewModels;

namespace EWAV.Services
{
    public class ScatterControlServiceAgent : IScatterControlServiceAgent
    {
        private Action<List<EWAVColumn>, Exception> _completed;
        private Action<LinRegressionResults, Exception> _rresultsCompleted;
        private Action<ScatterDataDTO, Exception> _tableCompleted;
        Exception ex = null;
        #region completion

        void sctrCtxColumnResults_Completed(object sender, EventArgs e)
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

        void sctrCtxRegResults_Completed(object sender, EventArgs e)
        {
            InvokeOperation<LinRegressionResults> result = (InvokeOperation<LinRegressionResults>)sender;
            if (result.HasError)
            {
                ex = result.Error;
                result.MarkErrorAsHandled();
            }
            //else
            //{
                LinRegressionResults returnedData = ((InvokeOperation<LinRegressionResults>)sender).Value;
                _rresultsCompleted(returnedData, null);
            //}
        }

        #endregion

        #region Methods


        /// <summary>
        /// Gets columns from Domain Service
        /// </summary>
        /// <param name="DataSourceName"></param>
        /// <param name="TableName"></param>
        /// <param name="completed"></param>
        public void GetColumns(string DataSourceName, string TableName, Action<List<EWAVColumn>, Exception> completed)
        {
            _completed = completed;

            ScatterDomainContext sctrCtx = new ScatterDomainContext();
            //LinearRegressionDomainContext linrCtx = new LinearRegressionDomainContext();

            InvokeOperation<List<EWAVColumn>> sctrCtxColumnResults = sctrCtx.GetColumns(DataSourceName, TableName);
            sctrCtxColumnResults.Completed += new EventHandler(sctrCtxColumnResults_Completed);
        }

        /// <summary>
        /// Gets the regression table results from Domain service
        /// </summary>
        /// <param name="DatasourceName"></param>
        /// <param name="TableName"></param>
        /// <param name="gadgetOptions"></param>
        /// <param name="columnNames"></param>
        /// <param name="inputDtoList"></param>
        /// <param name="completed"></param>
        //public void GetRegressionResults(string DatasourceName, string TableName, GadgetParameters gadgetOptions, List<string> columnNames, List<DictionaryDTO> inputDtoList, Action<LinRegressionResults, Exception> completed)
        //{
        //    _rresultsCompleted = completed;
        //    ScatterDomainContext sctrCtx = new ScatterDomainContext();
        //    InvokeOperation<LinRegressionResults> sctrCtxRegResults = sctrCtx.GetRegressionResult(DatasourceName, TableName, gadgetOptions, columnNames, inputDtoList);
        //    sctrCtxRegResults.Completed += new EventHandler(sctrCtxRegResults_Completed);
        //}

        
        #endregion


        public void GenerateTable(GadgetParameters gadgetOptions, IEnumerable<EWAVDataFilterCondition> ewavDataFilters,
            string filterString, Action<ScatterDataDTO, Exception> completed)
        {
            _tableCompleted = completed;
            ScatterDomainContext sctrCtx = new ScatterDomainContext();
            InvokeOperation<ScatterDataDTO> sctrCtxtableResults = sctrCtx.GenerateTable(gadgetOptions,ewavDataFilters, ApplicationViewModel.Instance.EWAVDefinedVariables, ApplicationViewModel.Instance.AdvancedDataFilterString);
            sctrCtxtableResults.Completed += new EventHandler(sctrCtxtableResults_Completed);
        }

        void sctrCtxtableResults_Completed(object sender, EventArgs e)
        {
            InvokeOperation<ScatterDataDTO> result = (InvokeOperation<ScatterDataDTO>)sender;
            if (result.HasError)
            {
                ex = result.Error;
                result.MarkErrorAsHandled();
            }
            //else
            //{
                ScatterDataDTO returnedData = ((InvokeOperation<ScatterDataDTO>)sender).Value;
                _tableCompleted(returnedData, null);
            //}
        }

    }
}
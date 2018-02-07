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
    public class LogisticRegressionServiceAgent : ILogisticRegressionServiceAgent
    {
        LogisticRegressionDomainContext logrCtx;
        private Action<List<EWAVColumn>, Exception> _completed;
        private Action<List<ListOfStringClass>, Exception> _logrCompleted;
        private Action<LogRegressionResults,Exception> _rresultsCompleted;

        void logrCtxColumnResults_Completed(object sender, EventArgs e)
        {
            InvokeOperation<List<EWAVColumn>> result = (InvokeOperation<List<EWAVColumn>>)sender;
            Exception ex = null;
            if (result.HasError)
            {
                ex = result.Error;
                result.MarkErrorAsHandled();
            }
            //else
            //{
                List<EWAVColumn> returnedData = ((InvokeOperation<List<EWAVColumn>>)sender).Value;
                _completed(returnedData, ex);
            //}
        }

        

        void logrResults_Completed(object sender, EventArgs e)
        {
            InvokeOperation<List<ListOfStringClass>> result =
                (InvokeOperation<List<ListOfStringClass>>)sender;

            if (result.HasError)
            {

            }
            else
            {
                List<ListOfStringClass> returnedData = ((InvokeOperation<List<ListOfStringClass>>)sender).Value;
                _logrCompleted(returnedData, null);
            }
        }

        

        void logrCtxRegResults_Completed(object sender, EventArgs e) 
        {
            InvokeOperation<LogRegressionResults> result = (InvokeOperation<LogRegressionResults>)sender;
            if (result.HasError)
            {

            }
            else
            {
                LogRegressionResults returnedData = ((InvokeOperation<LogRegressionResults>)sender).Value;
                _rresultsCompleted(returnedData, null);
            }
        }




       // void GetRegressionResults(string DatasourceName, string TableName, GadgetParameters gadgetOptions, List<MyString> columnNames, string customFilter,   List<DictionaryDTO> inputDtoList, Action<RegressionResults, Exception> completed)
       //{
          
       //}
        //public void GetColumns(string DataSourceName, string TableName, Action<List<EWAVColumn>, Exception> completed)
        //{
        //    _completed = completed;
        //    LogisticRegressionDomainContext logrCtx = new LogisticRegressionDomainContext();
        //    InvokeOperation<List<EWAVColumn>> logrCtxColumnResults = logrCtx.GetColumns(DataSourceName, TableName);
        //    logrCtxColumnResults.Completed += new EventHandler(logrCtxColumnResults_Completed);
        //}

       public void GenerateTable(string DataSourceName, string TableName, List<string> columnNames, string customFilter, Action<List<ListOfStringClass>, Exception> completed)
        {
            _logrCompleted = completed;
            logrCtx = new LogisticRegressionDomainContext();
            InvokeOperation<List<ListOfStringClass>> logrResults = logrCtx.GenerateTable(DataSourceName, TableName, columnNames, customFilter);
            logrResults.Completed += new EventHandler(logrResults_Completed);
        }

       //void ILogisticRegressionServiceAgent.GetColumns(string DataSourceName, string TableName, Action<List<EWAVColumn>, Exception> completed)
       //{
       //    throw new NotImplementedException();
       //}

       //void ILogisticRegressionServiceAgent.GenerateTable(string DataSourceName, string TableName, List<string> columnNames, string customFilter, Action<List<ListOfStringClass>, Exception> completed)
       //{
       //    throw new NotImplementedException();
       //}




       void ILogisticRegressionServiceAgent.GetRegressionResults(GadgetParameters gadgetOptions, List<string> columnNames, string customFilter, List<DictionaryDTO> inputDtoList, Action<LogRegressionResults , Exception> completed)
       {
           _rresultsCompleted = completed;
           LogisticRegressionDomainContext logrCtx = new LogisticRegressionDomainContext();
           InvokeOperation<LogRegressionResults> logrCtxRegResults = logrCtx.GetRegressionResult(gadgetOptions, columnNames, inputDtoList, ApplicationViewModel.Instance.EWAVDatafilters, ApplicationViewModel.Instance.EWAVDefinedVariables,ApplicationViewModel.Instance.AdvancedDataFilterString, customFilter);
           logrCtxRegResults.Completed += new EventHandler(logrCtxRegResults_Completed);
       }
    }
}
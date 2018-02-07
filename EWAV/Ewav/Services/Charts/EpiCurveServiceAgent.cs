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
using EWAV.BAL;
using EWAV.ViewModels;
using EWAV.Web.Services;
using System.ServiceModel.DomainServices.Client;
using EWAV.Client.Application;

namespace EWAV.Services
{
    public class EpiCurveServiceAgent : IEpiCurveServiceAgent
    {
        private Action<List<EWAVColumn>, Exception> _completed;
        private Action<Web.Services.DatatableBag, Exception> _epiCrvCompleted;

        public void GetEpiCurveResults(EWAV.Web.EpiDashboard.GadgetParameters gadgetParameters, bool byEpiWeek, string dateVar, string caseStatusVar, Action<Web.Services.DatatableBag, Exception> completed)
        {
            _epiCrvCompleted = completed;
            EpiCurveDomainContext eCrvCtx = new EpiCurveDomainContext();
            InvokeOperation<Web.Services.DatatableBag> eCrvResults = eCrvCtx.GetEpiCurveData(gadgetParameters,
                     ApplicationViewModel.Instance.EWAVDatafilters, ApplicationViewModel.Instance.EWAVDefinedVariables, ApplicationViewModel.Instance.AdvancedDataFilterString, byEpiWeek, dateVar, caseStatusVar);
            eCrvResults.Completed += new EventHandler(eCrvResults_Completed);
        }

        void eCrvResults_Completed(object sender, EventArgs e)
        {
            InvokeOperation<Web.Services.DatatableBag> result = (InvokeOperation<Web.Services.DatatableBag>)sender;
           Exception ex = null;
            if (result.HasError)
            {
                result.MarkErrorAsHandled();
                //throw new GadgetException(result.Error.Message);
                ex = result.Error;
            }
            //else
            //{
                Web.Services.DatatableBag returnedData = ((InvokeOperation<Web.Services.DatatableBag>)sender).Value;
                _epiCrvCompleted(returnedData, null);
            //}
        }

        public string CheckColumnType(string p)
        {
            throw new NotImplementedException();
        }

        public void GetColumns(string DataSourceName, string TableName, Action<System.Collections.Generic.List<BAL.EWAVColumn>, Exception> completed)
        {
            _completed = completed;
            EpiCurveDomainContext eCrvCtx = new EpiCurveDomainContext();
            InvokeOperation<List<EWAVColumn>> freqColumnResults = eCrvCtx.GetColumns(DataSourceName, TableName);
            freqColumnResults.Completed += new EventHandler(freqColumnResults_Completed);
        }

        void freqColumnResults_Completed(object sender, EventArgs e)
        {
            InvokeOperation<List<EWAVColumn>> result = (InvokeOperation<List<EWAVColumn>>)sender;
            if (result.HasError)
            {

            }
            else
            {
                List<EWAVColumn> returnedData = ((InvokeOperation<List<EWAVColumn>>)sender).Value;
                _completed(returnedData, null);
            }
        }


    }
}
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
using EWAV.Web.Services;
using System.Collections.Generic;
using System.ServiceModel.DomainServices.Client;
using EWAV.ViewModels;

namespace EWAV.Services
{
    public class LineListControlServiceAgent : ILineListControlServiceAgent
    {

        #region Variables
        LineListDomainContext llCtx = null;
        private Action<List<DatatableBag>, Exception> _completed;
        #endregion

        #region Constructor
        public LineListControlServiceAgent()
        {
        }
        #endregion

        #region Helper Method

        public void GenerateLineList(EWAV.Web.EpiDashboard.GadgetParameters gp, Action<List<DatatableBag>, Exception> completed)
        {
            _completed = completed;
            llCtx = new LineListDomainContext();
            InvokeOperation<List<DatatableBag>> lineListResutls =
               llCtx.GetLineList(gp, ApplicationViewModel.Instance.EWAVDatafilters, ApplicationViewModel.Instance.EWAVDefinedVariables, ApplicationViewModel.Instance.AdvancedDataFilterString);
            lineListResutls.Completed += new EventHandler(lineListResutls_Completed);
        }


        #endregion

        #region Completion Callbacks

        void lineListResutls_Completed(object sender, EventArgs e)
        {
            InvokeOperation<List<DatatableBag>> result =
                (InvokeOperation<List<DatatableBag>>)sender;

            Exception ex = null;
            if (result.HasError)
            {
                result.MarkErrorAsHandled();
                ex = result.Error;
            }
            List<DatatableBag> returnedData = ((InvokeOperation<List<DatatableBag>>)sender).Value;
            _completed(returnedData, ex);
        }
        #endregion




    }
}
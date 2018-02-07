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
using EWAV.Web.Services.ErrorDomainService;
using System.ServiceModel.DomainServices.Client;

namespace EWAV.Services
{
    public class ErrorMessageServiceAgent : IErrorMessageServiceAgent
    {
        public Action<bool, Exception> _completed;


        public void EmailErrorMessage(string Message, Action<bool, Exception> completed)
        {
            _completed = completed;

            ErrorDomainContext ctx = new ErrorDomainContext();

           InvokeOperation<bool> Results = ctx.EmailErrorMessage(Message);

           Results.Completed += new EventHandler(Results_Completed);
        }

        void Results_Completed(object sender, EventArgs e)
        {
            Exception ex = null;
            InvokeOperation<bool> result = (InvokeOperation<bool>)sender;
            if (result.HasError)
            {
                ex = result.Error;
                result.MarkErrorAsHandled();
            }
            bool returnedData = ((InvokeOperation<bool>)sender).Value;
            _completed(returnedData, ex);
            
        }


    }
}
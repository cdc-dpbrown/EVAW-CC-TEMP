namespace CDC.ISB.EIDEV.Web.Services.ErrorDomainService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using CDC.ISB.EIDEV.BAL;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class ErrorDomainService : DomainService
    {
        [Invoke]
        public bool EmailErrorMessage(string EmailMessage) 
        {
            try
            {
                //string emailAddress = ConfigurationManager.AppSettings["EMAIL_TO"].ToString();
                Email.SendMessage("", "Exception occured.", EmailMessage, true);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            //return false;
        }
    }
}
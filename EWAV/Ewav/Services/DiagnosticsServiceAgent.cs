using System;
using System.Collections.Generic;
using EWAV.Web.Services;
using EWAV.DTO;
using System.ServiceModel.DomainServices.Client;
using EWAV.BAL;
using EWAV.ViewModels;
using System.Linq;

namespace EWAV.Services
{
    /// <summary>
    /// Service agent for EWAV external data sources.  
    /// </summary>
    public class DiagnosticsServiceAgent
    {

        DiagnosticsDomainContext diagCtx;

        Exception ex = null;
        /// <summary>
        /// public ctor 
        /// </summary>
        public DiagnosticsServiceAgent()
        {

            diagCtx = new DiagnosticsDomainContext();

            //         DatasourceDomainContext xx = new DatasourceDomainContext();    



        }



        private Action<string, Exception> _completed;



        /// <summary>
        /// Gets the columns for datasource.
        /// </summary>
        /// <param name="dataSourceName">Name of the data source.</param>
        /// <param name="columnsForDatasourceCompleted">The columns for datasource completed.</param>
        public void CheckAllDatasources(Action<string, Exception> completed)
        {

            DiagnosticsDomainContext diagCtx = new DiagnosticsDomainContext();



            diagCtx.CheckAllDatasources(result =>
            {
                Exception ex = null;
                if (result.HasError)
                {
                    result.MarkErrorAsHandled();
                    ex = result.Error;
                    throw new GadgetException(result.Error.Message);

                }

                string errDatasources = ((InvokeOperation<string>)result).Value;
                completed(errDatasources, ex);

            }, null);
        }



        public void ServiceEndpointCheck(Action<bool, Exception> completed)
        {

            DiagnosticsDomainContext diagCtx = new DiagnosticsDomainContext();


            diagCtx.ServiceEndpointCheck(result =>
            {
                Exception ex = null;
                if (result.HasError)
                {


                    ex = result.Error;
                    throw new Exception(result.Error.Message);

                }

                bool pass = ((InvokeOperation<bool>)result).Value;
                completed(pass, ex);

            }, null);




        }

        public void UserCheck(string userName, Action<bool, Exception> completed)
        {

            DiagnosticsDomainContext diagCtx = new DiagnosticsDomainContext();


            diagCtx.UserCheck(userName, result =>
            {
                Exception ex = null;
                if (result.HasError)
                {

                    ex = result.Error;
                    throw new Exception(result.Error.Message);

                }

                bool pass = ((InvokeOperation<bool>)result).Value;
                completed(pass, ex);

            }, null);




        }

        public void CheckDatasource(string datasourceName, Action<Dictionary<string, bool>, Exception> completed)
        {

            DiagnosticsDomainContext diagCtx = new DiagnosticsDomainContext();

            diagCtx.CheckDatasource(datasourceName, result =>
            {
                Exception ex = null;
                if (result.HasError)
                {
                    result.MarkErrorAsHandled();
                    ex = result.Error;
                    throw new GadgetException(result.Error.Message);

                }

                Dictionary<string, bool> datasourceDict = ((InvokeOperation<Dictionary<string, bool>>)result).Value;
                completed(datasourceDict, ex);

            }, null);


        }

        public void GetAllDatasourceNames(Action<IEnumerable<string>, Exception> completed)
        {

            DiagnosticsDomainContext diagCtx = new DiagnosticsDomainContext();



            diagCtx.GetAllDatasourceNames(result =>
            {
                Exception ex = null;
                if (result.HasError)
                {
                    result.MarkErrorAsHandled();
                    ex = result.Error;
                    throw new GadgetException(result.Error.Message);

                }

                IEnumerable<string> datasourcesNames = ((InvokeOperation<IEnumerable<string>>)result).Value;
                completed(datasourcesNames, ex);

            }, null);
        }

    }
}
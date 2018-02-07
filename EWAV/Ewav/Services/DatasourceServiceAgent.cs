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
    public class DatasourceServiceAgent : IDatasourceServiceAgent
    {
        DatasourceDomainContext datasourceCtx;
        Exception ex = null;
        /// <summary>
        /// public ctor 
        /// </summary>
        public DatasourceServiceAgent()
        {
            datasourceCtx = new DatasourceDomainContext();
        }

        /// <summary>
        /// Thia is not per the SimpleMvvm guidelines but it makes it easier apparently if you 
        /// are NOT using Entity Framework 
        /// </summary>
        //private Action<IEnumerable<DTO.EWAVDatasourceDto>, Exception> _completed;
        private Action<IEnumerable<EWAVDatasourceDto>, Exception> _completed2;

        private Action<string, Exception> _completed3, _completed4, _advDFCompleted;

     //    private Action<List<DatasourceUserDto>, Exception> _getDatasourceUserCompleted;

        private Action<List<DTO.DatasourceDto>, Exception> _readOrgCompleted;
        private Action<long, Exception> _recordCountCompleted;




        /// <summary>
        /// Gets the columns for datasource.
        /// </summary>
        /// <param name="dataSourceName">Name of the data source.</param>
        /// <param name="columnsForDatasourceCompleted">The columns for datasource completed.</param>
        public void GetColumnsForDatasource(string dataSourceName, Action<List<EWAVColumn>, Exception> completed)
        {

            DatasourceDomainContext dataSourceCtx = new DatasourceDomainContext();

            dataSourceCtx.GetColumnsForDatasource(dataSourceName, result =>
              {
                  Exception ex = null;
                  if (result.HasError)
                  {
                      result.MarkErrorAsHandled();
                      ex = result.Error;
                      throw new GadgetException(result.Error.Message);

                  }

                  List<EWAVColumn> allColumns = ((InvokeOperation<List<EWAVColumn>>)result).Value;
                  completed(allColumns, ex);
              }, null);
        }

        /// <summary>
        /// Datasets the filtered record count.
        /// </summary>
        /// <param name="DatasetName">Name of the dataset.</param>
        /// <param name="Filter">The filter.</param>
        /// <param name="completed">The completed.</param>
        public void DatasetFilteredRecordCount(string DatasetName, object Filter, Action<long, Exception> completed)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all datasources 
        /// </summary>
        /// <param name="completed">This is the callback function passed from the view model </param>
        //public void GetDatasources(Action<IEnumerable<DTO.EWAVDatasourceDto>, Exception> completed)     
        //{
        //    _completed = completed;

        //    IEnumerable<EWAVDatasourceDto> datasources = null;
        //    // The actual call to the server from via the SL proxy. 
        //    InvokeOperation<IEnumerable<EWAVDatasourceDto>> datasouceResults = datasourceCtx.GetDatasourcesAsIEnumerble();
        //    datasouceResults.Completed += new EventHandler(datasouceResults_Completed);
        //}

        /// <summary>
        /// Get the record count.
        /// </summary>
        /// <param name="completed"></param>
        public void GetRecordCount(List<EWAVDataFilterCondition> filterList, List<EWAVRule_Base> rules, string tableName, string dsName, Action<string, Exception> completed)
        {
            _completed3 = completed;
            InvokeOperation<string> Results = datasourceCtx.GetRecordCount(filterList, rules, tableName, dsName);

            Results.Completed += new EventHandler(Results_Completed);

            //            string
        }

        void Results_Completed(object sender, EventArgs e)
        {
            InvokeOperation<string> result = (InvokeOperation<string>)sender;
            if (result.HasError)
            {
                ex = result.Error;
                result.MarkErrorAsHandled();
            }
            //else
            //{
            string returnedData = ((InvokeOperation<string>)sender).Value;
            _completed3(returnedData, ex);
            //}
        }

        /// <summary>
        /// Get the record count.
        /// </summary>
        /// <param name="completed"></param>
        public void GetRecordCount(List<EWAVRule_Base> rules, string s, string tableName, string dsName, Action<string, Exception> completed)
        {
            _advDFCompleted = completed;
            InvokeOperation<string> AdvResults = datasourceCtx.GetRecordCountByString(rules, s, tableName, dsName);
            AdvResults.Completed += new EventHandler(AdvResults_Completed);

            //            string
        }

        //public void GetAllDatasourceUser(Action<IEnumerable<DatasourceUserDto>, Exception> completed)
        //{
        //    _getDatasourceUserCompleted = completed;
        //    InvokeOperation<IEnumerable<DatasourceUserDto>> xAllDatasourceUsers = datasourceCtx.GetAllDatasourceUser();
                       

        //    //            string
        //}


        void AdvResults_Completed(object sender, EventArgs e)
        {
            InvokeOperation<string> result = (InvokeOperation<string>)sender;
            if (result.HasError)
            {
                ex = result.Error;
                result.MarkErrorAsHandled();
            }
            //else
            //{
            string returnedData = ((InvokeOperation<string>)sender).Value;
            _advDFCompleted(returnedData, ex);
            //}
        }
        /// <summary>
        /// Reads Filter string
        /// </summary>
        /// <param name="filterList"></param>
        /// <param name="dsName"></param>
        /// <param name="completed"></param>
        public void ReadFilterString(List<EWAVDataFilterCondition> filterList, List<EWAVRule_Base> rules, string tableName, string dsName, Action<string, Exception> completed)
        {
            _completed4 = completed;
            InvokeOperation<string> Results = datasourceCtx.ReadFilterString(filterList, rules, tableName, dsName);
            Results.Completed += new EventHandler(Results4_Completed);
        }

        void Results4_Completed(object sender, EventArgs e)
        {
            InvokeOperation<string> result = (InvokeOperation<string>)sender;
            if (result.HasError)
            {
                ex = result.Error;
                result.MarkErrorAsHandled();
            }
            //else
            //{
            string returnedData = ((InvokeOperation<string>)sender).Value;
            _completed4(returnedData, ex);
            //}
        }

        /// <summary>
        /// Completion handler for the domain context call.   
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //void datasouceResults_Completed(object sender, EventArgs e)
        //{
        //    InvokeOperation<IEnumerable<EWAVDatasourceDto>> result = (InvokeOperation<IEnumerable<EWAVDatasourceDto>>)sender;
        //    if (result.HasError)
        //    {
        //        // completed = result.Error;
        //    }
        //    else
        //    {
        //        IEnumerable<EWAVDatasourceDto> returnedData = ((InvokeOperation<IEnumerable<EWAVDatasourceDto>>)sender).Value;
        //        _completed(returnedData, null);
        //    }
        //    //   EWAV.ContextMenu.MenuItem it = new EWAV.ContextMenu.MenuItem("Item 1");
        //}


        public void DatasetRecordCount(string DatasetName, Action<long, Exception> completed)
        {
            _recordCountCompleted = completed;

            // The actual call to the server from via the SL proxy. 
            //InvokeOperation< string    > datasouceRecordCountResults = datasourceCtx.GetRecordCount(
            //    ApplicationViewModel.Instance.EWAVDatafilters,
            //    ApplicationViewModel.Instance.ListOfRules, 
            //    ApplicationViewModel.Instance.EWAVSelectedDatasource.TableName,
            //       ApplicationViewModel.Instance.EWAVSelectedDatasource.DatasourceName);
            //datasouceRecordCountResults.Completed += new EventHandler(datasouceRecordCountResults_Completed);
        }

        public void GetDatasources2(Action<IEnumerable<EWAVDatasourceDto>, Exception> completed)
        {
            _completed2 = completed;

            IEnumerable<EWAVDatasourceDto> datasources = null;
            //77777          // The actual call to the server from via the SL proxy. 
            InvokeOperation<IEnumerable<EWAVDatasourceDto>> datasouceResults2 = datasourceCtx.GetDatasourcesAsIEnumerble2(
                    ApplicationViewModel.Instance.LoggedInUser.UserDto.UserName);
            datasouceResults2.Completed += new EventHandler(datasouceResults_Completed2);
        }

        /// <summary>
        /// Handles the Completed2 event of the datasouceResults control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void datasouceResults_Completed2(object sender, EventArgs e)
        {
            InvokeOperation<IEnumerable<EWAVDatasourceDto>> result = (InvokeOperation<IEnumerable<EWAVDatasourceDto>>)sender;
            if (result.HasError)
            {
                ex = result.Error;
                throw new Exception(ex.Message + "====" + ex.StackTrace);

                // result.MarkErrorAsHandled();
            }
            //else
            //{
            IEnumerable<EWAVDatasourceDto> returnedData = ((InvokeOperation<IEnumerable<EWAVDatasourceDto>>)sender).Value;
            _completed2(returnedData, ex);
            //}
        }

        void datasouceRecordCountResults_Completed(object sender, EventArgs e)
        {
            InvokeOperation<long> result = (InvokeOperation<long>)sender;

            if (result.HasError)
            {
                ex = result.Error;
                result.MarkErrorAsHandled();
            }
            //else
            //{
            long returnedData = ((InvokeOperation<long>)sender).Value;
            _recordCountCompleted(returnedData, ex);
            //}
        }


        public void ReadAllDatasourcesInMyOrg(int orgId, Action<List<DTO.DatasourceDto>, Exception> completed)
        {
            _readOrgCompleted = completed;
            datasourceCtx = new DatasourceDomainContext();

            // InvokeOperation<IEnumerable<DTO.DatasourceDto>> readAllDSResults = datasourceCtx.ReadAllDatasourcesInMyOrg(orgId);
            //readAllDSResults.Completed += new EventHandler(readAllDSResults_Completed);
        }

        void readAllDSResults_Completed(object sender, EventArgs e)
        {
            InvokeOperation<IEnumerable<DTO.DatasourceDto>> result =
                (InvokeOperation<IEnumerable<DTO.DatasourceDto>>)sender;
            Exception ex = null;

            if (result.HasError)
            {
                result.MarkErrorAsHandled();
                //throw new GadgetException(result.Error.Message);
                ex = result.Error;
            }
            //else
            //{
            IEnumerable<DTO.DatasourceDto> returnedData = ((InvokeOperation<IEnumerable<DTO.DatasourceDto>>)sender).Value;
            _readOrgCompleted(returnedData.ToList(), ex);
            //}
        }

    }
}
using System;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;

// Toolkit namespace
using SimpleMvvmToolkit;

// Toolkit extension methods
using SimpleMvvmToolkit.ModelExtensions;
using EWAV.Services;
using System.Collections.Generic;
using EWAV.Web.Services;
using EWAV.BAL;
using EWAV.Web.EpiDashboard;
using EWAV.Client.Application;
using CommonLibrary;

namespace EWAV.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvmprop</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// </summary>
    public class AberrationViewModel : ViewModelBase<AberrationViewModel>
    {

        #region Initialization and Cleanup
        private IAberrationControlServiceAgent serviceAgent;

        public ApplicationViewModel applicationViewModel = ApplicationViewModel.Instance;

        /// <summary>
        /// When the data source name is chahged the name is made avail to the application  
        /// </summary>
        public event DatasourceChangedEventHandler DatasourceChangedEvent;

        public IAberrationControlServiceAgent ServiceAgent
        {
            get { return serviceAgent; }
            set { serviceAgent = value; }
        }

        /// <summary>
        /// Creates new object for Service Agent.
        /// </summary>
        public AberrationViewModel()
        {
            //applicationViewModel.DatasourceChangedEvent += new DatasourceChangedEventHandler(applicationViewModel_DatasourceChangedEvent);
            serviceAgent = new AberrationControlServiceAgent();

        }

        //void applicationViewModel_DatasourceChangedEvent(object o, DatasourceChangedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// initializes the serviceAgent.
        /// </summary>
        /// <param name="serviceAgent"></param>
        public AberrationViewModel(IAberrationControlServiceAgent serviceAgent)
        {
            this.serviceAgent = serviceAgent;
        }

        #endregion

        #region Notifications

        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;
        public event EventHandler<NotificationEventArgs<Exception>> ColumnsLoadedEvent;
        public event EventHandler<NotificationEventArgs<Exception>> FrequencyTableLoadedEvent;
        public event EventHandler<NotificationEventArgs<Exception>> ColumnsMetaDataLoadedEvent;

        #endregion

        #region Private Properties

        private List<FrequencyResultData> frequencyTable;

        public List<FrequencyResultData> FrequencyTable
        {
            get { return frequencyTable; }
            set { frequencyTable = value; }
        }

        private List<EWAVColumn> columns;

        public List<EWAVColumn> Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        #endregion

        #region Completion Callbacks

        #endregion

        #region Helpers

        // Helper method to notify View of an error
        private void NotifyError(string message, Exception error)
        {
            // Notify view of an error
            Notify(ErrorNotice, new NotificationEventArgs<Exception>(message, error));
        }


        /// <summary>
        /// Completion for frequency Table
        /// </summary>
        /// <param name="result"></param>
        /// <param name="e"></param>
        private void GetFrequencyTableCompleted(List<FrequencyResultData> result, Exception e)
        {
            if (e != null)
            {
                NotificationEventArgs<Exception> notification = new NotificationEventArgs<Exception>("", e);
                this.Notify(ErrorNotice, notification);
            }
            else
            {
                this.frequencyTable = result;
                if (frequencyTable.Count == 0)
                {
                    Exception exp = new Exception(SharedStrings.NO_RECORDS_SELECTED.ToString());

                    this.Notify(ErrorNotice, new NotificationEventArgs<Exception>("", exp));
                   // Notify(ErrorNotice, new NotificationEventArgs<Exception>(SharedStrings.NO_RECORDS_SELECTED));
                }
                else
                {
                    Notify(FrequencyTableLoadedEvent, new NotificationEventArgs<Exception>());
                }
            }
        }

        /// <summary>
        /// Completion for allColumns
        /// </summary>
        /// <param name="result"></param>
        /// <param name="e"></param>

        //private void GetColumnsCompleted(List<EWAVColumn> result, Exception e)
        //{
        //    if (e != null)
        //    {
        //        NotifyError("There is an error", e);
        //    }
        //    else
        //    {
        //        this.Columns = new List<EWAVColumn>(result);
        //        Notify(ColumnsLoadedEvent, new NotificationEventArgs<Exception>());
        //    }
        //}

        /// <summary>
        /// Call to serviceAgent Method
        /// </summary>
        /// <param name="DataSourceName"></param>
        /// <param name="TableName"></param>
        //public void GetColumns(string DataSourceName, string TableName)
        //{

        //    ServiceAgent.GetColumns(DataSourceName, TableName, GetColumnsCompleted);
        //}

        /// <summary>
        /// call to serviceAgent Method
        /// </summary>
        /// <param name="DataSourceName"></param>
        /// <param name="TableName"></param>
        /// <param name="gadgetParameters"></param>
        public void GetFrequencyData(GadgetParameters gadgetParameters)
        {
            ServiceAgent.GetFrequencyResults(gadgetParameters, GetFrequencyTableCompleted);
        }
        #endregion





    }
}
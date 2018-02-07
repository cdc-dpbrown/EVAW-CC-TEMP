﻿using System;
using System.Collections.Generic;
using EWAV.Web.EpiDashboard;
using EWAV.BAL;
using EWAV.Client.Application;
using EWAV.Services;
using EWAV.Web.Services;
using SimpleMvvmToolkit;

namespace EWAV.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvmprop</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// </summary>
    public class FrequencyViewModel : ViewModelBase<FrequencyViewModel>
    {
        #region Initialization and Cleanup
        private IFrequencyControlServiceAgent serviceAgent;

        public ApplicationViewModel applicationViewModel = ApplicationViewModel.Instance;

        public IFrequencyControlServiceAgent ServiceAgent
        {
            get
            {
                return this.serviceAgent;
            }
            set
            {
                this.serviceAgent = value;
            }
        }

        /// <summary>
        /// Creates new object for Service Agent.
        /// </summary>
        public FrequencyViewModel()
        {
            //this.applicationViewModel.DatasourceChangedEvent += new Client.Application.DatasourceChangedEventHandler(applicationViewModel_SelectedDatasourceNameChangedEvent);
            //this.serviceAgent = new FrequencyControlServiceAgent();  
        }

        /// <summary>
        /// initializes the serviceAgent.
        /// </summary>
        /// <param name="serviceAgent"></param>
        public FrequencyViewModel(IFrequencyControlServiceAgent serviceAgent)
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

        public event FilteredRecordcountUpdatedEventHandler FilteredRecordcountUpdatedEvent;

        #region Private Properties

        private List<FrequencyResultData> frequencyTable;

        public List<FrequencyResultData> FrequencyTable
        {
            get
            {
                return this.frequencyTable;
            }
            set
            {
                this.frequencyTable = value;
            }
        }

        private List<EWAVColumn> columns;

        public List<EWAVColumn> Columns
        {
            get
            {
                return this.columns;
            }
            set
            {
                this.columns = value;
            }
        }

        #endregion

        #region Completion Callbacks

        #endregion

        #region Helpers

        // Helper method to notify View of an error
        private void NotifyError(string message, Exception error)
        {
            // Notify view of an error
            this.Notify(ErrorNotice, new NotificationEventArgs<Exception>(message, error));
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
                NotificationEventArgs<Exception> notification = new NotificationEventArgs<Exception>("", e);
                this.frequencyTable = result;
                //if (frequencyTable.Count < applicationViewModel.EWAVSelectedDatasource.TotalRecords)
                //{
                if (frequencyTable.Count == 0)
                {
                    this.Notify(ErrorNotice, new NotificationEventArgs<Exception>("No Data Selected", e));// new NotificationEventArgs<Exception>());
                }
                else
                {
                    this.Notify(FrequencyTableLoadedEvent, new NotificationEventArgs<Exception>());
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
        //        this.NotifyError("There is an error", e);
        //    }
        //    else
        //    {
        //        this.Columns = new List<EWAVColumn>(result);
        //        this.Notify(ColumnsLoadedEvent, new NotificationEventArgs<Exception>());
        //    }
        //}

        /// <summary>
        /// Call to serviceAgent Method
        /// </summary>
        /// <param name="DataSourceName"></param>
        /// <param name="TableName"></param>
        //public void GetColumns(string DataSourceName, string TableName)
        //{
        //    this.ServiceAgent.GetColumns(DataSourceName, TableName, GetColumnsCompleted);
        //}

        /// <summary>
        /// call to serviceAgent Method
        /// </summary>
        /// <param name="DataSourceName"></param>
        /// <param name="TableName"></param>
        /// <param name="gadgetParameters"></param>
        public void GetFrequencyData(GadgetParameters gadgetParameters)
        {
            this.ServiceAgent.GetFrequencyResults(gadgetParameters, applicationViewModel.EWAVDatafilters, applicationViewModel.AdvancedDataFilterString,
                GetFrequencyTableCompleted);
        }    


        #endregion    


    }
}
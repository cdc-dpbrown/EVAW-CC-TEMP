using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EWAV.ViewModels;
using EWAV.BAL;
using System.Collections.Generic;

namespace EWAV
{
    public partial class SetDatasource : ChildWindow
    {
        AppMenuViewModel appMenuViewModel = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetDatasource" /> class.
        /// </summary>
        public SetDatasource()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(SetDB_Loaded);

        }

        /// <summary>
        /// Handles the Loaded event of the SetDB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        void SetDB_Loaded(object sender, RoutedEventArgs e)
        {
            appMenuViewModel = new AppMenuViewModel();
            appMenuViewModel.GetDatasourcesAsIEnumerable2();
            waitCursor.Visibility = System.Windows.Visibility.Visible;
            appMenuViewModel.DatasourcesLoadedEvent += new EventHandler<SimpleMvvmToolkit.NotificationEventArgs<Exception>>(appMenuViewModel_DatasourcesLoadedEvent);
        }

        /// <summary>
        /// Apps the menu view model_ datasources loaded event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        void appMenuViewModel_DatasourcesLoadedEvent(object sender, SimpleMvvmToolkit.NotificationEventArgs<Exception> e)
        {
            appMenuViewModel = (AppMenuViewModel)sender;

            ApplicationViewModel.Instance.EWAVDatasources = appMenuViewModel.Datasources2;

            if (appMenuViewModel.Datasources2.Count > 0)
            {
                List<EWAVDatasourceDto> Datasources2 = new List<EWAVDatasourceDto>();
                Datasources2.Insert(0, new EWAVDatasourceDto() { DatasourceNoCamelName = "Set Data Source" });
                Datasources2.InsertRange(1, appMenuViewModel.Datasources2);
                //appMenuViewModel.Datasources2 = Datasources2;
                this.cboDatasoures.ItemsSource = Datasources2;
                this.cboDatasoures.SelectedValue = "DatasourceID";
                this.cboDatasoures.DisplayMemberPath = "DatasourceNoCamelName";

                this.cboDatasoures.SelectedIndex = 0;
            }
            else
            {
                spMsg.Visibility = System.Windows.Visibility.Visible;
                tbSaveError.Text = "There are no data sources assigned to you. Please contact the Adminstrator for your organization.";
                btnSetDB.IsEnabled = false;
            }
            waitCursor.Visibility = System.Windows.Visibility.Collapsed;

        }

        /// <summary>
        /// Handles the Click event of the CancelButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        /// <summary>
        /// Handles the Click event of the OKButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (ApplicationViewModel.Instance.EWAVSelectedDatasource != null &&
                    ApplicationViewModel.Instance.EWAVDatasourceSelectedIndex != ((EWAV.BAL.EWAVDatasourceDto)(cboDatasoures.SelectedItem)).DatasourceID)
            {
                MessageBoxResult result = MessageBox.Show("You are about to change the data source. Any unsaved changes on your current dashboard will be lost. Would you like to continue?", "Warning", MessageBoxButton.OKCancel);

                if (result == MessageBoxResult.Cancel)
                {
                    this.DialogResult = false;
                    return;
                }
            }

            //  we should not do this twice         
            ApplicationViewModel.Instance.EWAVDatasourceSelectedIndex = -1;
            ApplicationViewModel.Instance.EWAVDatasourceSelectedIndex = cboDatasoures.SelectedIndex - 1; // -1 because cboDatasources has 'Set Data source' as a valid item in the collection.


            //  ApplicationViewModel.Instance.EWAVSelectedDatasource = (EWAVDatasourceDto)this.cboDatasoures.SelectedValue;

            this.DialogResult = true;


        }

        private void cboDatasoures_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboDatasoures.SelectedIndex > 0)
            {
                btnSetDB.IsEnabled = true;
            }
            else
            {
                btnSetDB.IsEnabled = false;
            }
        }

    }
}
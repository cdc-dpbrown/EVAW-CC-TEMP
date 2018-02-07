using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using EWAV.Web.Services;

namespace EWAV
{
    public partial class GadgetFilterControl : ChildWindow
    {
        private List<EWAVDataFilterCondition> gadgetFilters;

        public List<EWAVDataFilterCondition> GadgetFilters
        {
            get { return gadgetFilters; }
            set { gadgetFilters = value; }
        }


        public GadgetFilterControl()
        {
            InitializeComponent();
            FilterCtrl.FilterType = FilterControlType.DataFilter;
            FilterCtrl.InitializeDataFilter();
        }

        public GadgetFilterControl(List<EWAVDataFilterCondition> Conditions) 
        {
            InitializeComponent();
            FilterCtrl.FilterType = FilterControlType.DataFilter;
            FilterCtrl.ConstructStackPanelFromDataFilters(Conditions);
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            List<EWAVDataFilterCondition> DFilters = FilterCtrl.CreateDataFilters();
            if (DFilters == null)
            {
                return;
            }
            GadgetFilters = DFilters;

            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            FilterCtrl.Clear();
            FilterCtrl.CreateFilterConditionRow();

            GadgetFilters = null;

            this.DialogResult = true;
        }
    }
}
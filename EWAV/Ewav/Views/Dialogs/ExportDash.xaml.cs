using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EWAV.ViewModels;

namespace EWAV
{
    public partial class ExportDash : ChildWindow
    {
        ApplicationViewModel applicationViewModel = ApplicationViewModel.Instance;
        public ExportDash()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
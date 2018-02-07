using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EWAV.ViewModels;

namespace EWAV
{
    public partial class CloseGadget : ChildWindow
    {
        ApplicationViewModel applicationViewModel = ApplicationViewModel.Instance;
        UserControl _userControl;
        public CloseGadget(UserControl userControl)
        {
            InitializeComponent();
            _userControl = userControl;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            applicationViewModel.CloseGadget(_userControl);
            this.DialogResult = true;
        }
    }
}
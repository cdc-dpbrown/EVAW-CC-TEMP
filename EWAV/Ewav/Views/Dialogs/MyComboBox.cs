using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using EWAV.ViewModels;

namespace EWAV
{
    public class MyComboBox : ComboBox
    {
        public MyComboBox()
        {
            DefaultStyleKey = typeof(MyComboBox);
        }

        Popup popup;
        DataGrid g;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            popup = (VisualTreeHelper.GetChild(this, 0) as Grid).FindName("Popup") as Popup;
            g = ((popup.Child as Canvas).Children[1] as Border).Child as DataGrid;
            g.SelectionChanged += new SelectionChangedEventHandler(g_SelectionChanged);
            g.MouseLeftButtonUp += new MouseButtonEventHandler(g_MouseLeftButtonUp);
        }

        void g_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.IsDropDownOpen = false;
        }

        void g_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
            {
                this.SelectedIndex = 0;
            }
            else
            {
                this.SelectedItem = e.AddedItems[0];
                ApplicationViewModel.Instance.SelectedCanvasName = ((DashboardInfo)((DataGrid)sender).SelectedItem).Title;
                ApplicationViewModel.Instance.EwvSelectedDatasourceNameCandidate = ((DashboardInfo)((DataGrid)sender).SelectedItem).DataSource;
            }
        }
    }
}
using System.Windows;
using EWAV.ViewModels;

namespace EWAV
{
    public interface ICustomizableGadget
    {
  

    
        /// <summary>
        /// Gets or sets the set labels popup.
        /// </summary>
        /// <value>The set labels popup.</value>
        SetLabels setLabelsPopup { get; set; }
        

        
                /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        /// <value>The view model.</value>
        SetLabelsViewModel viewModel   { get; set; }

        
        void HeaderButton_Click(object sender, RoutedEventArgs e);

        void window_Unloaded(object sender, RoutedEventArgs e);

        void SetChartLabels();

        /// <summary>
        /// Sets the header and footer.
        /// </summary>
        void SetHeaderAndFooter();

        void LoadViewModel();
    }
}
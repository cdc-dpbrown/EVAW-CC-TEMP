using System.Windows;
using System.Windows.Controls;

namespace EWAV.Common
{
    public class MoveEngine
    {

        private EWAV.ViewModels.ApplicationViewModel applicationViewModel = EWAV.ViewModels.ApplicationViewModel.Instance;
        private DragCanvas parentCanvas;


        public void MoveElementRight(UIElement element)
        {

        }

        public void MoveAllElements()
        {
            foreach (UIElement thisElement in parentCanvas.Children    )  
            {
                if (thisElement is UserControl)
                {
                    UserControl uc = thisElement as UserControl;

                    if (uc is IEWAVGadget)
                    {
                        if (applicationViewModel.LoadedGadgets.Contains(uc.Name))
                        {
                            uc.SetValue(Canvas.LeftProperty, 44);
                            uc.SetValue(Canvas.TopProperty, 77);


                        }
                    }
                }
            }
        }

    }


}
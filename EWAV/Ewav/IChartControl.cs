using System;
using EWAV.ClientCommon;
using EWAV.ViewModels;

namespace EWAV
{
    /// <summary>
    /// IChartControl
    /// </summary>
    public interface IChartControl
    {
        /// <summary>
        /// Method used to Set the Chart Label
        /// </summary>
        void SetChartLabels();

        /// <summary>
        /// Method that saves the image.
        /// </summary>
        void SaveAsImage();


        XYControlChartTypes GetChartTypeEnum();


    }
}
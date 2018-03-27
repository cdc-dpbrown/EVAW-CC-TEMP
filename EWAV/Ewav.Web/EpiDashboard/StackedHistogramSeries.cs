using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Controls.DataVisualization;
using System.Windows.Controls;

namespace CDC.ISB.EIDEV.Web.EpiDashboard
{
    public class StackedHistogramSeries : StackedColumnSeries
    {
        protected override void UpdateDataItemPlacement(IEnumerable<DefinitionSeries.DataItem> dataItems)
        {
            base.UpdateDataItemPlacement(dataItems);
            double width = this.SeriesArea.ActualWidth / IndependentValueGroups.Count();
            foreach (DefinitionSeries.DataItem dataItem in dataItems)
            {
                double delta = width - dataItem.DataPoint.Width;
                dataItem.DataPoint.Width = width;
                Canvas.SetLeft(dataItem.Container, Canvas.GetLeft(dataItem.Container) - delta);
            }
        }

        public int IndependentValueCount
        {
            get
            {
                return IndependentValueGroups.Count();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EWAV.Web.EpiDashboard;

namespace EWAV.Web.Services  
{

    public class ListofDescriptiveStatistics
    {
        private List<DescriptiveStatistics> descriptiveStatisticsList;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListofDescriptiveStatistics" /> class.
        /// </summary>
        public ListofDescriptiveStatistics(List<DescriptiveStatistics> descStatsList)
        {
        }

        /// <summary>
        /// Gets or sets the descriptive statistics list.
        /// </summary>
        /// <value>The descriptive statistics list.</value>
        public List<DescriptiveStatistics> DescriptiveStatisticsList
        {
            get
            {
                return this.descriptiveStatisticsList;
            }
            set
            {
                this.descriptiveStatisticsList = value;
            }
        }
    }
}
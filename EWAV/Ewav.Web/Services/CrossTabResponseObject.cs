using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EWAV.Web.EpiDashboard;

namespace EWAV.Web.Services
{
    public class CrossTabResponseObjectDto
    {
        public CrossTabResponseObjectDto()
        {
            columnNames = new List<string>();
            dsList = new List<DescriptiveStatistics>();
        }

        private List<string> columnNames;

        public List<string> ColumnNames
        {
            get { return columnNames; }
            set { columnNames = value; }
        }

        private List<DescriptiveStatistics> dsList;

        public List<DescriptiveStatistics> DsList
        {
            get { return dsList; }
            set { dsList = value; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CDC.ISB.EIDEV.Web.EpiDashboard;

namespace CDC.ISB.EIDEV.Web.Services
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
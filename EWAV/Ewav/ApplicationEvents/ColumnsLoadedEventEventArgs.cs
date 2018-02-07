using System;
using System.Collections.Generic;
using EWAV.BAL;

namespace EWAV.Client.Application
{
    public class ColumnsLoadedEventEventArgs : EventArgs
    {
        private List<EWAVColumn> columnList;
  
        public ColumnsLoadedEventEventArgs(List<EWAVColumn> cols)
        {
            ColumnList = cols;
        }

        public List<EWAVColumn> ColumnList
        {
            get
            {
                return columnList;
            }
            set
            {
                columnList = value;
            }
        }
    }
}
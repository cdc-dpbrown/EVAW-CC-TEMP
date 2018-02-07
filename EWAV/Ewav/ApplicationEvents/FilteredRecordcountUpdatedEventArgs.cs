
using System;

namespace EWAV.Client.Application
{
    public class FilteredRecordcountUpdatedEventArgs : EventArgs
    {
        private long filteredRecordcount;
    
        public FilteredRecordcountUpdatedEventArgs(long filteredRecordCount)
        {
            FilteredRecordcount = filteredRecordCount;
        }

        public long FilteredRecordcount
        {
            get
            {
                return filteredRecordcount;
            }
            set
            {
                filteredRecordcount = value;
            }
        }
    }
}
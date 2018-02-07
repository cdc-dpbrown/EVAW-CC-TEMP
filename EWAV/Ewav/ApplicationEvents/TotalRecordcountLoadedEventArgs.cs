
using System;

namespace EWAV.Client.Application
{
    public class TotalRecordcountLoadedEventArgs : EventArgs
    {
        private long totalRecordcount;

        public long Recordcount
        {
            get { return totalRecordcount; }
            set { totalRecordcount = value; }
        }


        public TotalRecordcountLoadedEventArgs(long recordCount)
        {
            Recordcount = recordCount;
        }

    }
}
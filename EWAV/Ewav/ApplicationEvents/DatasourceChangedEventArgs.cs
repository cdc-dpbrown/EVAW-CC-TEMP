
using System;
namespace EWAV.Client.Application
{
    public class DatasourceChangedEventArgs : EventArgs
    {
        private int dataSource;

        public DatasourceChangedEventArgs(int dataSource)
        {
            DataSource = dataSource;
        }  

        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        /// <value>The data source.</value>
        public int DataSource
        {
            get
            {
                return this.dataSource;
            }
            set
            {
                this.dataSource = value;
            }
        }

    }
}
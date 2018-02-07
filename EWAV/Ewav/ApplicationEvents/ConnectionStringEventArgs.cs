using System;
using EWAV.Web.Services;
using EWAV.BAL;

namespace EWAV.Client.Application
{
    public class ConnectionStringEventArgs : EventArgs
    {
        private EWAVDatasourceDto ewavConnectionInfo;

        private string tableName;

        private string datasourceName;

        public ConnectionStringEventArgs(EWAVDatasourceDto  ewc)
        {
            ewavConnectionInfo = ewc;
        }

        /// <summary>
        /// Gets or sets the ewav connection info.
        /// </summary>
        /// <value>The ewav connection info.</value>

        public EWAVDatasourceDto EWAVConnectionInfo
        {
            get
            {
                return this.ewavConnectionInfo;
            }

        }
    }
}
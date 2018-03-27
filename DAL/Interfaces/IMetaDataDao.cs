using System;
using System.Data;
using System.Linq;
using CDC.ISB.EIDEV.DTO;

namespace CDC.ISB.EIDEV.DAL.Interfaces
{
    public interface IMetaDataDao
    {
        /// <summary>
        /// Gets or sets the meta data connection string.
        /// </summary>
        /// <value>The meta data connection string.</value>
        string MetaDataConnectionString { get; set; }
        /// <summary>
        /// Gets or sets the name of the meta data view.
        /// </summary>
        /// <value>The name of the meta data view.</value>
        string MetaDataViewName { get; set; }


        /// <summary>
        /// Gets all available data sources
        /// </summary>
        /// <returns>A data table with one row of meta data for each data source</returns>
        System.Data.DataTable GetAllDataSources(string userName);

        /// <summary>
        /// Gets the columns for datasource.
        /// </summary>
        /// <returns></returns>
        DataTable GetColumnsForDatasource(string dataSourceName);

        //    string GetExternalConnectionString(string dataSourceName, out  string tableName, out     DataBaseTypeEnum databaseType);

        //string ConnectionString;
        //string MetaDataViewName;

        /// <summary>
        /// Gets the type of the database.
        /// </summary>
        /// <param name="dataSourceName">Name of the data source.</param>
        /// <returns></returns>
        DataBaseTypeEnum GetDatabaseType(string dataSourceName);

        /// <summary>
        /// Gets the external connection string to retrieve data for analysis.  Not to je confused with the 
        /// metadata Connection string which is used to connect to the EWAV database    
        /// </summary>
        /// <param name="dataSourceName">Name of the data source.</param>
        string GetExternalConnectionString(string dataSourceName, out string tableName);

        /// <summary>
        /// Gets the external connection string to retrieve data for analysis.  Not to je confused with the 
        /// metadata Connection string which is used to connect to the EWAV database    
        /// </summary>
        /// <param name="dataSourceName">Name of the data source.</param>
        /// <returns></returns>
        string GetExternalConnectionString(string dataSourceName);

        /// <summary>
        /// This method was written to get EWAVLite DataObject. 
        /// </summary>
        /// <param name="datasourceName"></param>
        /// <returns></returns>
        string GetDatabaseObject(string datasourceName);
    }

 
}
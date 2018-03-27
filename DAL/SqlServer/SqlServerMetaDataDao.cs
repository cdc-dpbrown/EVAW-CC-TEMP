using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CDC.ISB.EIDEV.DAL.Interfaces;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using CDC.ISB.EIDEV.DTO;

namespace CDC.ISB.EIDEV.DAL.SqlServer
{
    public class SqlServerMetaDataDao : IMetaDataDao
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerMetaDataDao" /> class.
        /// </summary>
        /// <param name="ConnectionString">The meta data connection string.</param>
        /// <param name="MetaDataViewName">Name of the meta data view.</param>
        public SqlServerMetaDataDao(string MetaDataConnectionString, string MetaDataViewName)
        {
            this.MetaDataConnectionString = MetaDataConnectionString;
            this.MetaDataViewName = MetaDataViewName;
        }

        public SqlServerMetaDataDao()
        {
        }

        /// <summary>
        /// Gets or sets the meta data connection string.
        /// </summary>
        /// <value>The meta data connection string.</value>
        public string MetaDataConnectionString { get; set; }
        /// <summary>
        /// Gets or sets the name of the meta data view.
        /// </summary>
        /// <value>The name of the meta data view.</value>
        public string MetaDataViewName { get; set; }
        /// <summary>
        /// Gets all available data sources
        /// </summary>
        /// <returns>A data table with one row of meta data for each data source</returns>
        public DataTable GetAllDataSources(string userName)
        {
            SqlConnection conn = new SqlConnection(this.MetaDataConnectionString);

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_read_all_datasources";
            command.Parameters.Add(new SqlParameter("UserName", userName));
            command.Parameters.Add(new SqlParameter("DatabaseObject", this.MetaDataViewName));
            command.Connection = conn;
            // create a new data adapter based on the specified query.
            SqlDataAdapter da = new SqlDataAdapter();
            //set the SelectCommand of the adapter
            da.SelectCommand = command;
            // create a new DataTable
            DataTable dtGet = new DataTable();
            //fill the DataTable
            da.Fill(dtGet);
            //return the DataTable

            return dtGet;
        }

        /// <summary>
        /// Gets the columns for datasource.
        /// </summary>
        /// <param name="dataSourceName"></param>
        /// <returns></returns>
        public DataTable GetColumnsForDatasource(string dataSourceName)
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the type of the database.
        /// </summary>
        /// <param name="dataSourceName">Name of the data source.</param>
        /// <returns></returns>
        public DataBaseTypeEnum GetDatabaseType(string dataSourceName)
        {
            SqlDatabase ewavDB = new SqlDatabase(this.MetaDataConnectionString);
            DataTable dtGet = ewavDB.ExecuteDataSet("usp_read_database_type", dataSourceName, this.MetaDataViewName).Tables[0];

            return 
            (
                (DataBaseTypeEnum)Enum.Parse(typeof(DataBaseTypeEnum), dtGet.Rows[0]["DatabaseType"].ToString())
            );
        }

        /// <summary>
        /// Gets the external connection string to retrieve data for analysis.  Not to je confused with the 
        /// metadata Connection string which is used to connect to the EWAV database    
        /// </summary>
        /// <param name="dataSourceName">Name of the data source.</param>
        /// <returns></returns>
        public string GetExternalConnectionString(string dataSourceName)
        {
            SqlDatabase ewavDB = new SqlDatabase(this.MetaDataConnectionString);

            DataTable dtExternal = ewavDB.ExecuteDataSet("usp_read_external_connec_str", this.MetaDataViewName, dataSourceName).Tables[0];

            DataBaseTypeEnum dataBaseTypeEnum = ((DataBaseTypeEnum)Enum.Parse(typeof(DataBaseTypeEnum),
                dtExternal.Rows[0]["DatabaseType"].ToString()));

            string extConnectionString = " ";

            extConnectionString = Utilities.CreateConnectionString(dataBaseTypeEnum, new DataRow[] { dtExternal.Rows[0] });

            return extConnectionString;
        }

        /// <summary>
        /// Gets the database object for EWAVLite  
        /// </summary>
        /// <param name="dataSourceName">Name of the data source.</param>
        /// <returns></returns>
        public string GetDatabaseObject(string dataSourceName)
        {
            SqlDatabase ewavDB = new SqlDatabase(this.MetaDataConnectionString);

            DataTable dtExternal = ewavDB.ExecuteDataSet("usp_read_external_connec_str", this.MetaDataViewName, dataSourceName).Tables[0];

            return dtExternal.Rows[0]["DatabaseObject"].ToString();
        }

        /// <summary>
        /// Gets the external connection string.
        /// </summary>
        /// <param name="dataSourceName">Name of the data source.</param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public string GetExternalConnectionString(string dataSourceName, out string tableName)  //     out    DataBaseTypeEnum databaseType)
        {
            throw new NotImplementedException();
        }

        public void SaveCanvas(CanvasDto canvasDto)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Data;
using System.Linq;
using CDC.ISB.EIDEV.DAL.Interfaces;
using CDC.ISB.EIDEV.Security;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using CDC.ISB.EIDEV.DTO;

namespace CDC.ISB.EIDEV.DAL.MySqlLayer
{
    public class MySqlDatasourceDao : IAdminDatasourceDao
    {
        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>The name of the table.</value>
        public string TableName { get; set; }

        /// <summary>
        /// Copies the saved canvas to different datasource
        /// </summary>
        /// <param name="OldCanvasName"></param>
        /// <param name="NewCanvasName"></param>
        /// <param name="OldDatasourceId"></param>
        /// <param name="NewDatasourceId"></param>
        /// <returns></returns>
        public bool CopyDashboard(string OldCanvasName, string NewCanvasName,  string NewDatasourceName)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the datasource.
        /// </summary>
        /// <param name="datasourceId">The datasource id.</param>
        /// <returns></returns>
        public DataSet GetDatasource(int datasourceId)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the datasource.
        /// </summary>
        /// <param name="dsDto">The ds dto.</param>
        /// <returns></returns>
        public bool AddDatasource(DTO.DatasourceDto dsDto)
        {
            MySqlConnection mySqlConn = new MySqlConnection(this.ConnectionString);

            mySqlConn.Open();

            MySqlCommand addDSCommand = mySqlConn.CreateCommand();
            MySqlCommand addUserDSCommand = mySqlConn.CreateCommand();

            int dsId = -1;

            addDSCommand.CommandType = System.Data.CommandType.StoredProcedure;

            addDSCommand.CommandText = "usp_add_datasource"; //TBD

            Cryptography cy = new Cryptography();

            addDSCommand.Parameters.AddWithValue("DatasourceNameArg", dsDto.DatasourceName);
            addDSCommand.Parameters.AddWithValue("OrganizationId", dsDto.OrganizationId);
            addDSCommand.Parameters.AddWithValue("DatasourceServerName", cy.Encrypt(dsDto.Connection.ServerName));
            addDSCommand.Parameters.AddWithValue("DatabaseType", dsDto.Connection.DatabaseType.ToString());
            addDSCommand.Parameters.AddWithValue("InitialCatalog", cy.Encrypt(dsDto.Connection.DatabaseName));
            addDSCommand.Parameters.AddWithValue("PersistSecurityInfo", dsDto.Connection.PersistSecurityInfo.ToString());
            addDSCommand.Parameters.AddWithValue("DatabaseUserID", cy.Encrypt(dsDto.Connection.UserId));
            addDSCommand.Parameters.AddWithValue("Password", cy.Encrypt(dsDto.Connection.Password));
            addDSCommand.Parameters.AddWithValue("DatabaseObject", cy.Encrypt(dsDto.Connection.DatabaseObject));
            addDSCommand.Parameters.AddWithValue("SQLQuery", dsDto.SQLQuery());

            addDSCommand.Parameters.AddWithValue("active", dsDto.IsActive);

            addDSCommand.Parameters.AddWithValue("@DatasourceUser", SqlDbType.Structured);
            addDSCommand.Parameters["@DatasourceUser"].Direction = ParameterDirection.Input;

            addDSCommand.Parameters.AddWithValue("portnumber", cy.Encrypt(dsDto.Connection.PortNumber));

            try
            {
                string assUsers = "";
                string datasourceID = "";

                foreach (CDC.ISB.EIDEV.DTO.UserDTO item in dsDto.AssociatedUsers)
                {
                    assUsers += string.Format("{0},", item.UserID.ToString());
                    datasourceID += string.Format("{0},", dsDto.DatasourceId.ToString());
                }


                addDSCommand.Parameters.AddWithValue("datasource_ids", datasourceID);
                addDSCommand.Parameters.AddWithValue("user_ids", assUsers);
            }
            catch (Exception  ex  ) 
            {
                throw new Exception(ex.Message);
            }

            try
            {
                dsId = Convert.ToInt32(addDSCommand.ExecuteScalar());
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// Gets the columns for the table or view for a datasource.
        /// </summary>
        /// <returns></returns>
        public DataTable GetColumnsForDatasource()
        {
            DataSet ds = null;
            //  SqlDatabase db = new SqlDatabase(ConnectionString);
            try
            {
                ds = MySql.Data.MySqlClient.MySqlHelper.ExecuteDataset(ConnectionString,
                    string.Format("select   *  from {0} limit 1 ", TableName));
            }
            catch (MySql.Data.MySqlClient.MySqlException sqlEx)
            {
                Exception duplicateException = new Exception(string.Format("SQL Exception - {0}", sqlEx.Message));
                throw duplicateException;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ds.Tables[0];
        }

        /// <summary>
        /// Gets the connection string from DB.
        /// </summary>
        /// <param name="DsName">Name of the ds.</param>
        /// <param name="ConnectionString">The connection string.</param>
        /// <returns></returns>
        public string GetConnectionStringFromDB(string DsName, string ConnectionString)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads the users that are part of a organization
        /// </summary>
        /// <param name="orgId">The org id.</param>
        /// <returns></returns>
        public System.Data.DataSet ReadAssociatedUsers(int orgId)
        {
            DataSet ds = null;

            try
            {
                //ds = MySqlUtilities.ExecuteSimpleDatsetFromStoredProc(connectionString, "usp_read_user",
                //         new string[] { orgId.ToString(), "-1", "null", "-1", dsID.ToString() });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ds;
        }


        /// <summary>
        /// Reads the users that are part of a organization and have access to a particular datasource
        /// </summary>
        /// <param name="dsID">The datasource ID.</param>
        /// <param name="orgId">The organization id.</param>
        /// <returns></returns>
        public DataSet ReadAssociatedUsersForDatasource(int dsID, int orgId)
        {
            DataSet ds = null;

            try
            {
                ds = MySqlUtilities.ExecuteSimpleDatsetFromStoredProc(ConnectionString, "usp_read_users_for_datasource",
                    orgId.ToString(), dsID.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ds;
        }

        public System.Data.DataSet ReadDatasource(int orgId)
        {
            DataSet ds = null;

            try
            {
                ds = MySqlUtilities.ExecuteSimpleDatsetFromStoredProc(ConnectionString, "usp_read_datasource",
                    new string[] { orgId.ToString(), "-1" });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ds;
        }

        public bool RemoveDatasource(int dsId)
        {
            return false;
        }

        public bool TestData(string sqlOrTableName)
        {
            try
            {
                MySql.Data.MySqlClient.MySqlHelper.ExecuteScalar(this.ConnectionString, string.Format("Select Count(*) from {0}", sqlOrTableName));
                int i = Convert.ToInt32(MySql.Data.MySqlClient.MySqlHelper.ExecuteScalar(this.ConnectionString, string.Format("Select Count(*) from {0}", sqlOrTableName)));

                if (i <= 0)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                //throw;
            }
            return true;
        }

        public bool TestDBConnection(string connStr)
        {
            MySql.Data.MySqlClient.MySqlConnection sqlConn = new MySql.Data.MySqlClient.MySqlConnection(this.ConnectionString);

            try
            {
                sqlConn.Open();
                sqlConn.Close();
                return true;
            }
            catch (Exception)
            {
                sqlConn.Close();
                sqlConn = null;
                return false;
            }
        }

        public bool UpdateDatasource(DTO.DatasourceDto dsDto)
        {
            MySqlConnection mySqlConn = new MySqlConnection(this.ConnectionString);

            mySqlConn.Open();

            MySqlCommand addDSCommand = mySqlConn.CreateCommand();
            MySqlCommand addUserDSCommand = mySqlConn.CreateCommand();

            addDSCommand.CommandType = System.Data.CommandType.StoredProcedure;

            addDSCommand.CommandText = "usp_update_datasource";

            Cryptography cy = new Cryptography();

            addDSCommand.Parameters.AddWithValue("DatasourceNameArg", dsDto.DatasourceName);
            addDSCommand.Parameters.AddWithValue("DatabaseType", dsDto.Connection.DatabaseType.ToString());
            addDSCommand.Parameters.AddWithValue("PersistSecurityInfo", dsDto.Connection.PersistSecurityInfo.ToString());
            addDSCommand.Parameters.AddWithValue("InitialCatalog", cy.Encrypt(dsDto.Connection.DatabaseName));
            addDSCommand.Parameters.AddWithValue("DatasourceServerName", cy.Encrypt(dsDto.Connection.ServerName));
            addDSCommand.Parameters.AddWithValue("DatabaseUserID", cy.Encrypt(dsDto.Connection.UserId));
            addDSCommand.Parameters.AddWithValue("Password", cy.Encrypt(dsDto.Connection.Password));
            addDSCommand.Parameters.AddWithValue("DatabaseObject", cy.Encrypt(dsDto.Connection.DatabaseObject));
            addDSCommand.Parameters.AddWithValue("DatasourceID", dsDto.DatasourceId);

            addDSCommand.Parameters.AddWithValue("active", dsDto.IsActive);

            try
            {
                string assUsers = "";
                string datasourceID = "";

                foreach (CDC.ISB.EIDEV.DTO.UserDTO item in dsDto.AssociatedUsers)
                {
                    assUsers += string.Format("{0},", item.UserID.ToString());
                    datasourceID += string.Format("{0},", dsDto.DatasourceId.ToString());
                }
            }
            catch (Exception)
            {
            }

            try
            {
                int dsId = Convert.ToInt32(addDSCommand.ExecuteScalar());
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public object ReadEWEDatasourceFormId(DTO.EWEDatasourceDto EWEDsDto)
        {
            
            throw new NotImplementedException("Functionality is not supported for underlying database type.");
        }

        public DataSet ReadAllDatasourceUsers()
        {
            throw new NotImplementedException();
        }


    }
}
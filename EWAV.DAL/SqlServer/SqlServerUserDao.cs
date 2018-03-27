namespace CDC.ISB.EIDEV.DAL.SqlServer
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using CDC.ISB.EIDEV.DAL.Interfaces;
    using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
    using CDC.ISB.EIDEV.DTO;
    using System.Collections.Generic;
    using Microsoft.SqlServer.Server;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SqlServerUserDao : IUserDao
    {
        public string ConnectionString { get; set; }
        public string TableName { get; set; }
        /// <summary>
        /// Reads the users for organization id.
        /// </summary>
        /// <param name="organizationId">The organization id.</param>
        /// <returns></returns>
        public DataTable ReadAdminsForOrganizationId(int organizationId)
        {

            //SqlDatabase db = new SqlDatabase(ConnectionString);
            //string query = string.Format(
            //    "SELECT  *   FROM  [User]        WHERE    (  organizationId =  {0}  and RoleId  =  2    )  ", organizationId);

            //try
            //{
            //    DataSet ds = db.ExecuteDataSet(CommandType.Text, query);
            //    return ds.Tables[0];
            //}
            //catch (SqlException sqlEx)
            //{
            //    Exception duplicateException = new Exception(string.Format("SQL Exception - {0}", sqlEx.Message));
            //    throw duplicateException;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}

            DataSet ds = null;
            SqlDatabase db = new SqlDatabase(ConnectionString);
            try
            {
                ds = db.ExecuteDataSet("usp_read_admins", organizationId);
            }
            catch (SqlException sqlEx)
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

        public DataTable GetUserForAuthentication(string userName, string passwordHash)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            //string query = string.Format(
            //    "SELECT  *   FROM  [User] WHERE    ( UserName = '{0}'  ) AND    ( PasswordHash =  '{1}'    )  ", userName, passwordHash);

            Guid UGuid;
            if (Guid.TryParse(userName, out UGuid))
            {
                try
                {
                    DataSet ds = db.ExecuteDataSet("usp_read_user_bypass_authentication", UGuid);
                    return ds.Tables[0];
                }
                catch (SqlException sqlEx)
                {
                    Exception duplicateException = new Exception(string.Format("SQL Exception - {0}", sqlEx.Message));
                    throw duplicateException;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                try
                {
                    DataSet ds = db.ExecuteDataSet("usp_read_user_for_authentication", userName, passwordHash);
                    return ds.Tables[0];
                }
                catch (SqlException sqlEx)
                {
                    Exception duplicateException = new Exception(string.Format("SQL Exception - {0}", sqlEx.Message));
                    throw duplicateException;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }


        public DataTable LoadUser(string userName)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            //string query = string.Format(
            //    "SELECT  UserId   FROM   [User]  WHERE    ( UserName = '{0}'  )  ", userName);
            //DataSet ds = db.ExecuteDataSet(CommandType.Text, query);

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    string UserId = ds.Tables[0].Rows[0]["UserId"].ToString();
            //    query = "Select *, (Select Count(*) from DatasourceUser where DatasourceUser.UserId = " + UserId + ") as DatasourceCount from vwUserOrganizationUser where vwUserOrganizationUser.UserId = " + UserId + "  and Active = 'True' and IsorgActive = 'True' ";
            //}
            DataSet ds = null;
            try
            {
                ds = db.ExecuteDataSet("usp_load_user", userName);
                return ds.Tables[0];
            }
            catch (SqlException sqlEx)
            {
                Exception duplicateException = new Exception(string.Format("SQL Exception - {0}", sqlEx.Message));
                throw duplicateException;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public bool AddUser(UserOrganizationDto dto)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);

            UserDTO User = dto.User;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand addUserCommand = connection.CreateCommand();

                addUserCommand.CommandType = CommandType.StoredProcedure;
                addUserCommand.CommandText = "usp_add_user";

                addUserCommand.Parameters.AddWithValue("UserName", User.UserName);
                addUserCommand.Parameters.AddWithValue("FirstName", User.FirstName);
                addUserCommand.Parameters.AddWithValue("LastName", User.LastName);
                addUserCommand.Parameters.AddWithValue("EmailAddress", User.Email);
                addUserCommand.Parameters.AddWithValue("PhoneNumber", User.Phone);
                addUserCommand.Parameters.AddWithValue("PasswordHash", User.PasswordHash);
                addUserCommand.Parameters.AddWithValue("ResetPassword", User.ShouldResetPassword);

                if (User.IsExistingUser)
                {
                    addUserCommand.Parameters.AddWithValue("UsrId", User.UserID);
                }
                else
                {
                    addUserCommand.Parameters.AddWithValue("UsrId", -1);
                }

                addUserCommand.Parameters.AddWithValue("OrganizationId", dto.Organization.Id);
                addUserCommand.Parameters.AddWithValue("RoleId", dto.RoleId);
                addUserCommand.Parameters.AddWithValue("Active", dto.Active);

                addUserCommand.Parameters.AddWithValue("UGuid", Guid.NewGuid());

                addUserCommand.Parameters.AddWithValue("@DatasourceUser", SqlDbType.Structured);
                addUserCommand.Parameters["@DatasourceUser"].Direction = ParameterDirection.Input;
                addUserCommand.Parameters["@DatasourceUser"].TypeName = "DatasourceUserTableType";

                List<SqlDataRecord> sqlDrList = new List<SqlDataRecord>();
                SqlDataRecord sqdr;

                foreach (DatasourceDto item in User.DatasourceList)
                {
                    sqdr = new SqlDataRecord(new SqlMetaData[] 
                    { new SqlMetaData("DatasourceID", SqlDbType.Int ), 
                       new SqlMetaData("UserID", SqlDbType.Int)      
                    });
                    
                    sqdr.SetInt32(0, item.DatasourceId);
                    sqdr.SetInt32(1, 0);
                    sqlDrList.Add(sqdr);
                }


                if (User.DatasourceList.Count == 0)
                    addUserCommand.Parameters["@DatasourceUser"].Value = null;
                else
                    addUserCommand.Parameters["@DatasourceUser"].Value = sqlDrList;

                try
                {
                    addUserCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }

            return true;
        }

        public bool UpdateUser(UserOrganizationDto dto)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            //SqlTransaction sqlTran = null;
            //int flag = -1;
            UserDTO User = dto.User;
            OrganizationDto Organization = dto.Organization;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand updUsercommand = connection.CreateCommand();

                if (User.UserEditType == UserEditType.EditingUserInfo)
                {
                    updUsercommand.CommandType = CommandType.StoredProcedure;
                    updUsercommand.CommandText = "usp_update_user";
                    updUsercommand.Parameters.AddWithValue("FirstName", User.FirstName);
                    updUsercommand.Parameters.AddWithValue("LastName", User.LastName);
                    updUsercommand.Parameters.AddWithValue("EmailAddress", User.Email);
                    updUsercommand.Parameters.AddWithValue("PhoneNumber", User.Phone);
                    updUsercommand.Parameters.AddWithValue("UserId", User.UserID);
                    updUsercommand.Parameters.AddWithValue("OrganizationId", dto.Organization.Id);
                    updUsercommand.Parameters.AddWithValue("IsUserOrgActive", dto.Active);
                    updUsercommand.Parameters.AddWithValue("RoleId", dto.RoleId);

                    updUsercommand.Parameters.Add("@DatasourceUser", SqlDbType.Structured);
                    updUsercommand.Parameters["@DatasourceUser"].Direction = ParameterDirection.Input;
                    updUsercommand.Parameters["@DatasourceUser"].TypeName = "DatasourceUserTableType";

                    List<SqlDataRecord> sqlDrList = new List<SqlDataRecord>();
                    SqlDataRecord sqdr;
                    
                    foreach (DatasourceDto item in User.DatasourceList)
                    {
                        sqdr = new SqlDataRecord(new SqlMetaData[] 
                    { new SqlMetaData("DatasourceID", SqlDbType.Int ), 
                       new SqlMetaData("UserID", SqlDbType.Int)      
                    });

                        sqdr.SetInt32(0, item.DatasourceId);
                        sqdr.SetInt32(1, User.UserID);

                        sqlDrList.Add(sqdr);
                    }


                    if (User.DatasourceList.Count == 0)
                        updUsercommand.Parameters["@DatasourceUser"].Value = null;
                    else
                        updUsercommand.Parameters["@DatasourceUser"].Value = sqlDrList;

                }
                else
                {
                    updUsercommand.CommandType = CommandType.StoredProcedure;
                    updUsercommand.CommandText = "usp_update_password";
                    updUsercommand.Parameters.AddWithValue("UserId", User.UserID);
                    updUsercommand.Parameters.AddWithValue("HashedPassword", User.PasswordHash);

                }
                try
                {
                    updUsercommand.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }

                return true;
            }

        }

        public bool RemoveUser(int userId)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            int flag = 0;
            try
            {
                flag = Convert.ToInt32(db.ExecuteScalar("usp_delete_user", userId));
            }
            catch (SqlException sqlEx)
            {
                Exception duplicateException = new Exception(string.Format("SQL Exception - {0}", sqlEx.Message));
                throw duplicateException;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (flag == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public DataSet GetUser(int userid)
        {
            DataSet ds = null;
            SqlDatabase db = new SqlDatabase(ConnectionString);
            try
            {
                ds = db.ExecuteDataSet(CommandType.Text, "select * from  [user]  where  userid = " + userid);
            }
            catch { }

            return ds;
        }

        public DataSet ReadUser(int roleid, int organizationId)
        {
            DataSet ds = null;
            SqlDatabase db = new SqlDatabase(ConnectionString);


            try
            {
                ds = db.ExecuteDataSet("usp_read_user", organizationId, -1, " ", roleid);
            }
            catch (SqlException sqlEx)
            {
                Exception duplicateException = new Exception(string.Format("SQL Exception - {0}", sqlEx.Message));
                throw duplicateException;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ds;
        }


        public bool ForgotPasswod(string email, string hashedPwd)
        {
            SqlDatabase db = new SqlDatabase(ConnectionString);
            DataSet ds = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();


                SqlCommand readUserComman = connection.CreateCommand();
                SqlCommand updateUserCommand = connection.CreateCommand();

                try
                {
                    readUserComman.CommandType = CommandType.StoredProcedure;
                    readUserComman.CommandText = "usp_read_user";
                    readUserComman.Parameters.AddWithValue("orgid", -1);
                    readUserComman.Parameters.AddWithValue("userid", -1);
                    readUserComman.Parameters.AddWithValue("email", email);
                    readUserComman.Parameters.AddWithValue("roleid", -1);

                    ds = db.ExecuteDataSet(readUserComman);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        updateUserCommand = connection.CreateCommand();

                        try
                        {
                            updateUserCommand.CommandType = CommandType.StoredProcedure;
                            updateUserCommand.CommandText = "usp_forgot_password";
                            updateUserCommand.Parameters.AddWithValue("EmailAddress", ds.Tables[0].Rows[0]["EMAILADDRESS"]);
                            updateUserCommand.Parameters.AddWithValue("HashedPassword", hashedPwd);
                            updateUserCommand.ExecuteNonQuery();
                        }
                        catch (SqlException sqlEx)
                        {
                            Exception duplicateException = new Exception(string.Format("SQL Exception - {0}", sqlEx.Message));
                            // sqlTran.Rollback();
                            throw duplicateException;
                        }
                        catch (Exception ex)
                        {
                            //sqlTran.Rollback();
                            throw new Exception(ex.Message);
                        }

                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    //sqlTran.Rollback();
                    throw new Exception(e.Message);
                }

                return true;
            }
        }


        public DataSet ReadAssociatedDatasources(int UserId, int OrganizationId)
        {
            DataSet ds = null;
            SqlDatabase db = new SqlDatabase(ConnectionString);
            try
            {
                ds = db.ExecuteDataSet("usp_read_datasource", OrganizationId, UserId);//TBD
            }
            catch (SqlException sqlEx)
            {
                Exception duplicateException = new Exception(string.Format("SQL Exception - {0}", sqlEx.Message));
                throw duplicateException;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ds;
        }


        public DataSet ReadUserNames()
        {
            DataSet ds = null;

            SqlDatabase db = new SqlDatabase(ConnectionString);
            try
            {
                ds = db.ExecuteDataSet("usp_read_usernames");
            }
            catch (SqlException sqlEx)
            {
                Exception duplicateException = new Exception(string.Format("SQL Exception - {0}", sqlEx.Message));
                throw duplicateException;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ds;

        }


        public DataSet ReadUserByUserName(string UserName)
        {
            DataSet ds = null;

            SqlDatabase db = new SqlDatabase(ConnectionString);
            try
            {
                //ds = db.ExecuteDataSet(CommandType.Text, "select * from [User] left join UserOrganization on [User].UserId = UserOrganization.UserId Where UserName = '" + UserName + "'");
                ds = db.ExecuteDataSet("usp_read_by_username", UserName);
            }
            catch (SqlException sqlEx)
            {
                Exception duplicateException = new Exception(string.Format("SQL Exception - {0}", sqlEx.Message));
                throw duplicateException;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ds;
        }

        public DataTable ReadAllOrgsForUser(int userID)
        {

            DataSet ds = null;

            SqlDatabase db = new SqlDatabase(ConnectionString);
            try
            {
                //ds = db.ExecuteDataSet(CommandType.Text, "Select * From   vwOrgsforUser  Where RoleId > 1 AND UserId  =  " + userID + " AND Active = 1 AND IsOrgActive = 1");
                ds = db.ExecuteDataSet("usp_read_all_organization_for_user", userID);
            }
            catch (SqlException sqlEx)
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
        /// Reads the super admin from ewav.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public string ReadSuperAdminFromEWAV()
        {
            DataSet ds = null;

            SqlDatabase db = new SqlDatabase(ConnectionString);
            try
            {
                //ds = db.ExecuteDataSet(CommandType.Text, "Select TOP 1 EmailAddress From vwUserOrganizationuser Where RoleID = 4 ");
                ds = db.ExecuteDataSet("usp_read_super_admin_from_ewav");
            }
            catch (SqlException sqlEx)
            {
                Exception duplicateException = new Exception(string.Format("SQL Exception - {0}", sqlEx.Message));
                throw duplicateException;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ds.Tables[0].Rows[0][0].ToString();
        }
    }
}
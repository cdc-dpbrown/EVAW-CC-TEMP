namespace EWAV.DAL.MySqlLayer
{
    using System;
    using System.Data;
    using System.Linq;
    using EWAV.DAL.Interfaces;
    using EWAV.DTO;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class MySqlUserDao : IUserDao
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
        /// Gets the user.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns></returns>
        public DataSet GetUser(int userid)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public bool AddUser(UserOrganizationDto dto)
        {
            //      SqlDatabase db = new SqlDatabase(ConnectionString);
            UserDTO User = dto.User;

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                MySqlCommand addUserCommand = connection.CreateCommand();

                addUserCommand.CommandType = CommandType.StoredProcedure;
                addUserCommand.CommandText = "usp_add_user";

                addUserCommand.Parameters.AddWithValue("UserNameArg", User.UserName);
                addUserCommand.Parameters.AddWithValue("FirstName", User.FirstName);
                addUserCommand.Parameters.AddWithValue("LastName", User.LastName);
                addUserCommand.Parameters.AddWithValue("EmailAddressArg", User.Email);
                addUserCommand.Parameters.AddWithValue("PhoneNumber", User.Phone);
                addUserCommand.Parameters.AddWithValue("PasswordHash", User.PasswordHash);
                addUserCommand.Parameters.AddWithValue("ResetPassword", User.ShouldResetPassword);
                //addUserCommand.Parameters.AddWithValue("IsExistingUser", User.IsExistingUser);

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

                addUserCommand.Parameters.AddWithValue("@DatasourceUser", SqlDbType.Structured);
                addUserCommand.Parameters["@DatasourceUser"].Direction = ParameterDirection.Input;

                try
                {
                    addUserCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                int defaultUserId = 0;

                try
                {
                    foreach (DatasourceDto item in User.DatasourceList)
                    {
                        MySqlHelper.ExecuteNonQuery(ConnectionString, "call usp_add_datasourceuser ",
                            new MySqlParameter[]
                        {
                            new MySqlParameter("DatasourceId", item.DatasourceId),
                            new MySqlParameter("UserId", defaultUserId)
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return true;
            }
        }

        public bool ForgotPasswod(string email, string hashedPwd)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <param name="passwordHash">The password hash.</param>
        /// <returns></returns>
        public DataTable GetUserForAuthentication(string userName, string passwordHash)
        {
            try
            {
                DataSet ds = MySqlUtilities.ExecuteSimpleDatsetFromStoredProc(ConnectionString, "usp_read_user_for_authentication",
                    userName, passwordHash);

                return ds.Tables[0];
            }
            catch (MySqlException sqlEx)
            {
                Exception duplicateException = new Exception(string.Format("SQL Exception - {0}", sqlEx.Message));
                throw duplicateException;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Loads the user.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        public DataTable LoadUser(string userID)
        {
            DataSet ds;

            string query = string.Format(
                "SELECT  UserId   FROM  User    WHERE    ( UserName = '{0}'  )  ", userID);

            try
            {
                MySqlParameter pa = new MySqlParameter("UserId", userID);
                ds = MySqlHelper.ExecuteDataset(ConnectionString, string.Format(" call usp_load_user (   '{0}'             ) ", userID));

                if (ds.Tables[0].Rows.Count > 0)
                {
                    string UserId = ds.Tables[0].Rows[0]["UserId"].ToString();
                    query = string.Format("Select *, (Select Count(*) from DatasourceUser where DatasourceUser.UserId = {0}) as DatasourceCount from vwUserOrganizationUser where vwUserOrganizationUser.UserId = {1}  and Active =   True  and IsorgActive =  True  ", UserId, UserId);

                    ds = MySqlHelper.ExecuteDataset(ConnectionString, query);
                    return ds.Tables[0];
                }
                else
                {
                    return new DataTable();
                }
            }
            catch (MySqlException sqlEx)
            {
                Exception duplicateException = new Exception(string.Format("SQL Exception - {0}", sqlEx.Message));
                throw duplicateException;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ReadAdminsForOrganizationId(int organizationId)
        {
            throw new NotImplementedException();
        }

        public DataTable ReadAllOrgsForUser(int userID)
        {
            DataSet ds = null;

            try
            {
                //  ds = MySqlHelper.ExecuteDataset(ConnectionString, "Select * From   vwOrgsforUser  Where RoleId > 1 AND UserId  =  " + userID + " AND Active = 1 AND IsOrgActive = 1");
                ds = MySqlUtilities.ExecuteSimpleDatsetFromStoredProc(ConnectionString, "usp_read_all_organization_for_user", userID.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ds.Tables[0];
        }

        public DataSet ReadAssociatedDatasources(int UserId, int OrganizationId)
        {
            DataSet ds = null;

            try
            {
                ds = MySqlUtilities.ExecuteSimpleDatsetFromStoredProc(ConnectionString, "usp_read_datasource",
                    new string[] { OrganizationId.ToString(), UserId.ToString() });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ds;
        }

        public string ReadSuperAdminFromEWAV()
        {
            DataSet ds = null;

            try
            {
                ds = MySqlHelper.ExecuteDataset(ConnectionString, "call  usp_read_super_admin_from_ewav ");
            }
            catch (MySqlException sqlEx)
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

        public DataSet ReadUser(int organizationId)
        {
            throw new NotImplementedException();
        }

        public DataSet ReadUser(int roleid, int organizationId)
        {
            DataSet ds = null;

            try
            {
                ds = MySqlUtilities.ExecuteSimpleDatsetFromStoredProc(ConnectionString, "usp_read_user_with_orgID_roleID",
                    new string[] { organizationId.ToString(), roleid.ToString() });
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

            try
            {
                ds = MySqlUtilities.ExecuteSimpleDatsetFromStoredProc(ConnectionString, "usp_read_by_username", UserName);
            }
            catch (MySqlException sqlEx)
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

            try
            {
                ds = MySqlHelper.ExecuteDataset(ConnectionString, "call  usp_read_usernames  ");         //     Select UserName From User");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ds;
        }

        public bool RemoveUser(int userId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(UserOrganizationDto dto)
        {
            UserDTO User = dto.User;
            OrganizationDto Organization = dto.Organization;

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                MySqlCommand updUsercommand = connection.CreateCommand();

                if (User.UserEditType == UserEditType.EditingUserInfo)
                {
                    updUsercommand.CommandType = CommandType.StoredProcedure;
                    updUsercommand.CommandText = "usp_update_user";
                    updUsercommand.Parameters.AddWithValue("FirstName", User.FirstName);
                    updUsercommand.Parameters.AddWithValue("LastName", User.LastName);
                    updUsercommand.Parameters.AddWithValue("EmailAddressArg", User.Email);
                    updUsercommand.Parameters.AddWithValue("PhoneNumber", User.Phone);
                    updUsercommand.Parameters.AddWithValue("UserId", User.UserID);
                    updUsercommand.Parameters.AddWithValue("OrganizationId", dto.Organization.Id);
                    updUsercommand.Parameters.AddWithValue("IsUserOrgActive", dto.Active);
                    updUsercommand.Parameters.AddWithValue("RoleId", dto.RoleId);

                    string assocUsers = "";
                    string assocDatasources = "";

                    foreach (DatasourceDto item in User.DatasourceList)
                    {
                        assocUsers += string.Format("{0},", User.UserID.ToString());
                        assocDatasources += string.Format("{0},", item.DatasourceId.ToString());
                    }

                    updUsercommand.Parameters.AddWithValue("datasource_ids", assocDatasources);
                    updUsercommand.Parameters.AddWithValue("user_ids", assocUsers);
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
    }
}
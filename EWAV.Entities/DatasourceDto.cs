using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CDC.ISB.EIDEV.DTO
{
    public class DatasourceDto
    {
        private string datasourceServerName;

        public int DatasourceId { get; set; }

        public string DatasourceName { get; set; }

        //public string DatasourceConnectionString { get; set; }


        //public string SqlScript { get; set; }


        public EWAVDatabaseObjectType ewavDatabaseObjectType;


        /// <summary>
        /// Gets or sets the type of the ewav database object.
        /// </summary>
        /// <value>The type of the ewav database object.</value>
        public EWAVDatabaseObjectType EWAVDatabaseObjectType
        {
            get
            {
                return this.ewavDatabaseObjectType;
            }
            set
            {
                this.ewavDatabaseObjectType = value;
            }
        }

        /// <summary>
        /// SQLs the query.
        /// </summary>
        /// <returns></returns>
        public bool SQLQuery()
        {


            return (ewavDatabaseObjectType == DTO.EWAVDatabaseObjectType.SqlScript);

        }

        /// <summary>
        /// Gets or sets the name of the datasource server.
        /// </summary>
        /// <value>The name of the datasource server.</value>
        public string DatasourceServerName
        {
            get
            {
                return this.datasourceServerName;
            }
            set
            {
                this.datasourceServerName = value;
            }
        }

        //public int CreatorID
        //{
        //    get
        //    {
        //        return creatorID;
        //    }
        //    set
        //    {
        //        creatorID = value;
        //    }
        //}

        public List<UserDTO> AssociatedUsers { get; set; }


        public int NumberOfUsers { get; set; }

        public Connection Connection { get; set; }

        public bool IsActive { get; set; }

        public int OrganizationId { get; set; }

        //public string FormId { get; set; }

        private bool _isEpiInfoForm = false;

        public bool IsEpiInfoForm
        {
            get { return _isEpiInfoForm; }
            set { _isEpiInfoForm = value; }
        }
        

        //public string SqlScriptOrTableName { get; set; }

        //public string ServerName { get; set; }

        //public string DatabaseName { get; set; }

        //public DataBaseTypeEnum DatasourceType { get; set; }

        //public string UserId { get; set; }

        //public string Password { get; set; }
    }

    //public enum DatabaseType 
    //{
    //    SqlServer = 0,
    //    MySql
    //}

    public enum EWAVDatabaseObjectType
    {
        Table = 0,
        View,
        SqlScript
    }
}
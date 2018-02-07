using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EWAV.DAL.Interfaces;

namespace EWAV.DAL.PostgreSQL
{
    public class PostgreSQLDaoFactory : IDaoFactory
    {
        private readonly string MetaDataConnectionString;
        private readonly string MetaDataViewName;

        public PostgreSQLDaoFactory(string MetaDataConnectionString, string MetaDataViewName)
        {
            this.MetaDataConnectionString = MetaDataConnectionString;
            this.MetaDataViewName = MetaDataViewName;
        }

        public PostgreSQLDaoFactory(string MetaDataConnectionString)
        {
            this.MetaDataConnectionString = MetaDataConnectionString;
        }

        public PostgreSQLDaoFactory()
        {

        }


        public ICanvasDao CanvasDao
        {
            get { return new PostgreSQLCanvasDao(); }
        }

        public IMetaDataDao MetaDataDao
        {
            get
            {
                if (this.MetaDataConnectionString != null && this.MetaDataViewName != null)
                {
                    return new PostgreSQLMetaDataDao(this.MetaDataConnectionString, this.MetaDataViewName);       //     return new SqlMetaDataDao();
                }
                else
                {
                    throw new ApplicationException();
                }
            }
        }

        public IMetaDataDao MetaDataDaoEmpty
        {
            get
            {

                return new PostgreSQLMetaDataDao();       //     return new SqlMetaDataDao();

            }
        }

        public IRawDataDao RawDataDao
        {
            get
            {
                return new PostgreSQLRawDataDao(this.MetaDataConnectionString, this.MetaDataViewName);
            }
        }

        public IUserDao UserDao
        {
            get { return new PostgreSQLUserDao(); }
        }

        public IOrganizationDao OrganizationDao
        {
            get { return new PostgreSQLOrganizationDao(); }
        }

        public IAdminDatasourceDao AdminDSDao
        {
            get { return new PostgreSQLDatasourceDao(); }
        }
    }
}
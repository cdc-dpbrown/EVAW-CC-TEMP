using System;
using System.Linq;
using CDC.ISB.EIDEV.DAL.Interfaces;
using CDC.ISB.EIDEV.DAL.MySqlLayer;
using CDC.ISB.EIDEV.DAL.SqlServer;
using CDC.ISB.EIDEV.DTO;
using CDC.ISB.EIDEV.DAL.PostgreSQL;

namespace CDC.ISB.EIDEV.DAL
{
    public static class DaoFatories
    {
        /// <summary>
        /// Gets the factory.
        /// </summary>
        /// <param name="dataBaseTypeEnum">The data base type enum.</param>
        /// <param name="MetaDataConnectionString">The meta data connection string.</param>
        /// <param name="MetaDataViewName">Name of the meta data view.</param>
        /// <returns></returns>
        public static IDaoFactory GetFactory(DataBaseTypeEnum dataBaseTypeEnum, string MetaDataConnectionString, string MetaDataViewName)
        {
            switch (dataBaseTypeEnum)
            {
                case DataBaseTypeEnum.MySQL:
                    return new MySqlDaoFactory(MetaDataConnectionString, MetaDataViewName);
                    
                case DataBaseTypeEnum.SQLServer:
                    return new SqlServerDaoFactory(MetaDataConnectionString, MetaDataViewName);

                case DataBaseTypeEnum.PostgreSQL:
                    return new PostgreSQLDaoFactory(MetaDataConnectionString, MetaDataViewName);
                    
                default:
                    throw new ApplicationException(string.Format("Database type {0} is not supported ", dataBaseTypeEnum.ToString()));
            }
        }

        /// <summary>
        /// Gets the factory.
        /// </summary>
        /// <param name="dataBaseTypeEnum">The data base type enum.</param>
        /// <returns></returns>
        public static IDaoFactory GetFactory(DataBaseTypeEnum dataBaseTypeEnum)
        {
            switch (dataBaseTypeEnum)
            {
                case DataBaseTypeEnum.MySQL:
                    return new MySqlDaoFactory();
                case DataBaseTypeEnum.SQLServer:
                    return new SqlServerDaoFactory();
                case DataBaseTypeEnum.PostgreSQL:
                    return new PostgreSQLDaoFactory();
                default:
                    throw new ApplicationException(string.Format("Database type {0} is not supported ", dataBaseTypeEnum.ToString()));
            }
        }
    }
}
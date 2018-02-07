using System;
using System.Linq;
using EWAV.DAL.Interfaces;
using EWAV.DAL.MySqlLayer;
using EWAV.DAL.SqlServer;
using EWAV.DTO;
using EWAV.DAL.PostgreSQL;

// -----------------------------------------------------------------------
// <copyright file="$safeitemrootname$.cs" company="$registeredorganization$">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
namespace EWAV.DAL
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
        public static IDaoFactory GetFactory(DataBaseTypeEnum dataBaseTypeEnum, 
                    string MetaDataConnectionString, string MetaDataViewName)
        {
            switch (dataBaseTypeEnum)
            {
                case DataBaseTypeEnum.MySQL:
                    return new MySqlDaoFactory(MetaDataConnectionString, MetaDataViewName);


                case DataBaseTypeEnum.SQLServer:
                    return new SqlServerDaoFactory(MetaDataConnectionString, MetaDataViewName);

                case DataBaseTypeEnum.PostgreSQL:
                    return new PostgreSQLDaoFactory(MetaDataConnectionString, MetaDataViewName);
                    
                    // default:
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
                    // default:
                default:
                    throw new ApplicationException(string.Format("Database type {0} is not supported ", dataBaseTypeEnum.ToString()));
            }
        }
    }
}
using System;

namespace EWAV.DAL.Interfaces
{
    public interface IDaoFactory
    {
        ICanvasDao CanvasDao { get; }
        IMetaDataDao MetaDataDao { get; }
        IMetaDataDao MetaDataDaoEmpty { get; }
        IRawDataDao RawDataDao { get; }
        /// <summary>
        /// Gets or sets the user DAO.
        /// </summary>
        /// <value>The user DAO.</value>
        IUserDao UserDao { get; }
        IOrganizationDao OrganizationDao { get; }
        IAdminDatasourceDao AdminDSDao { get; }
    }
}
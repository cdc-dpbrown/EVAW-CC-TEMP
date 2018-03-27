using System;

namespace CDC.ISB.EIDEV.DAL.Interfaces
{
    public interface IDaoFactory
    {
        ICanvasDao CanvasDao { get; }
        IMetaDataDao MetaDataDao { get; }
        IMetaDataDao MetaDataDaoEmpty { get; }
        IRawDataDao RawDataDao { get; }
        IUserDao UserDao { get; }
        IOrganizationDao OrganizationDao { get; }
        IAdminDatasourceDao AdminDSDao { get; }
    }
}
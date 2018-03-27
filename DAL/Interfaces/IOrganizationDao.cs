using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CDC.ISB.EIDEV.DTO;
using System.Data;
using CDC.ISB.EIDEV.DTO;

namespace CDC.ISB.EIDEV.DAL.Interfaces
{
    public interface IOrganizationDao
    {
        string ConnectionString { get; set; }

        string TableName { get; set; }

        int AddOrganization(UserOrganizationDto organizationDto);

        bool UpdateOrganization(OrganizationDto dto);

        bool RemoveOrganization(int organzationId);

        DataSet ReadOrganization(int organizationID);          

        DataSet ReadAllOrganizations();  

    }
}
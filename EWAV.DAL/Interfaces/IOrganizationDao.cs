using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EWAV;
using System.Data;
using EWAV.DTO;

namespace EWAV.DAL.Interfaces
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
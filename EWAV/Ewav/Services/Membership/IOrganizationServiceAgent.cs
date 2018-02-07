using System;
using System.Collections.Generic;
using System.ServiceModel.DomainServices.Client;
using EWAV.Web.Services;
using EWAV.DTO;

namespace EWAV.Services
{
    public interface IOrganizationServiceAgent    
    {
        /// <summary>
        /// Reads all.
        /// </summary>
        /// <param name="readAllCompleted">The read all completed.</param>
        void ReadAll();

        void Add(UserOrganizationDto dto, Action<int, Exception> completed);

        void Update(OrganizationDto dto, Action<bool, Exception> completed);

        void Delete(int organizationId, Action<bool, Exception> completed);

        void Read(int organizationId, Action<OrganizationDto, Exception> completed);
    }
}
using System;

namespace CDC.ISB.EIDEV.DTO.Membership
{
    /// <summary>
    /// These flags control the security level of a User    
    /// </summary>
    [Flags]
    public enum RolesEnum
    {
        /// <summary>
        /// The default user level.  
        /// Zero or more per organization 
        /// Users can create, read, share, and delete canvases
        /// </summary>
        Analyst = 1,
        /// <summary>
        /// One or more per Organization 
        /// Administrators may create users
        /// Administrators may create other administrators
        /// Administrators can create, read, share, and delete cnavases  
        /// Administrators can create, edit or delete Datasources for their organization only 
        /// </summary>
        Administrator = 2,
        /// <summary>
        /// THERE CAN BE ONLY ONE PER DEPLOYMENT 
        /// SuperAdministrators may create, edit or delete Organizations 
        /// SuperAdministrators may create one or more Administrators per organization 
        /// SuperAdministrators may create one or more users for their organization only 
        /// SuperAdministrators may create, read, share, and delete canvases in their own organization 
        /// SuperAdministrators can create, edit or delete Datasources for their organization only 
        /// </summary>
        SuperAdministrator = 3
    }
}
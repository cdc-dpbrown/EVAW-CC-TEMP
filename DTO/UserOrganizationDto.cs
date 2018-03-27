namespace CDC.ISB.EIDEV.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CDC.ISB.EIDEV.DTO.Membership;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class UserOrganizationDto
    {
        public OrganizationDto Organization { get; set; }
        public UserDTO User { get; set; }
        public bool Active { get; set; }
        public int RoleId { get; set; }
        public string RoleText {
            get {
                return Convert.ToString(Enum.Parse(typeof(RolesEnum), this.RoleId.ToString(), false));
            }
        }
    }
}
namespace CDC.ISB.EIDEV.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CDC.ISB.EIDEV.DTO.Membership;

    /// <summary>
    /// 
    /// </summary>
    public class UserDTO   
    {
        private string passwordHash = false.ToString();
        private int highestRole;
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserRoleInOrganization { get; set; }
        public int HighestRole
        {
            get
            {
                return this.highestRole;
            }
            set
            {
                this.highestRole = value;
            }
        }

        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        public string Phone { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the temp id.
        /// </summary>
        /// <value>
        /// The temp id.
        /// </value>
        public Guid TempId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
        //public int OriginalUserID { get; set; }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName 
        { 
            get 
            {
                return this.FirstName + " " + this.LastName;
            } 
        }


        /// <summary>
        /// Gets or sets the password hash.
        /// </summary>
        /// <value>
        /// The password hash.
        /// </value>
        public string PasswordHash
        {
            get
            {
                return passwordHash;
            }
            set
            {
                passwordHash = value;
            }
        }



        /// <summary>
        /// Gets or sets a value indicating whether [should reset password].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [should reset password]; otherwise, <c>false</c>.
        /// </value>
        public bool ShouldResetPassword { get; set; }


        /// <summary>
        /// Gets or sets the datasource list.
        /// </summary>
        /// <value>
        /// The datasource list.
        /// </value>
        public List<DTO.DatasourceDto> DatasourceList { get; set; }

        //public string RoleText
        //{
        //    get
        //    {
        //        return Convert.ToString(Enum.Parse(typeof(RolesEnum), this.RoleValue.ToString(), false));
        //    }
        //}

        /// <summary>
        /// Gets or sets the datasource count.
        /// </summary>
        /// <value>
        /// The datasource count.
        /// </value>
        public int DatasourceCount { get; set; }

        /// <summary>
        /// Gets or sets the type of the user edit.
        /// </summary>
        /// <value>
        /// The type of the user edit.
        /// </value>
        public CDC.ISB.EIDEV.DTO.UserEditType UserEditType { get;set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is existing user.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is existing user; otherwise, <c>false</c>.
        /// </value>
        public bool IsExistingUser { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum UserEditType
    {
        /// <summary>
        /// The editing password
        /// </summary>
        EditingPassword = 0,
        /// <summary>
        /// The editing user info
        /// </summary>
        EditingUserInfo
    }
}
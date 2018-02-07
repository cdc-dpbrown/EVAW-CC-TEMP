namespace EWAV.Web.Services
{
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using EWAV.BAL;
    using System.Collections.Generic;
    using System.Xml;
    using System.Configuration;
    using EWAV.DTO;
    using EWAV.Security;

    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class UserDomainService : DomainService
    {
        EntityManager em = new EntityManager();


        /// <summary>
        /// Loads the user from activedirectory.
        /// </summary>
        /// <param name="EmailAddress">The email address.</param>
        /// <returns></returns>
        public UserDTO LoadUserFromActivedirectory(string DomainName, string EmailAddress)
        {
            EntityManager em = new EntityManager();
            return em.LoadUserFromActivedirectory(DomainName, EmailAddress);
        }

        /// <summary>
        /// Loads the user.
        /// </summary>
        /// <param name="UserName">Name of the user.</param>
        /// <returns></returns>
        public UserDTO LoadUser(string UserName)
        {
            EntityManager em = new EntityManager();
            UserDTO resulUserDTO = em.LoadUser(UserName);
            return resulUserDTO;
        }


        public PasswordHasher GetPh(PasswordHasher ph)
        {

            return new PasswordHasher("aa");

        }



        /// <summary>
        /// Gets the user for authentication.
        /// </summary>
        /// <param name="userDTO">The user DTO.</param>
        /// <returns></returns>
        public UserDTO GetUserForAuthentication(UserDTO userDTO)                   //        string userID, string passwordHash)
        {
            EntityManager em = new EntityManager();
            UserDTO resulUserDTO = em.GetUserForAuthentication(userDTO);
            return resulUserDTO;
        }


        /// <summary>
        /// Returns Users organization dto.
        /// </summary>
        /// <param name="userOrganizationDto">The user organization dto.</param>
        /// <returns></returns>
        public List<OrganizationDto> userOrganizationDto(List<OrganizationDto> userOrganizationDto)
        {
            return new List<OrganizationDto>();
        }

        /// <summary>
        /// Reads all orgs for user.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        public List<OrganizationDto> ReadAllOrgsForUser(int userID)
        {
            EntityManager em = new EntityManager();

            List<OrganizationDto> result = em.ReadAllOrgsForUser(userID);

            return result;
        }
        /// <summary>
        /// Gets the name of the client user.
        /// </summary>
        /// <returns></returns>
        public string GetClientUserName()
        {
            return System.Web.HttpContext.Current.User.Identity.Name.ToString();
        }

        /// <summary>
        /// Forgots the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public bool ForgotPassword(string email)
        {
            return em.ForgotPassword(email);
        }

        /// <summary>
        /// Generates the user.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        public bool GenerateUser(UserOrganizationDto dto)
        {
            return em.GenerateUser(dto);
        }

        /// <summary>
        /// Edits the user.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        public bool EditUser(UserOrganizationDto dto)
        {
            return em.EditUser(dto);
        }

        /// <summary>
        /// Removes the user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        public bool RemoveUser(int userId)
        {
            return em.RemoveUser(userId);
        }

        /// <summary>
        /// Reads the user.
        /// </summary>
        /// <param name="roleid">The roleid.</param>
        /// <param name="organizationId">The organization id.</param>
        /// <returns></returns>
        public List<UserDTO> ReadUser(int roleid, int organizationId)
        {
            return em.ReadUser(roleid, organizationId);
        }

        //public bool ValidatePassword(string )

        /// <summary>
        /// Reads the password rules.
        /// </summary>
        /// <returns></returns>
        public PasswordRulesDTO ReadPasswordRules()
        {
            return new PasswordRulesDTO();
        }

        /// <summary>
        /// Reads the associated datasources.
        /// </summary>
        /// <param name="UserId">The user id.</param>
        /// <param name="OrganizationId">The organization id.</param>
        /// <returns></returns>
        public List<DatasourceDto> ReadAssociatedDatasources(int UserId, int OrganizationId)
        {
            return em.ReadAssociatedDatasources(UserId, OrganizationId);
        }

        /// <summary>
        /// Reads the user names from ewav.
        /// </summary>
        /// <returns></returns>
        public List<string> ReadUserNamesFromEWAV()
        {
            return em.ReadUserNames();
        }

        /// <summary>
        /// Reads the name of the user by username.
        /// </summary>
        /// <param name="UserName">Name of the user.</param>
        /// <param name="OrganizationId">The organization id.</param>
        /// <returns></returns>
        public UserDTO ReadUserByUserName(string UserName, int OrganizationId)
        {
            return em.ReadUserByUserName(UserName, OrganizationId);
        }
    }
}
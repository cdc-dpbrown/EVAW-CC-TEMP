using System;
using System.Collections.Generic;
using EWAV.DTO;

namespace EWAV.Services
{
    public interface IUserServiceAgent
    {
        void GetUserForAuthentication(UserDTO userDTO, Action<UserDTO, Exception> completed);
        void AddUser(UserOrganizationDto dto, Action<bool, Exception> completed);
        void UpdateUser(UserOrganizationDto dto, Action<bool, Exception> completed);
        void DeleteUser(int userId, Action<bool, Exception> completed);
        void ReadUser(int roleid, int orgnizationId, Action<List<UserDTO>, Exception> completed);
        void ForgotPassword(string email, Action<bool, Exception> completed);
        void ReadPasswordRules(Action<PasswordRulesDTO, Exception> completed);
        void ReadAssociatedDatasources(int UserId, int OrganizationId, Action<List<DatasourceDto>, Exception> completed);
        void ReadUserNamesFromEWAV(Action<List<string>, Exception> completed);
        void ReadUserByUserName(string UserName, int OrganizationId, Action<UserDTO, Exception> completed);
    }





}
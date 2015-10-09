using System;
using System.Linq;
using System.Web.Helpers;
using System.Web.Security;
using Forum.ViewModels;
using BLL.Interface;
using BLL.Interface.Entities;

namespace Forum.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        private readonly IRoleService roleService;
        private readonly IUserService userService;

        public CustomRoleProvider()
        {
            this.roleService = (IRoleService)System.Web.Mvc.DependencyResolver
                .Current.GetService(typeof(IRoleService));
            this.userService = (IUserService)System.Web.Mvc.DependencyResolver
                .Current.GetService(typeof(IUserService));
        }

        public override bool IsUserInRole(string login, string roleName)
        {
            string[] roles = GetRolesForUser(login);
            for (int i = 0; i < roles.Length; i++)
			{
                if (roleName.Equals(roleName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
			}
            return false;
        }

        public override string[] GetRolesForUser(string login)
        {
            string[] roles = {};
            UserEntity user = userService.GetByLogin(login);
            if (user != null)
	        {
                roles = roleService.GetRolesForUser(user.Id).Select(role => role.Name).ToArray();
	        }
            return roles;
        }

        public override void CreateRole(string roleName)
        {
            var newRole = new RoleEntity() { Name = roleName };
            roleService.Create(newRole);
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}
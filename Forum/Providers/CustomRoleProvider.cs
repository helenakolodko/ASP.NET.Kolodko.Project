using System;
using System.Linq;
using System.Web.Helpers;
using System.Web.Security;
using Forum.ViewModels;

namespace Forum.Providers
{
    //public class CustomRoleProvider : RoleProvider
    //{
    //    public override bool IsUserInRole(string email, string roleName)
    //    {
    //        using (var context = new UserContext())
    //        {
    //            User user = (from u in context.Users
    //                         where u.Email == email
    //                         select u).FirstOrDefault();

    //            if (user == null) return false;

    //            Role userRole = context.Roles.Find(user.RoleId);

    //            if (userRole != null && userRole.Name == roleName)
    //            {
    //                return true;
    //            }

    //            return false;
    //        }
    //    }

    //    public override string[] GetRolesForUser(string email)
    //    {
    //        using (var context = new UserContext())
    //        {
    //            var roles = new string[] { };
    //            var user = context.Users.FirstOrDefault(u => u.Email == email);

    //            if (user == null) return roles;

    //            var userRole = user.Role;

    //            if (userRole != null)
    //            {
    //                roles = new string[] { userRole.Name };
    //            }
    //            return roles;
    //        }
    //    }

    //    public override void CreateRole(string roleName)
    //    {
    //        var newRole = new Role() { Name = roleName };
    //        using (var context = new UserContext())
    //        {
    //            context.Roles.Add(newRole);
    //            context.SaveChanges();
    //        }
    //    }

    //    public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override bool RoleExists(string roleName)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override void AddUsersToRoles(string[] usernames, string[] roleNames)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override string[] GetUsersInRole(string roleName)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override string[] GetAllRoles()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override string[] FindUsersInRole(string roleName, string usernameToMatch)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override string ApplicationName { get; set; }
    //}
}
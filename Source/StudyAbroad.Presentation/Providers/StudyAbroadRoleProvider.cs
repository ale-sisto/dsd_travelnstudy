using StudyAbroad.BusinessLogic.Factories;
using StudyAbroad.DomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace StudyAbroad.Presentation.Providers
{
    public class StudyAbroadRoleProvider : RoleProvider
    {
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            foreach (string rolename in roleNames)
            {
                if (String.IsNullOrEmpty(rolename))
                {
                    throw new ArgumentException("Invalid Role name.");
                }
                
                if (!RoleExists(rolename))
                {
                    throw new ProviderException("Role name not found.");
                }
            }

            foreach (string username in usernames)
            {
                if (username.Contains(","))
                {
                    throw new ArgumentException("User names cannot contain commas.");
                }

                if (String.IsNullOrEmpty(username))
                {
                    throw new ArgumentException("Invalid User name.");
                }

                foreach (string rolename in roleNames)
                {
                    if (IsUserInRole(username, rolename))
                    {
                        throw new ProviderException("User is already in role.");
                    }
                }
            }
        }

        public override string ApplicationName
        {
            get
            {
                return "StudyAbroad";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            // We support 2 roles Admin and User out of the box, no plans to add roles ad hoc
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            // We support 2 roles Admin and User out of the box, no plans to remove roles ad hoc
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            // Not implemented because does not provide value
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            return Enum.GetNames(typeof(UserRoleEnum));
        }

        public override string[] GetRolesForUser(string username)
        {
            if (String.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Invalid User name.");
            }

            var roles = BLLFactory.User().GetUserRoles(username);
            var roleNames = roles.Select(x => x.ToString()).ToArray();
            return roleNames;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            if (String.IsNullOrEmpty(roleName))
            {
                throw new ArgumentException("Invalid Role name.");
            }

            if (!RoleExists(roleName))
            {
                throw new ProviderException("Role name not found.");
            }

            var role = (UserRoleEnum) Enum.Parse(typeof(UserRoleEnum), roleName);
            var users = BLLFactory.User().GetByRole(role);
            var userNames = users.Select(x => x.Username).ToArray();
            return userNames;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            if (String.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Invalid User name.");
            }

            if (String.IsNullOrEmpty(roleName))
            {
                throw new ArgumentException("Invalid Role name.");
            }

            var role = (UserRoleEnum) Enum.Parse(typeof(UserRoleEnum), roleName);
            return BLLFactory.User().UserHasRole(username, role);            
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            // Not implemented because does not provide value
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            if (String.IsNullOrEmpty(roleName))
            {
                throw new ArgumentException("Invalid Role name.");
            }

            foreach (string role in Enum.GetNames(typeof(UserRoleEnum)))
            {
                if (role == roleName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
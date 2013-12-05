using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using StudyAbroad.DomainModel.Core;
using StudyAbroad.DomainModel.Enums;

namespace StudyAbroad.BusinessLogic.Core
{
    public class UserBusinessLogic : Framework.BusinessLogic<User>
    {
        public bool CheckUsernameAvailability(string inUsername)
        {
            var userWithUsername = Orm.FilterFirst(u => u.Username == inUsername);
            return userWithUsername == null;
        }

        public List<User> GetByRole(UserRoleEnum inRole)
        {
            return Orm.FilterAll(u => u.HasRole(inRole));
        }

        public void AddUser(User inUser)
        {
            if (!CheckUsernameAvailability(inUser.Username))
                throw new Exception("That username already exists in the database");

            Orm.Create(inUser);
        }

        public User AddUser(string inUsername, string inPassword, string inName, string inSurname, string inCountryName)
        {
            var country = Factories.BLLFactory.Location().GetByName(inCountryName) as Country;
            var user = new User(inName, inSurname, inUsername, inPassword, country);
            AddUser(user);
            return user;
        }

        public List<UserRoleEnum> GetUserRoles(string inUsername)
        {
            var user = GetByUsername(inUsername);
            return user.Roles;
        }

        public void UpdateUser(User inUser)
        {
            Orm.Update(inUser);
        }

        public void UserAddRole(string inUsername, UserRoleEnum inRole)
        {
            var user = GetByUsername(inUsername);
            user.AddRole(inRole);
            UpdateUser(user);
        }

        public bool UserHasRole(string inUsername, UserRoleEnum inRole)
        {
            var user = GetByUsername(inUsername);
            return user.HasRole(inRole);
        }

        public User GetByUsername(string inUsername)
        {
            var user = Orm.FilterFirst(u => u.Username == inUsername);
            if (user == null)
                throw new Exception("No user with provided username was found!");
            return user;
        }

        public void ChangePassword(string username, string oldPassword, string newPassword)
        {
            var user = GetByUsername(username);
            user.ChangePassword(oldPassword, newPassword);
            UpdateUser(user);
        }

        public User GetUserCredentials(string inUsername, string inPassword)
        {
            var user = Orm.FilterFirst(u => u.Username == inUsername);
            if (user == null)
                return null;

            if (user.PassHash != User.HashPassword(inPassword))
                return null;           

            return user;
        }

        public bool ValidateUser(string inUsername, string inPassword)
        {
            var user = Orm.FilterFirst(u => u.Username == inUsername);
            if (user == null)
                return false;

            if (user.PassHash != User.HashPassword(inPassword))
                return false;
            
            return true;
        }

        public void DeleteUser(string inUsername)
        {
            var user = GetByUsername(inUsername);
            if (user == null)
                throw new Exception("No user was found with the username: "+inUsername);
            DeleteUser(user);
        }

        public void DeleteUser(User inUser)
        {
            Orm.Delete(inUser);
        }

        public List<User> GetAll()
        {
            return Orm.ReadAll();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using StudyAbroad.DomainModel.Enums;
using StudyAbroad.DomainModel.Exceptions;
using StudyAbroad.DomainModel.Framework;

namespace StudyAbroad.DomainModel.Core
{
    /// <summary>
    /// Will adjust this class as a sample class for ORM
    /// The class MUST BE public
    /// </summary>
    public class User : DomainBase<User>
    {
        /// <summary>
        /// All mapped properties MUST BE virtual
        /// Also all methods MUST BE virtual
        /// </summary>
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string PassHash { get; set; }
        public virtual Country Country { get; set; }
        public virtual List<UserRoleEnum> Roles { get; set; }
        //public Dictionary<string, string> Preferences { get; set; }  -- wont map this for now until we get to work with preferences

        /// <summary>
        /// Must have a normal and a parameter less constructor
        /// For parameter names, prefix with "in" so "name" > "inName"
        /// </summary>
        public User(string inName, string inSurname, string inUsername, string inPassword, Country inCountry)
        {
            //Inside the constructor do some validation checks (check the same validation rules you put in for mapping)
            //These errors will be easier to debug then nHibernate ones
            if (string.IsNullOrEmpty(inName) || inName.Length > 40)
                throw new DomainModelValidationException("First name is a neccessary field and cannot be larger then 40 chars.", "inName");
            if (string.IsNullOrEmpty(inSurname) || inSurname.Length > 60)
                throw new DomainModelValidationException("Last name is a neccessary field and cannot be larger then 60 chars.", "inSurname");
            if (inUsername.Length < 5 || inUsername.Length > 20)
                //Obviously we will need to check if the username already exists but this will be done in the BLL validation section
                throw new DomainModelValidationException("The username must have no less then 5 and no more then 20 chars.", "inUsername");
            if (inPassword.Length < 5 || inPassword.Length > 20)
                //Again for password we will need to do more things like hashing, and this can be done here but for now keep it like this
                throw new DomainModelValidationException("The password must have no less then 5 and no more then 20 chars.", "inPassHash");

            //If validation succeeds proceed
            this.Name = inName;
            this.Surname = inSurname;
            this.Username = inUsername;
            this.Password = inPassword;
            this.Country = inCountry;

            PassHash = User.HashPassword(inPassword);
            Roles = new List<UserRoleEnum>() {UserRoleEnum.User};
        }

        /// <summary>
        /// A necessary parameter less constructor
        /// </summary>
        public User()
        {
            Roles = new List<UserRoleEnum>() {UserRoleEnum.User};
        }

        public virtual void ChangePassword(string oldPassword, string newPassword)
        {
            if (PassHash != HashPassword(oldPassword))
                throw new Exception("The current password is not valid.");

            if (newPassword.Length < 5 || newPassword.Length > 20)
                //Again for password we will need to do more things like hashing, and this can be done here but for now keep it like this
                throw new DomainModelValidationException("The new password must have no less then 5 and no more then 20 chars.", "inPassHash");

            Password = newPassword;
            PassHash = HashPassword(newPassword);
        }

        public virtual bool HasRole(UserRoleEnum inRole)
        {
            return Roles.Contains(inRole);
        }

        public virtual void AddRole(UserRoleEnum inRole)
        {
            if (HasRole(inRole))
                throw new Exception("User already has the role you are trying to add!");
            Roles.Add(inRole);
        }

        /// <summary>
        /// A toString method must be implemented
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name + " " + Surname;
        }

        /// <summary>
        /// Add a Display property which returns toString so the client side guys can have something to easily display objects
        /// </summary>
        /// <returns></returns>
        public virtual string Display()
        {
            return ToString();
        }

        public static string HashPassword(string inPassword)
        {
            // step 1, calculate MD5 hash from input
            var md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(inPassword);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

    }
}

using StudyAbroad.BusinessLogic.Factories;
using StudyAbroad.DomainModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace StudyAbroad.Presentation.Providers
{
    public class StudyAbroadMembershipProvider: MembershipProvider
    {
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
           BLLFactory.User().ChangePassword(username, oldPassword, newPassword);
           return true;
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {               
            throw new NotImplementedException();            
        }

        public MembershipUser CreateUser(string username, string password, string firstName, string lastName, string countryName, out MembershipCreateStatus status)
        {
            if (password.Length < MinRequiredPasswordLength)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(username, password, true);
            OnValidatingPassword(args);

            if (args.Cancel)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            MembershipUser user = null;
            status = MembershipCreateStatus.UserRejected;

            try
            {
                user = GetUser(username, true);

                if (user == null)
                {
                    BLLFactory.User().AddUser(username, password, firstName, lastName, countryName);
                    status = MembershipCreateStatus.Success;
                    user = GetUser(username, true);
                }
                else
                {
                    status = MembershipCreateStatus.DuplicateUserName;    
                    throw new Exception("Duplicate user name");
                }
            }
            catch (Exception err)
            {
                user = null;                
                Elmah.ErrorSignal.FromCurrentContext().Raise(err);
            }           

            return user;
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            if (String.IsNullOrEmpty(username))
            {
                throw new ArgumentException();
            }
            BLLFactory.User().DeleteUser(username);
            return true;
        }

        public override bool EnablePasswordReset
        {
            get { return false; }
        }

        public override bool EnablePasswordRetrieval
        {
            get { return false; }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            User user = null;
            try
            {
                user = BLLFactory.User().GetByUsername(username);
            }
            catch (Exception e)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(e);   
            }

            if (user != null)
            {                
                StudyAbroadMembershipUser memUser = new StudyAbroadMembershipUser("StudyAbroadMembershipProvider",
                                               user.Username, user.Id, string.Empty,
                                               string.Empty, string.Empty,
                                               true, false, DateTime.MinValue,
                                               DateTime.MinValue,
                                               DateTime.MinValue,
                                               DateTime.Now, DateTime.Now,
                                               user.Name, user.Surname, user.Country.Name);
                return memUser;
            }

            return null;
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { return 3; }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return 0; }
        }

        public override int MinRequiredPasswordLength
        {
            get { return 5; }
        }

        public override int PasswordAttemptWindow
        {
            get { return 10; }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return false; }
        }

        public override bool RequiresUniqueEmail
        {
            get { return false; }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            
            DomainModel.Core.User coreUser = BLLFactory.User().GetByUsername(user.UserName);
            var saUser = user as StudyAbroadMembershipUser;
            
            coreUser.Name = saUser.FirstName;
            coreUser.Surname = saUser.LastName;

            var country = BLLFactory.Location().GetByName(saUser.CountryName) as Country;
            coreUser.Country = country;

            BLLFactory.User().UpdateUser(coreUser);
        }

        public override bool ValidateUser(string username, string password)
        {
            var isValid = BLLFactory.User().ValidateUser(username, password);
            if (isValid)
                return true;
            return false;
        }
    }
}
using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyAbroad.DomainModel.Core;

namespace StudyAbroad.Test
{
    /// <summary>
    /// Summary description for User_UnitTests
    /// </summary>
    [TestClass]
    public class User_UnitTests
    {
        public User_UnitTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestCheckUsername()
        {
            //test to see if a nonexistant username is available
            var nonExistantUserName = "pero123";
            var usernameAvailable = BusinessLogic.Factories.BLLFactory.User().CheckUsernameAvailability(nonExistantUserName);
            Assert.AreEqual(true, usernameAvailable);

            //now add a user with that username
            var userPero = BusinessLogic.Factories.BLLFactory.User().AddUser("pero123", "perinpass", "Pero", "Perić", "Croatia");

            //test the availability of the username again, now it should not be available
            usernameAvailable = BusinessLogic.Factories.BLLFactory.User().CheckUsernameAvailability(nonExistantUserName);
            Assert.AreEqual(false, usernameAvailable);

            //clean up
            BusinessLogic.Factories.BLLFactory.User().DeleteUser(userPero);
        }

        [TestMethod]
        public void TestPasswordHashing()
        {
            //create a user
            var userPero = BusinessLogic.Factories.BLLFactory.User().AddUser("pero123", "perinpass", "Pero", "Perić", "Croatia");

            //load the user
            var pero = BusinessLogic.Factories.BLLFactory.User().GetUserCredentials(userPero.Username, userPero.Password);
            //test to see if the hashing was done and stored correctly
            Assert.AreEqual(pero.PassHash, User.HashPassword("perinpass"));
            Assert.AreNotEqual(pero.PassHash, User.HashPassword("bilosta"));

            //clean up
            BusinessLogic.Factories.BLLFactory.User().DeleteUser(userPero);
        }

        [TestMethod]
        public void TestAddingUsers()
        {
            //create a user
            var userPero = BusinessLogic.Factories.BLLFactory.User().AddUser("pero123", "perinpass", "Pero", "Perić", "Croatia");

            //load the user
            var pero = BusinessLogic.Factories.BLLFactory.User().GetUserCredentials(userPero.Username, userPero.Password);
            //test to see if the user was created and stored successfuly
            Assert.AreEqual(pero.Name, "Pero");
            Assert.AreEqual(pero.Surname, "Perić");

            //clean up
            BusinessLogic.Factories.BLLFactory.User().DeleteUser(userPero);
        }

        [TestMethod]
        public void TestValidatingUser()
        {
            //create a user
            var userPero = BusinessLogic.Factories.BLLFactory.User().AddUser("pero123", "perinpass", "Pero", "Perić", "Croatia");

            //validate the user correctly
            var user = BusinessLogic.Factories.BLLFactory.User().GetUserCredentials("pero123", "perinpass");
            Assert.AreEqual(user.Name, "Pero");
            Assert.AreEqual(user.Surname, "Perić");

            //validate the user by wrong username
            user = BusinessLogic.Factories.BLLFactory.User().GetUserCredentials("pero999", "perinpass");
            Assert.AreEqual(user, null);

            //validate the user by wrong password
            user = BusinessLogic.Factories.BLLFactory.User().GetUserCredentials("pero123", "wrongpass");
            Assert.AreEqual(user, null);

            //clean up
            BusinessLogic.Factories.BLLFactory.User().DeleteUser(userPero);
        }
    }
}

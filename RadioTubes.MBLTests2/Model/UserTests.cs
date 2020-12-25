using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RadioTubes.MBL.Model.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void UserTest()
        {
            // Arrange
            var userName = "testUser";
            var userNull = "";

            // Act
            var user = new User(userName);

            // Assert
            Assert.AreEqual(userName, user.UserName);
            Assert.ThrowsException<ArgumentException>(() => new User(userNull));
        }

        public void ToStringTest()
        {
            // Arrange
            var userName = "testUser";

            // Act
            var user = new User(userName);

            // Assert
            Assert.AreEqual("UserName: userEmpty\nFirstName: \nMiddleName: \nSecondName: \nGender: \nDateOfBirth: 01.01.0001\nLocation: \n",
                            user.ToString());

        }
    }
}
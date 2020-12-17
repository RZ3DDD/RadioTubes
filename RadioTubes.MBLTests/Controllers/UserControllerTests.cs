using Microsoft.VisualStudio.TestTools.UnitTesting;
using RadioTubes.MBL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioTubes.MBL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString() + "-test";

            // Act
            var controllerOfUser1 = new UserController(userName);
            
            // Assert
            Assert.AreEqual(userName, controllerOfUser1.CurrentUser.UserName);
        }

        [TestMethod()]
        public void UpdateCurrentUserDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetRequiredParametersTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetOptionalParametersTest()
        {
            Assert.Fail();
        }

   }
}
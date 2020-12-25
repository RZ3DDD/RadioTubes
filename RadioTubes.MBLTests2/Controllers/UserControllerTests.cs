using Microsoft.VisualStudio.TestTools.UnitTesting;
using RadioTubes.MBL.Model;
using System;
using System.IO;

namespace RadioTubes.MBL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void CleanseUsersTest()
        {
            // Arrange
            // Удалить существующий файл со списком тестовых пользователей если он есть
            var fi = new FileInfo("users.dat");
            if (fi.Exists) fi.Delete();

            //Act
            // Создать чистого существующего пользователя
            // Создать новый файл и записать очищенный список тестовых пользователей
            var existingUserController = new UserController("ExistingUser");

            // Assert
            Assert.AreEqual(existingUserController.CurrentUser.UserName, "ExistingUser");
        }

        [TestMethod()]
        public void UserControllerTest()
        {
            // Arrange
            var userNull = "";
            var userEmpty = "      ";
            var userNew = Guid.NewGuid().ToString() + "-test";
            var userExisting = "ExistingUser";

            // Act
            var userController1 = new UserController(userExisting);
            var userController2 = new UserController(userNew);
            //var userController3 = new UserController(userNull);


            //Assert
            Assert.AreEqual(userExisting, userController1.CurrentUser.UserName);
            Assert.AreEqual(userNew, userController2.CurrentUser.UserName);
            Assert.ThrowsException<ArgumentNullException>(() => new UserController(userNull));
            Assert.ThrowsException<ArgumentNullException>(() => new UserController(userEmpty));
        }

        [TestMethod()]
        public void SetRequiredParametersTest()
        {
            // Arrange
            var user = "ExistingUser";
            var gender = "male";
            var dateOfBirth = DateTime.Parse("13/04/1961");
            var location = new Location("Россия", "Тверь");


            // Act
            var userControllerIn = new UserController(user);
            userControllerIn.SetRequiredParameters(gender, dateOfBirth, location);

            var userControllerOut = new UserController(user);

            // Assert
            Assert.AreEqual(userControllerIn.CurrentUser.Gender.Name, userControllerOut.CurrentUser.Gender.Name);
            Assert.AreEqual(userControllerIn.CurrentUser.DateOfBirth, userControllerOut.CurrentUser.DateOfBirth);
            Assert.AreEqual(userControllerIn.CurrentUser.Location.Country, userControllerOut.CurrentUser.Location.Country);
            Assert.AreEqual(userControllerIn.CurrentUser.Location.Locality, userControllerOut.CurrentUser.Location.Locality);
        }

        [TestMethod()]
        public void SetOptionalParametersTest()
        {
            // Arrange
            var user = "ExistingUser";


            // Act
            var userControllerIn = new UserController(user);
            userControllerIn.SetOptionalParameters("Сидор", "Сидорович", "Сидоров");

            var userControllerOut = new UserController(user);

            // Assert
            Assert.AreEqual(userControllerIn.CurrentUser.FirstName, userControllerOut.CurrentUser.FirstName);
            Assert.AreEqual(userControllerIn.CurrentUser.MiddleName, userControllerOut.CurrentUser.MiddleName);
            Assert.AreEqual(userControllerIn.CurrentUser.SecondName, userControllerOut.CurrentUser.SecondName);
            //Console.WriteLine(userControllerOut.CurrentUser);
            //Console.ReadLine();
        }
    }
}
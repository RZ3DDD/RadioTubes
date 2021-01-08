using Microsoft.VisualStudio.TestTools.UnitTesting;
using RadioTubes.MBL.Model;
using System;
using System.IO;

namespace RadioTubes.MBL.Controllers.Tests
{
    [TestClass()]
    public class KindOfTubeControllerTests
    {
        [TestMethod()]
        public void CleanseKindOfTubesTest()
        {
            // Arrange
            // Удалить существующий файл со списком тестовых типов ламп, если он есть
            //MBLSettings settings = new MBLSettings();
            //var fi = new FileInfo(settings.UserDataPath + "kind_of_tubes.dat");
            //if (fi.Exists) fi.Delete();

            //Act
            // Создать чистый существующий тип лампы
            // Создать новый файл и записать очищенный список тестовых типов пользователей
            //var existingKindOfTube = new KindOfTubeController("ExistingTube");
            //var existingKindOfTube = new KindOfTubeController();

            // Assert
            //Assert.AreEqual(existingKindOfTube.CurrentKindOfTube.EngName, "ExistingTube");
            Assert.Fail();
        }
        //public void KindOfTubeControllerTest()
        //{
        //    // Arrange
        //    var kindOfTubeNull = "";
        //    var kindOfTubeEmpty = "      ";
        //    var kindOfTubeNew = Guid.NewGuid().ToString() + "-test";
        //    var kindOfTubeExisting = "ExistingTube";

        //    // Act
        //    var kindOfTubeController1 = new KindOfTubeController(kindOfTubeExisting);
        //    var kindOfTubeController2 = new KindOfTubeController(kindOfTubeNew);


        //    //Assert
        //    Assert.AreEqual(kindOfTubeExisting, kindOfTubeController1.CurrentKindOfTube.EngName);
        //    Assert.AreEqual(kindOfTubeNew, kindOfTubeController2.CurrentKindOfTube.EngName);
        //    Assert.ThrowsException<ArgumentNullException>(() => new KindOfTubeController(kindOfTubeNull));
        //    Assert.ThrowsException<ArgumentNullException>(() => new KindOfTubeController(kindOfTubeEmpty));
        //}

        //[TestMethod()]
        //public void SetOptionalCultNameParameterTest()
        //{
        //    // Arrange
        //    var kindOfTube = "ExistingTube";


        //    // Act
        //    var kindOfTubeControllerIn = new KindOfTubeController(kindOfTube);
        //    kindOfTubeControllerIn.CurrentKindOfTube.CultName = "ТестовыйТип";

        //    var kindOfTubeControllerOut = new KindOfTubeController(kindOfTube);

        //    // Assert
        //    Assert.AreEqual(kindOfTubeControllerIn.CurrentKindOfTube.CultName, kindOfTubeControllerOut.CurrentKindOfTube.CultName);
        //    //Console.WriteLine(kindOfTubeControllerOut.CurrentKindOfTube);
        //    //Console.ReadLine();
        //}

        //    [TestMethod()]
        //    public void SetOptionalCultNameParameterNullTest()
        //    {
        //        // Arrange
        //        var kindOfTube = "ExistingTube";


        //        // Act
        //        var kindOfTubeControllerIn = new KindOfTubeController(kindOfTube);
        //        kindOfTubeControllerIn.CurrentKindOfTube.CultName = "  ";

        //        var kindOfTubeControllerOut = new KindOfTubeController(kindOfTube);

        //        // Assert
        //        Assert.AreEqual(kindOfTubeControllerIn.CurrentKindOfTube.EngName, kindOfTubeControllerOut.CurrentKindOfTube.CultName);
        //        //Console.WriteLine(kindOfTubeControllerOut.CurrentKindOfTube);
        //        //Console.ReadLine();
        //    }
    }
}
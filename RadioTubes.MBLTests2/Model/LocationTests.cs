using Microsoft.VisualStudio.TestTools.UnitTesting;
using RadioTubes.MBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioTubes.MBL.Model.Tests
{
    [TestClass()]
    public class LocationTests
    {
        [TestMethod()]
        public void LocationTest()
        {
            // Arrange
            var country = "Россия";
            var locality = "Рязань";

            // Act
            var location = new Location(country, locality);

            // Assert
            Assert.AreEqual(country, location.Country);
            Assert.AreEqual(locality, location.Locality);
            Assert.ThrowsException<ArgumentNullException>(() => new Location(country, ""));
            Assert.ThrowsException<ArgumentNullException>(() => new Location("", locality));
            Assert.ThrowsException<ArgumentNullException>(() => new Location("", ""));
        }

        [TestMethod()]
        public void ToStringTest()
        {
            // Arrange
            var country = "Россия";
            var locality = "Рязань";

            // Act
            var location = new Location(country, locality);

            // Assert
            Assert.AreEqual("Страна: Россия.  Населённый пункт: Рязань.", location.ToString());
        }
    }
}
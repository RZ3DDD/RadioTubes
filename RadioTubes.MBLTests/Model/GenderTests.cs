using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RadioTubes.MBL.Model.Tests
{
    [TestClass()]
    public class GenderTests
    {
        [TestMethod()]
        public void GenderTest()
        {
            // Arrange
            var gen = "male";
            var genNull = "";

            // Act
            var gender = new Gender(gen);

            // Assert
            Assert.AreEqual(gen, gender.Name);
            Assert.ThrowsException<ArgumentNullException>(() => new Gender(genNull));

        }

        [TestMethod()]
        public void ToStringTest()
        {
            // Arrange
            var gen = "female";

            // Act
            var gender = new Gender(gen);

            // Assert
            Assert.AreEqual(gender.ToString(), gen);
        }
    }
}
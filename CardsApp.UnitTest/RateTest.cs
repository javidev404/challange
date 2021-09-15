using System;
using NUnit.Framework;
using CardsApp.Helpers;
using CardsApp.Models;

namespace CardsApp.UnitTest
{
    public class RateTest
    {
        private IRateCalculator RateCalculator;

        [SetUp]
        public void Setup()
        {
            RateCalculator = new RateCalculator();
        }

        [Test]
        public void CalcularRatePorcentual_Squa_CalculatesCorrectly()
        {
            //Arrange
            Brand Brand = Brand.SQUA;
            DateTime dateTime = new DateTime(2021, 8, 25);

            //Act
            var rate = RateCalculator.CalcularRatePorcentual(Brand, dateTime);

            //Assert
            Assert.AreEqual(252.625, rate);
        }

        [Test]
        public void CalcularRatePorcentual_Sco_CalculatesCorrectly()
        {
            //Arrange
            Brand Brand = Brand.SCO;
            DateTime dateTime = new DateTime(2021, 8, 25);

            //Act
            var rate = RateCalculator.CalcularRatePorcentual(Brand, dateTime);

            //Assert
            Assert.AreEqual(4.0, rate);
        }

        [Test]
        public void CalcularRatePorcentual_Pere_CalculatesCorrectly()
        {
            //Arrange
            Brand Brand = Brand.PERE;
            DateTime dateTime = new DateTime(2021, 8, 25);

            //Act
            var rate = RateCalculator.CalcularRatePorcentual(Brand, dateTime);

            //Assert
            Assert.AreEqual(0.8, rate);
        }
    }
}
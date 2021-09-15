using System;
using NUnit.Framework;
using CardsApp.Models;
using CardsApp.Helpers;

namespace CardsApp.UnitTest
{
    class CardTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsCardValid_ReturnsFalseIfOld()
        {
            //Arrange
            var Card = new Card()
            {
                Expiration = DateTime.Today.AddDays(-1)
            };

            //Act
            var isValid = CardHelpers.IsCardValid(Card);


            //Assert
            Assert.False(isValid);
        }
        
        [Test]
        public void AreCardsEqual_ReturnsTrueIfSameAttributes()
        {
            //Arrange
            var Card1 = new Card()
            {
                Brand = Brand.PERE,
                Number = "00000000",
                cardHolder = "Javier",
                Expiration = new DateTime(2021, 8, 25)
            };

            var Card2 = new Card()
            {
                Brand = Brand.PERE,
                Number = "00000000",
                cardHolder = "Javier",
                Expiration = new DateTime(2021, 8, 25)
            };

            //Act
            var areEqual = CardHelpers.AreCardsEqual(Card1, Card2);

            //Assert
            Assert.True(areEqual);
        }
    }
}


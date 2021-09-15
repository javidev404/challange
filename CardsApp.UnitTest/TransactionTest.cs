using CardsApp.Helpers;
using NUnit.Framework;

namespace CardsApp.UnitTest
{
    class TransactionTest
    {
        public void Setup()
        {
        }

        [Test]
        public void IsTransactionValid_TrueFor99()
        {
            //Arrange
            var amount = 99;

            //Act
            var isValid = TransactionHelpers.IsTransactionValid(amount);

            //Assert
            Assert.IsTrue(isValid);
        }
    }
}

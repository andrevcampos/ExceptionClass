using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExceptionClass;


namespace ExceptionClass.UnitTests
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void Withdraw_InsufficientFundsException()
        {
            // Arrange
            Account account = new Everyday(500);
            decimal withdrawAmount = 700;

            // Act & Assert
            try
            {
                account.Withdrawal((int)withdrawAmount);
                Assert.Fail("Expected InsufficientFundsException was not thrown.");
            }
            catch (InsufficientFundsException ex)
            {
                // Assert
                Assert.AreEqual("Insufficient fund to withdraw.", ex.Message);
                Assert.AreEqual(500, ex.CurrentBalance);
                Assert.AreEqual(withdrawAmount, ex.WithdrawAmount);
            }
        }

        [TestMethod]
        public void Deposit_InvalidDepositException()
        {
            // Arrange
            Account account = new Inverstiment(100, 1000);
            decimal depositAmount = -50;

            // Act & Assert
            try
            {
                account.Deposit((int)depositAmount);
                Assert.Fail("Expected InvalidDepositException was not thrown.");
            }
            catch (InvalidDepositException ex)
            {
                // Assert
                Assert.AreEqual("Invalid amount.", ex.Message);
                Assert.AreEqual(depositAmount, ex.DepositAmount);
            }
        }

        [TestMethod]
        public void Everyday_GetFees()
        {
            // Arrange
            Account account = new Everyday(800);

            // Act & Assert
            Assert.AreEqual(0, account.GetFees());
        }

        // Add more test methods for other classes and methods...
    }
}

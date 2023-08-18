using ExceptionClass;

namespace TestProject1
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void Deposit_ValidAmount_Success()
        {
            // Arrange
            Account account = new Everyday(1000);
            decimal depositAmount = 200;

            // Act
            account.Deposit((int)depositAmount);

            // Assert
            Assert.AreEqual(1200, account.GetBalance);
        }

        [TestMethod]
        public void Deposit_InvalidAmount_ThrowsInvalidDepositException()
        {
            // Arrange
            Account account = new Everyday(1500);
            decimal depositAmount = -50;

            // Act & Assert
            Assert.ThrowsException<InvalidDepositException>(() => account.Deposit((int)depositAmount));
        }

        [TestMethod]
        public void Withdraw_InsufficientFunds_ThrowsInsufficientFundsException()
        {
            // Arrange
            Account account = new Everyday(800);
            decimal withdrawAmount = 1000;

            // Act & Assert
            Assert.ThrowsException<InsufficientFundsException>(() => account.Withdrawal((int)withdrawAmount));
        }

        [TestMethod]
        public void Withdraw_SufficientFunds_Success()
        {
            // Arrange
            Account account = new Everyday(1500);
            decimal withdrawAmount = 700;

            // Act
            account.Withdrawal((int)withdrawAmount);

            // Assert
            Assert.AreEqual(800, account.GetBalance);
        }

        [TestMethod]
        public void Everyday_GetFees_ReturnsZero()
        {
            // Arrange
            Account account = new Everyday(1000);

            // Act & Assert
            Assert.AreEqual(0, account.GetFees());
        }

        [TestMethod]
        public void Investment_GetInterest_ReturnsRandomInterest()
        {
            // Arrange
            Account account = new Inverstiment(50, 2000);

            // Act
            int interest = account.GetInterest();

            // Assert
            Assert.IsTrue(interest >= 10 && interest <= 20);
        }

        [TestMethod]
        public void Omni_GetOverdraft_ReturnsOverdraftLimit()
        {
            // Arrange
            Account account = new Omni(30, 10, 500, 3000);

            // Act & Assert
            Assert.AreEqual(500, account.GetOverdraft());
        }
    }
}
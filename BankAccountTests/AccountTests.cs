using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account acc;

        [TestInitialize]
        public void CreateDefaultAccount()
        {
            acc = new Account("J Doe");
        }

        [TestMethod()]
        [DataRow(100)]
        [DataRow(.01)]
        [DataRow(1.99)]
        [DataRow(9_999.99)]
        public void Deposit_APositiveAmount_AddToBalance(double depositAmount)
        {
            
            acc.Deposit(depositAmount);

            Assert.AreEqual(depositAmount, acc.Balance);
        }

        [TestMethod]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance()
        {
            // AAA - Arrange, Act, Assert
            //Arrange
            
            double depositAmount = 100;
            double expectedReturn = 100;

            //Act
            double returnValue = acc.Deposit(depositAmount);

            //Assert
            Assert.AreEqual(expectedReturn, returnValue);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        public void Deposit_ZeroOrLess_ThrowsArgumentException(double invalidDepositAmount)
        {
            //Arrange
            //Nothing to add

            //Assert => Act
            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => acc.Deposit(invalidDepositAmount));
        }


        [TestMethod]
        
        
        public void Withdraw_APositiveAmount_DecreasesBalance()
        {
            //Arrange
            double initialDeposit = 100;
            double withdrawalAmount = 50;
            double expectedBalance = initialDeposit - withdrawalAmount;
            //Act

            acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawalAmount);

            double actualBalance = acc.Balance;

            //Assert
            Assert.AreEqual(expectedBalance, actualBalance);

        }
        [TestMethod]
        public void Withdraw_PositiveAmount_ReturnsUpdatedBalance()
        {
            //Arrange
            double initialDeposit = 100;
            double withdrawalAmount = 50;
            double expectedBalance = initialDeposit - withdrawalAmount;

            //Act
            acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawalAmount);

            double updatedBalance = acc.Balance;

            //Assert
            Assert.AreEqual(expectedBalance, updatedBalance);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-.01)]
        [DataRow(-1000)]
        public void Withdraw_ZeroOrLess_ThrowsArgumentOutOfRangeException(double invalidWithdrawalAmount)
        {
            double initialDeposit = 100;

            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => acc.Deposit(invalidWithdrawalAmount));

        }

        [TestMethod]
        [DataRow(101)]
        [DataRow(1000)]
        [DataRow(10_000)]
        public void Withdraw_MoreThanAvailableBalance_ThrowsArgumentException(double invalidWithdrawalAmount)
        {
            double initialDeposit = 100;

            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => acc.Withdraw(invalidWithdrawalAmount));
        }

    }
}
// Withdrawing a positive amount - decrease balance
//Withdrawing 0 - Throws argument out of range exception
//Withdrawing negative amount - Throws ArgumentOutOfRange
//Withdrawing more than available balance = ArgumentException
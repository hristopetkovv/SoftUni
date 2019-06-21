using System;
using NUnit.Framework;

namespace BankAccount.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void Constructor_ShouldSetProperValues()
        {
            string name = "Gosho";
            decimal balance = 340.34m;

            var bankAccount = new BankAccount(name,balance);

            Assert.AreEqual(name, bankAccount.Name);
            Assert.AreEqual(balance, bankAccount.Balance);
        }

        [Test]
        [TestCase("1", 3450.34)]
        [TestCase("stringWithLengthMoreThan25Symbolsasdasdasdasd", 3450.34)]
        public void Constructor_ShouldThrowArgumentException_InvalidNameLength(string name, decimal balance)
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(name, balance));
        }

        [Test]
        [TestCase("Gosho", -1)]
        [TestCase("Pesho", -5)]
        public void Constructor_ShouldThrowArgumentException_InvalidBalance(string name, decimal balance)
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(name, balance));
        }

        [Test]
        [TestCase( -1)]
        [TestCase( -5)]
        public void DepositShouldThrowInvalidOperationException_InvalidAmount(decimal amount)
        {
            string name = "Gosho";
            decimal balance = 340.34m;

            var bankAccount = new BankAccount(name, balance);

            Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(0));
        }

        //balance has increased
        [Test]
        public void Deposit_ShouldIncreaseBalance_ValidAmount()
        {
            string name = "Gosho";
            decimal balance = 340.34m;

            var bankAccount = new BankAccount(name, balance);

            bankAccount.Deposit(120);

            var expected = 460.34m;
            var actual = bankAccount.Balance;

            Assert.AreEqual(expected, actual);
        }

        //withdraw invalid amount 0
        [Test]
        public void Withdraw_ShouldThrowInvalidOperationException_InvalidBalance()
        {
            string name = "Gosho";
            decimal balance = 340.34m;

            var bankAccount = new BankAccount(name, balance);

            var invalidAmount = -1;

            Assert.Throws<InvalidOperationException>(() => bankAccount.Withdraw(invalidAmount));
        }

        //insufficient funds
        [Test]
        public void Withdraw_ShouldThrowInvalidOperationException_InsuficientFunds()
        {
            string name = "Gosho";
            decimal balance = 340.34m;

            var bankAccount = new BankAccount(name, balance);

            var invalidAmount = 500;

            Assert.Throws<InvalidOperationException>(() => bankAccount.Withdraw(invalidAmount));
        }

        //balance has decreased
        //correct balance
        [Test]
        public void Withdraw_ShouldDecreaseBalanceCorrectly()
        {
            string name = "Gosho";
            decimal balance = 340.34m;

            var bankAccount = new BankAccount(name, balance);

            var validAmount = 40.34m;

            bankAccount.Withdraw(validAmount);

            var expected = 300;

            var actual = bankAccount.Balance;

            Assert.AreEqual(expected, actual);

        }
    }
}
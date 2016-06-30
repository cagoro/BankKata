using System.Collections.Generic;
using System.Linq;
using BankKata;
using Moq;
using NUnit.Framework;

namespace BankKataTests
{
    [TestFixture]
    public class AccountRepositoryTests
    {
        private Mock<IClock> _clock;
        private AccountRepository _accountRepository;

        [SetUp]
        public void Setup()
        {
            _clock = new Mock<IClock>();

            _accountRepository = new AccountRepository(_clock.Object);
        }

        [Test]
        public void GetAllTransactions_WhenThereAreNoTransactions_ReturnsEmptyList()
        {
            Assert.IsEmpty(_accountRepository.GetAllTransactions());
        }

        [Test]
        public void Deposit_DepositTransactionIsAdded()
        {
            _clock.Setup(x => x.Now()).Returns("10/04/2014");
            _accountRepository.Deposit(100);

            var expectedTransactions = new List<Transaction>() { new Transaction(100, "10/04/2014") };

            Assert.AreEqual(expectedTransactions, _accountRepository.GetAllTransactions());
        }

        [Test]
        public void Withdraw_WithdrawTransactionIsAdded()
        {
            _clock.Setup(x => x.Now()).Returns("10/04/2014");
            _accountRepository.Withdraw(50);

            var expectedTransactions = new List<Transaction>() {new Transaction(-50, "10/04/2014")};     

            Assert.AreEqual(expectedTransactions, _accountRepository.GetAllTransactions());
        }

        [Test]
        public void GetAllTransactions_SeveralTransactionsAddedOutOfOrder_AllTransactionsReturnedInDescendingDateOrder()
        {
           _clock.SetupSequence(x => x.Now())
               .Returns("10/04/2014")
               .Returns("12/04/2014")
               .Returns("11/04/2014");

           _accountRepository.Withdraw(50);
           _accountRepository.Deposit(100);
           _accountRepository.Deposit(1000);

            var expectedTransactions = new List<Transaction>()
            {
                new Transaction(100, "12/04/2014"),
                new Transaction(1000, "11/04/2014"),
                new Transaction(-50, "10/04/2014")
            };

            Assert.AreEqual(expectedTransactions, _accountRepository.GetAllTransactions());
        }
    }
}
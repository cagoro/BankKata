using System.Collections.Generic;
using BankKata;
using Moq;
using NUnit.Framework;

namespace BankKataTests
{
    [TestFixture]
    public class AccountTests
    {
        private Account _account;
        private Mock<IAccountRepository> _accountTracker;
        private Mock<IStatementPrinter> _statementPrinter;

        [SetUp]
        public void SetUp()
        {
            _accountTracker = new Mock<IAccountRepository>();
            _statementPrinter = new Mock<IStatementPrinter>();
            _account = new Account(_accountTracker.Object, _statementPrinter.Object);
        }

        [Test]
        public void Deposit_OneHundredPounds()
        {
            _account.Deposit(100);
            _accountTracker.Verify(x => x.Deposit(100));
        }

        [Test]
        public void Withdraw_OneHundredPounds()
        {
            _account.Withdraw(100);
            _accountTracker.Verify(x => x.Withdraw(100));

        }

        [Test]
        public void PrintStatement_AllTransactionsArePrinted()
        {
            var transactions = new List<Transaction>
            {
                new Transaction(-1000, "10/04/2014"),
                new Transaction(5000, "09/04/2014")
            };

            _accountTracker
                .Setup(x => x.GetAllTransactions())
                .Returns(transactions);

            _account.PrintStatement();

            _statementPrinter.Verify(x => x.Print(transactions));
        }
    }
}

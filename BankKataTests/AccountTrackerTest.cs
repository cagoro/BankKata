using System.Linq;
using BankKata;
using Moq;
using NUnit.Framework;

namespace BankKataTests
{
    [TestFixture]
    public class AccountTrackerTest
    {
        [Test]
        public void Deposit_DepositTransactionIsAdded()
        {
            var clock = new Mock<IClock>();

            clock.Setup(x => x.Now()).Returns("10/04/2014");

            var accountTracker = new AccountTracker(clock.Object);
            
            accountTracker.Deposit(100);

            var transactions = accountTracker.GetAllTransactions();
            Assert.IsNotEmpty(transactions);
            Assert.AreEqual(new Transaction(100, "10/04/2014"), transactions.First());
        }

    }
}
using BankKata;
using Moq;
using NUnit.Framework;

namespace BankKataTests
{
    [TestFixture]
    public class PrintStatementFeature
    {
        private Mock<IConsole> console;

        private Account account;
        private Mock<IClock> _clock;

        [SetUp]
        public void SetUp()
        {
            console = new Mock<IConsole>();

            _clock = new Mock<IClock>();

            account = new Account(new AccountRepository(_clock.Object), new StatementPrinter(console.Object));
        }

        [Test]
        public void PrintStatement_ContainingAllTransactions()
        {
            _clock.SetupSequence(x => x.Now())
                .Returns("01/04/2014")
                .Returns("02/04/2014")
                .Returns("10/04/2014");

            account.Deposit(1000);
            account.Withdraw(100);
            account.Deposit(500);
                
            account.PrintStatement();

            console.Verify(x => x.PrintLine("DATE | AMOUNT | BALANCE"));
            console.Verify(x => x.PrintLine("10/04/2014 | 500.00 | 1400.00"));
            console.Verify(x => x.PrintLine("02/04/2014 | -100.00 | 900.00"));
            console.Verify(x => x.PrintLine("01/04/2014 | 1000.00 | 1000.00"));
        }

    }
}

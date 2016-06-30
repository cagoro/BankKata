using System;
using BankKata;
using Moq;
using NUnit.Framework;

namespace BankKataTests
{
    public interface IConsole
    {
        void PrintLine(string dateAmountBalance);
    }

    [TestFixture]
    public class PrintStatementFeature
    {
        private Mock<IConsole> console;

        private Account account;

        [SetUp]
        public void SetUp()
        {
            console = new Mock<IConsole>();

            Mock<IClock> clock = new Mock<IClock>();

            account = new Account(new AccountRepository(clock.Object), new StatementPrinter());
        }

        [Test]
        public void PrintStatement_ContainingAllTransactions()
        {
            account.Deposit(1000);
            account.Withdraw(100);
            account.Deposit(500);
                
            account.PrintStatement();

            console.Verify(x => x.PrintLine("DATE | AMOUNT | BALANCE"));
            console.Verify(x => x.PrintLine("10/04/2014 | 500.00| 1400.00"));
            console.Verify(x => x.PrintLine("02/04/2014 | -100.00 | 900.00"));
            console.Verify(x => x.PrintLine("01/04/2014 | 1000.00 | 1000.00"));
        }

    }
}

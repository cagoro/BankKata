using System.Collections.Generic;
using BankKata;
using Moq;
using NUnit.Framework;

namespace BankKataTests
{
    [TestFixture]
    class StatementPrinterTests
    {
        [Test]
        public void Print_WhenNoTransactions_HeaderOnlyIsPrinted()
        {
            var console = new Mock<IConsole>();
            var statementPrinter = new StatementPrinter(console.Object);
            statementPrinter.Print(new List<Transaction>());
            console.Verify(x => x.PrintLine("DATE | AMOUNT | BALANCE"));
        }
    }
}

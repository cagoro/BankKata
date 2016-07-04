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

        [Test]
        public void Print_WhenMultipleTransactions_TransactionsPrintedInReverseChronologicalOrder()
        {
            var console = new Mock<IConsole>();
            var statementPrinter = new StatementPrinter(console.Object);

            var transactions = new List<Transaction>
            {
                new Transaction(-50, "10/04/2014"),
                new Transaction(100, "12/04/2014"),
                new Transaction(1000, "11/04/2014")
            };

            statementPrinter.Print(transactions);

            console.Verify(x => x.PrintLine("DATE | AMOUNT | BALANCE"));
            console.Verify(x => x.PrintLine("12/04/2014 | 100.00 | 1050.00"));
            console.Verify(x => x.PrintLine("11/04/2014 | 1000.00 | 950.00"));
            console.Verify(x => x.PrintLine("10/04/2014 | -50.00 | -50.00"));
        }
    }
}

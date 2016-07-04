using System;
using System.Collections.Generic;
using System.Linq;

namespace BankKata
{
    public class StatementPrinter : IStatementPrinter {
        
        private readonly IConsole _console;

        public StatementPrinter(IConsole console)
        {
            _console = console;
        }

        public void Print(List<Transaction> transactions)
        {
            PrintHeaders();

            var sortedTransactions = GetSortedTransactions(transactions);

            var lineStatements = CreateLineStatements(sortedTransactions);

            PrintLineStatements(lineStatements);
        }

        private void PrintLineStatements(List<StatementLine> lineStatements)
        {
            lineStatements.ForEach(lineStatement => _console.PrintLine(lineStatement.ToString()));
        }

        private void PrintHeaders()
        {
            _console.PrintLine("DATE | AMOUNT | BALANCE");
        }

        private static IOrderedEnumerable<Transaction> GetSortedTransactions(List<Transaction> transactions)
        {
            return transactions.OrderBy(x => DateTime.Parse(x.Date));
        }

        private static List<StatementLine> CreateLineStatements(IEnumerable<Transaction> sortedTransactions)
        {
            int runningBalance = 0;
            var lineStatements = new List<StatementLine>();
            foreach (var transaction in sortedTransactions)
            {
                runningBalance += transaction.Amount;
                lineStatements.Add(new StatementLine(transaction, runningBalance));
            }
            return lineStatements;
        }

        class StatementLine
        {
            private readonly Transaction _transaction;
            private readonly int _balance;

            public StatementLine(Transaction transaction, int balance)
            {
                _transaction = transaction;
                _balance = balance;
            }

            public override string ToString()
            {
                return string.Format("{0} | {1}.00 | {2}.00", _transaction.Date, _transaction.Amount, _balance);
            }
        }
    }
}


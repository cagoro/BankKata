using System.Collections.Generic;

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
            throw new System.NotImplementedException();
        }
    }
}


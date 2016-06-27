using System.Collections.Generic;

namespace BankKata
{
    public interface IStatementPrinter {
        void Print(List<Transaction> transactions);
    }
}
using System.Collections.Generic;

namespace BankKata
{
    public interface IAccountTracker {
        void Deposit(int amount);
        void Withdraw(int amount);
        List<Transaction> GetAllTransactions();
    }
}
using System.Collections.Generic;

namespace BankKata
{
    public interface IAccountRepository {
        void Deposit(int amount);
        void Withdraw(int amount);
        List<Transaction> GetAllTransactions();
    }
}
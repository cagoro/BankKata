using System.Collections.Generic;

namespace BankKata
{
    public class AccountTracker : IAccountTracker {

        private readonly IClock _clock;

        public AccountTracker(IClock clock)
        {
            _clock = clock;
        }

        public void Deposit(int amount)
        {
        }

        public void Withdraw(int amount)
        {
            throw new System.NotImplementedException();
        }

        public List<Transaction> GetAllTransactions()
        {
            throw new System.NotImplementedException();
        }
    }
}
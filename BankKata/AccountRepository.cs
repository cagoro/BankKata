using System;
using System.Collections.Generic;

namespace BankKata
{
    public class AccountRepository : IAccountRepository {

        private readonly IClock _clock;
        private readonly List<Transaction> _transactions; 

        public AccountRepository(IClock clock)
        {
            _clock = clock;
            _transactions = new List<Transaction>();
        }

        public void Deposit(int amount)
        {
            _transactions.Add(new Transaction(amount, _clock.Now()));
        }

        public void Withdraw(int amount)
        {
            _transactions.Add(new Transaction(-amount, _clock.Now()));
        }

        public List<Transaction> GetAllTransactions()
        {
            return _transactions;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

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
            _transactions.Sort((x, y) => -DateTime.Parse(x.Date).CompareTo(DateTime.Parse(y.Date)));
            return _transactions;
        }
    }
}
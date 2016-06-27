using System.Collections.Generic;

namespace BankKata
{
    public class Account
    {
        private readonly IAccountTracker _accountTracker;
        private readonly IStatementPrinter _statementPrinter;

        public Account(IAccountTracker accountTracker, IStatementPrinter statementPrinter)
        {
            _accountTracker = accountTracker;
            _statementPrinter = statementPrinter;
        }

        public void Deposit(int amount)
        {
            _accountTracker.Deposit(amount);
        }

        public void Withdraw(int amount)
        {
            _accountTracker.Withdraw(amount);
        }

        public void PrintStatement()
        {
            _statementPrinter.Print(_accountTracker.GetAllTransactions());
        }
    }
}

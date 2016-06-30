using System.Collections.Generic;

namespace BankKata
{
    public class Account
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IStatementPrinter _statementPrinter;

        public Account(IAccountRepository accountRepository, IStatementPrinter statementPrinter)
        {
            _accountRepository = accountRepository;
            _statementPrinter = statementPrinter;
        }

        public void Deposit(int amount)
        {
            _accountRepository.Deposit(amount);
        }

        public void Withdraw(int amount)
        {
            _accountRepository.Withdraw(amount);
        }

        public void PrintStatement()
        {
            _statementPrinter.Print(_accountRepository.GetAllTransactions());
        }
    }
}

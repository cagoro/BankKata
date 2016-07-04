using System;

namespace BankKata
{
    class BankKataSystem
    {
        static void Main()
        {
            var console = new Console();

            var clock = new Clock();

            var account = new Account(new AccountRepository(clock), new StatementPrinter(console));

            account.Deposit(100000);
            account.Withdraw(45000);
            account.Deposit(5);

            account.PrintStatement();

            System.Console.ReadLine();
        }


        class Console : IConsole
        {
            public void PrintLine(string line)
            {
                System.Console.WriteLine(line);
            }
        }

        class Clock : IClock
        {

            public string Now()
            {
                string format = "dd/MM/yyyy";
                return DateTime.Now.ToString(format);
                
            }
        }


    }

}

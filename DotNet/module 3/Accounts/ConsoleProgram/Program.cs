using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountsLib;

namespace ConsoleProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            string action;
            Console.WriteLine("enter amount to deposit to your new account");
            int amount = int.Parse(Console.ReadLine());
            Account acc = AccountFactory.CreateAccount(amount);
            do
            {
                Console.WriteLine("What action would you like to perform on your account?");
                Console.WriteLine("a.Deposit \nb.Withdraw\nc.Query your balance\nd.Continue");
                action = Console.ReadLine();
                switch (action)
                {
                    case "a":
                        Console.WriteLine("How much would you like to Deposit?");
                        amount = int.Parse(Console.ReadLine());
                        acc.Deposit(amount);
                        break;
                    case "b":
                        Console.WriteLine("How much would you like to Withdraw?");
                        amount = int.Parse(Console.ReadLine());
                        acc.Withdraw(amount);
                        break;
                    case "c":
                        Console.WriteLine($"Your account's balance is: {acc.Balance}");
                        break;
                    case "d": break;
                    default: Console.WriteLine("Wrong input");
                        break;
                }
            } while (action != "d");

            Account acc2 = AccountFactory.CreateAccount(0);
            Console.WriteLine("new Account was created, how much would you like to transfer?");
            amount = int.Parse(Console.ReadLine());
            acc.Transfer(acc2, amount);
            Console.WriteLine($"New Balance:\nAccount no.1: {acc.Balance} \nAccount no.2: {acc2.Balance}");

        }
    }
}

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
            int amount;
            int.TryParse(Console.ReadLine(),out amount);
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
                        int.TryParse(Console.ReadLine(), out amount);
                        try
                        { acc.Deposit(amount); }
                        catch(ArgumentOutOfRangeException e) {
                            Console.WriteLine("Unable to Deposit a negative number");
                        }
                        break;
                    case "b":
                        Console.WriteLine("How much would you like to Withdraw?");
                        int.TryParse(Console.ReadLine(), out amount);
                        try
                        {
                            acc.Withdraw(amount);
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            Console.WriteLine("Unable to Withdraw a negative number");
                        }
                        catch (InsufficientFundsException e)
                        {
                            //You should have used the message from the exception
                            Console.WriteLine("Unable to Withdraw, amount too great");
                        }
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
            int.TryParse(Console.ReadLine(), out amount);
            acc.Transfer(acc2, amount);
        }
    }
}

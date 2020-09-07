using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    public class Account
    {
        int id,sum;

        public Account(int id)
        {
            sum = 0;
            this.id = id;
        }//Constructor

        public int ID
        {
            get
            {
                return id;
            }//get - ID
        }// ID property


        public void Deposit(int amount)
        {
            //You should have added a message to the exception
            if (amount < 0) throw new ArgumentOutOfRangeException();
            sum += amount;
            
        }//Deposit

        public int Withdraw(int amount)
        {
            //You should have added a message to the exception
            if (amount < 0) throw new ArgumentOutOfRangeException();

            //You should have added a message to the exception
            if (amount > sum) throw new InsufficientFundsException();
            sum -= amount;
            return amount;
        }//Withdraw - returns the amount that was withdrawn

        public int Balance
        {
            get
            {
                return sum;
            }//get - Balance
        }// Balance property

        public void Transfer(Account acc,int amount)
        {
            try
            {
                acc.Deposit(Withdraw(amount));
                Console.WriteLine("Transfer Complete.");

                //The exception should have been catched in main.
            }catch (ArgumentOutOfRangeException e) {
                //You should have used the message from the exception
                Console.WriteLine("Unable to Transfer a negative amount");
            }
            finally
            {
                //where is the try-finally and the logging with the balance before and after the operation is done?
                Console.WriteLine($"\nAccounts Balance:\nAccount no.1: {Balance} \nAccount no.2: {acc.Balance}");
            }
        }// Transfer
    }//Class Account
}

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
            if (amount > 0)
                 sum += amount;
        }//Deposit

        public int Withdraw(int amount)
        {
            if (amount > sum) amount = sum;
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
            acc.Deposit(Withdraw(amount));
        }// Transfer
    }//Class Account
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    public static class AccountFactory
    {
        private static int accountsNum = 0;

        public static Account CreateAccount(int balance)
        {
            Account acc = new Account(++accountsNum);
            acc.Deposit(balance);
            return acc;
        }// Create Account 
    }
}
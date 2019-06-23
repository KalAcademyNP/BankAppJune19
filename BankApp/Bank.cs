using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    static class Bank
    {
        /// <summary>
        /// Creates a new account
        /// </summary>
        /// <param name="emailAddress">Email address of the account</param>
        /// <param name="accountType">Type of account</param>
        /// <param name="initialDeposit">Initial deposit</param>
        /// <returns>The newly created account</returns>
        public static Account CreateAccount(string emailAddress,
            TypeOfAccount accountType = TypeOfAccount.Checking, 
            decimal initialDeposit = 0)
        {
            var account = new Account
            {
                EmailAddress = emailAddress,
                AccountType = accountType
            };
            if (initialDeposit > 0)
            {
                account.Deposit(initialDeposit);
            }

            return account;
        }
    }
}

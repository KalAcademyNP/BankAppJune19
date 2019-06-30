using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp
{
    static class Bank
    {
        private static List<Account> accounts = new List<Account>();
        private static List<Transaction> transactions = new List<Transaction>();

        
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
            accounts.Add(account);
            return account;
        }

        public static IEnumerable<Account> 
            GetAccountsByEmailAddress(string emailAddress)
        {
            return accounts.Where(a => a.EmailAddress == emailAddress);
        }

        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = FindAccountByAccountNumber(accountNumber);
            account.Deposit(amount);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                Description = "Bank deposit",
                Amount = amount,
                AccountNumber = accountNumber,
                TransactionType = TransactionType.Credit
            };
            transactions.Add(transaction);

        }

        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = FindAccountByAccountNumber(accountNumber);
            account.Withdraw(amount);
            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                Description = "Bank withdrawal",
                Amount = amount,
                AccountNumber = accountNumber,
                TransactionType = TransactionType.Debit
            };
            transactions.Add(transaction);
        }

        private static Account FindAccountByAccountNumber
            (int accountNumber)
        {
            var account =
                accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                //Throw exception
                return null;
            }

            return account;
        }
    }
}

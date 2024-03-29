﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp
{
    public static class Bank
    {
        private static BankContext db = new BankContext();
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
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }

        public static IEnumerable<Transaction> GetTransactionsByAccountNumber(int accountNumber)
        {
            return db.Transactions.Where(t => t.AccountNumber == accountNumber).OrderByDescending(t => t.TransactionDate);
        }

        public static IEnumerable<Account> 
            GetAccountsByEmailAddress(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentNullException("emailAddress", "Email Address is required!");
            }
            return db.Accounts.Where(a => a.EmailAddress == emailAddress);
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
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        /// <summary>
        /// Withdraw money from the account
        /// </summary>
        /// <param name="accountNumber">Account number</param>
        /// <param name="amount">Amount to withdraw</param>
        /// <exception cref="ArgumentException" />
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
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public static Account FindAccountByAccountNumber
            (int accountNumber)
        {
            var account =
                db.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                throw new ArgumentException("Invalid account number!");
            }

            return account;
        }

        public static void EditAccount(Account updatedAccount)
        {
            var oldAccount = 
                FindAccountByAccountNumber(updatedAccount.AccountNumber);
            oldAccount.EmailAddress = updatedAccount.EmailAddress;
            oldAccount.AccountType = updatedAccount.AccountType;

            db.SaveChanges();
        }

        public static void DeleteAccount(int accountNumber)
        {
            var account = FindAccountByAccountNumber(accountNumber);
            db.Accounts.Remove(account);
            db.SaveChanges();
        }
    }
}

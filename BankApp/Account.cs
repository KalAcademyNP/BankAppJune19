using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    /// <summary>
    /// A bank account where
    /// you can deposit or withdraw money
    /// </summary>
    class Account
    {
        #region Properties
        /// <summary>
        /// Unique number for the account
        /// </summary>
        public int AccountNumber { get; set; }

        public string EmailAddress { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Deposit money into your account
        /// </summary>
        /// <param name="amount">Amount to be deposited</param>
        /// <returns>New balance</returns>
        public decimal Deposit(decimal amount)
        {
            Balance += amount;
            return Balance;
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }
        #endregion
    }
}

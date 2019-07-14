using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{

    enum TypeOfAccount
    {
        Checking,
        Savings,
        CD,
        Loan
    }

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
        public int AccountNumber { get;  set; }

        public string EmailAddress { get; set; }
        public TypeOfAccount AccountType { get; set; }
        public decimal Balance { get;  set; }
        public DateTime CreatedDate { get;  set; }
        #endregion

        #region Constructors

        public Account()
        {
            CreatedDate = DateTime.Now;
        }

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
            if (amount > Balance)
            {
                //throw new ArgumentException("Insufficient fund in the account!");
                throw new NSFException();
            }
            Balance -= amount;
        }
        #endregion
    }
}

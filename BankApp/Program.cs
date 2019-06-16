using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Object = instance the class
            //var myAccount = new Account()
            //{
            //    EmailAddress = "test@test.com",
            //    AccountType = "Checking"
            //};
            //myAccount.Deposit(200);
            //Console.WriteLine($"AN: {myAccount.AccountNumber}, EA: {myAccount.EmailAddress}, B: {myAccount.Balance:C}, CD: {myAccount.CreatedDate}");

            //var myAccount2 = new Account()
            //{
            //    EmailAddress = "test2@test.com",
            //    AccountType = "Savings"
            //};
            //myAccount2.Deposit(500);
            //Console.WriteLine($"AN: {myAccount2.AccountNumber}, EA: {myAccount2.EmailAddress}, B: {myAccount2.Balance:C}, CD: {myAccount2.CreatedDate}");

            Console.WriteLine("********************");
            Console.WriteLine("Welcome to my bank!");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Create a new account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Print all accounts");

        }
    }
}

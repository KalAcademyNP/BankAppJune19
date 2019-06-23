using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Console.WriteLine("********************");
            Console.WriteLine("Welcome to my bank!");
            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create a new account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Print all accounts");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting the bank!");
                        return;
                    case "1":
                        Console.Write("Email Address: ");
                        var emailAddress = Console.ReadLine();

                        Console.WriteLine("Account types: ");
                        var accountTypes = Enum.GetNames(typeof(TypeOfAccount));
                        for(var i = 0; i < accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i}. {accountTypes[i]}");
                        }
                        Console.Write("Select an account type: ");
                        var accountType = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Initial deposit: ");
                        var amount = Convert.ToDecimal(Console.ReadLine());

                        var account = Bank.CreateAccount(emailAddress,
                            (TypeOfAccount)accountType, amount);
                        Console.WriteLine($"AN : {account.AccountNumber}, B: {account.Balance:C}, AT: {account.AccountType}, CD: {account.CreatedDate}");
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

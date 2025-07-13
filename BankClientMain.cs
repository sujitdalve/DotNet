using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BankLibraryDllPrjFinal;

namespace BankConsoleApplProject
{
    internal class BankClientMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to BankKibrary Menu!!");
            Console.WriteLine("-------------------------------------------------------");

            IBankRepository bankRepository = new BankRepository();

            while (true)
            {

                Console.WriteLine("\nBank Menu:");
                Console.WriteLine("1. Create New Account");
                Console.WriteLine("2. Display All Accounts");
                Console.WriteLine("3. View Account Details");
                Console.WriteLine("4. Deposit Amount");
                Console.WriteLine("5. Withdraw Amount");
                Console.WriteLine("6. View Transactions");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateNewAccount(bankRepository);
                        break;
                    case "2":
                        DisplayAllAccounts(bankRepository);
                        break;
                    case "3":
                        ViewAccountDetails(bankRepository);
                        break;
                    case "4":
                        DepositAmount(bankRepository);
                        break;
                    case "5":
                        WithdrawAmount(bankRepository);
                        break;
                    case "6":
                        ViewTransactions(bankRepository);
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

       // static void InsertData(IBankRepository bankRepository)
       // {
            // Insert some initial accounts
         //   BankRepository.NewAccount(new SBAccount
        //    {
         //       AccountNumber = 101,
         //       CustomerName = "Akash More",
         //       CustomerAddress = "123 Main Road,KarveNagar.",
          //      CurrentBalance = 50000
 //           });

        //   BankRepository.NewAccount(new SBAccount
        //    {
            //    AccountNumber = 102,
        //        CustomerName = "Tejas Halkude",
         //       CustomerAddress = "456 Hingane,Udgir.",
        //        CurrentBalance = 705000
       //     });

            // Insert some initial transactions for these accounts
       //     bankRepository.DepositAmount(101, 20000);
      //      bankRepository.WithdrawAmount(101, 10500);
      //      bankRepository.DepositAmount(102, 35000);
     //   }

        static void CreateNewAccount(IBankRepository bankRepository)
        {
           
            try
            {

               
                Console.Write("Enter Account Number: ");
                int accNo = int.Parse(Console.ReadLine());

                Console.Write("Enter Customer Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Customer Address: ");
                string address = Console.ReadLine();

                Console.Write("Enter Initial Balance: ");
                decimal balance = decimal.Parse(Console.ReadLine());

                SBAccount newAccount = new SBAccount
                {
                    AccountNumber = accNo,
                    CustomerName = name,
                    CustomerAddress = address,
                    CurrentBalance = balance
                };

                bankRepository.NewAccount(newAccount);
                Console.WriteLine("Account created successfully.!!!");

                // Database creation 

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void DisplayAllAccounts(IBankRepository bankRepository)
        {
            try
            {
                var accounts = bankRepository.GetAllAccounts();
                foreach (var account in accounts)
                {
                    Console.WriteLine($"Account Number: {account.AccountNumber}, Name: {account.CustomerName}, Balance: {account.CurrentBalance}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ViewAccountDetails(IBankRepository bankRepository)
        {
            try
            {
                Console.Write("Enter Account Number: ");
                int accNo = int.Parse(Console.ReadLine());

                var account = bankRepository.GetAccountDetails(accNo);
                Console.WriteLine($"Account Number: {account.AccountNumber}, Name: {account.CustomerName}, Address: {account.CustomerAddress}, Balance: {account.CurrentBalance}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void DepositAmount(IBankRepository bankRepository)
        {
            try
            {
                Console.Write("Enter Account Number: ");
                int accNo = int.Parse(Console.ReadLine());

                Console.Write("Enter Amount to Deposit: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                bankRepository.DepositAmount(accNo, amount);
                Console.WriteLine("Amount deposited successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void WithdrawAmount(IBankRepository bankRepository)
        {
            try
            {
                Console.Write("Enter Account Number: ");
                int accNo = int.Parse(Console.ReadLine());

                Console.Write("Enter Amount to Withdraw: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                bankRepository.WithdrawAmount(accNo, amount);
                Console.WriteLine("Amount withdrawn successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ViewTransactions(IBankRepository bankRepository)
        {
            try
            {
                Console.Write("Enter Account Number: ");
                int accNo = int.Parse(Console.ReadLine());

                var transactions = bankRepository.GetTransactions(accNo);
                foreach (var transaction in transactions)
                {
                    Console.WriteLine($"Transaction ID: {transaction.TransactionId}, Date: {transaction.TransactionDate}, Amount: {transaction.Amount}, Type: {transaction.TransactionType}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

using EFcoreBankPrjEx.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcoreBankPrjEx
{
    public class SbAccountMain
    {
        public static BankdbContext context = new BankdbContext();
      private static Sbaccount a;

        public static void Main()
        {
            // 2.for deleting records
           /* Console.WriteLine("Enter AccNo which you want to delete:");
            int accountno = Convert.ToInt32(Console.ReadLine());

            DeleteAccount(accountno);  */

            // 1. Displaying Records

            /* Console.WriteLine("Displaying Records from SBAccount table: ");
             Console.WriteLine("--------------------------------------------------");
             foreach (var item in context.Sbaccounts)
             {
                 Console.WriteLine(item.AccNo + " " + item.Cname + " " + item.Caddress + " "+item.CurrentBalance);
             }
            */
            // AddAccount();
            //   FindAccountByAccNo();

            // GetAllAccounts();

            Console.WriteLine("Enter AccNo which you want to Update:");
            int accountnum = Convert.ToInt32(Console.ReadLine());

            Sbaccount updatedAccount = new Sbaccount
            {
               AccNo= accountnum,
               Cname= "Sujit Dalve",
               Caddress= "Pune",
               CurrentBalance=4505151000
               
            };
            UpdateAccount(accountnum, updatedAccount);
            
           


        }

        private static void AddAccount()
        {
            Console.WriteLine("Adding new Accounts to SBAccount Table:");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Enter AccNo,CustomerName,CustomerAddress and Current Balance");

            Sbaccount a = new Sbaccount();
            a.AccNo = Convert.ToInt32(Console.ReadLine());
            a.Cname = Console.ReadLine();
            a.Caddress = Console.ReadLine();
            a.CurrentBalance=float.Parse(Console.ReadLine());

            context.Sbaccounts.Add(a);
            context.SaveChanges();
            
        }

        private static void GetAllAccounts()
        {
            foreach (var account in context.Sbaccounts)
            {
                Console.WriteLine(account.AccNo +" "+ account.Cname +" "+ account.Caddress + " " +account.CurrentBalance );
            }
        }

        private static void FindAccountByAccNo()
        {
            Console.WriteLine("Finding Account by Passing input AccNo through user...");
            Console.WriteLine("----------------------------------------------------------");

            Console.WriteLine("Enter AccNo which you want to Find:");
            int accountno=Convert.ToInt32(Console.ReadLine());
            Sbaccount a=context.Sbaccounts.SingleOrDefault(x => x.AccNo == accountno);

            if (a != null)
            {
                Console.WriteLine(a.AccNo + " " + a.Cname + " " + a.Caddress + " " + a.CurrentBalance);
            }
            else
            {
                Console.WriteLine("Sorry!!! Account not found for given AccNo.");
            }
        }

        private static void DeleteAccount(int id)
        {
           Sbaccount a = context.Sbaccounts.Where(x => x.AccNo == id).SingleOrDefault();
            context.Sbaccounts.Remove(a);
            context.SaveChanges();
        }

        private static void UpdateAccount(int id, Sbaccount account )
        {
          Sbaccount existingAccount = context.Sbaccounts.SingleOrDefault(x => x.AccNo == id);
            if (existingAccount != null)
            {
                int maxCnameLength = 20;
                account.Cname = account.Cname.Length > maxCnameLength ? account.Cname.Substring(0, maxCnameLength) : account.Cname;

                existingAccount.Cname = account.Cname;
                existingAccount.CurrentBalance = account.CurrentBalance;
                context.SaveChanges();

                Console.WriteLine("Account got updated successfully !!");
            }
            else
            {
                Console.WriteLine("Account not found!");
            }
        }

    }
}

    



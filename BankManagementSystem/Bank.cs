using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem
{
    internal static  class Bank
    {

        public static List<Account> allAccounts = new List<Account>();
        public static List<string> allMobiles = new List<string>();

        public static void AddAccount (Account account)
        {
            if (account != null)
            {

                allAccounts.Add(account);
                
            }
            else
            {
                Console.WriteLine("Please Create an Account!");
            }
        }

        public static void ShowAllAccount ()
        {
            foreach (Account account in allAccounts)
            {
                Console.WriteLine("-------------------------------------------------------");
                account.DisplayDetails();
                Console.WriteLine("-------------------------------------------------------");
            }
        }

        public static Account SeachAccontNo(string accNo)
        {
            foreach (Account acc in allAccounts)
            {
                if (acc.AccountNo == accNo)
                {
                    return acc;
                }
            }
            return null;

        }
         public static string GenerateAccountNo (string mobileNo)
        {
            string bankCode = "101";
            string mobileSuffix = mobileNo.Substring(mobileNo.Length - 6);
            Random rand = new Random();
            int randomPart = rand.Next(100, 999);
            string year = DateTime.Now.Year.ToString();
            string accountNumber = $"{bankCode}{mobileSuffix}{randomPart}{year}";
            return accountNumber;

        }

        public static bool AddMobileNumber(string mobileNo)
        {
            if (!allMobiles.Contains(mobileNo))
            {
                allMobiles.Add(mobileNo);
                return true;

            }
           return false;
           
           
        }

        
    }
}

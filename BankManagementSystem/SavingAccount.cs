using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BankManagementSystem
{
     class SavingAccount : Account
    {
        protected static int Rate=8;

        public SavingAccount(string AccountHolderName, string AccountNo):base(AccountHolderName,AccountNo) 
        { 

        }
        public override void Deposit (double amount)
        {
            Balance += amount;
            Console.WriteLine("You have deposited Amount: " + amount);
            Console.WriteLine("Your Current Balance: " + Balance);
        }

        public override void Withdraw (double amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient Balance");
            }
            else
            {
                Balance-=amount;
                Console.WriteLine("You have WithDraw amount of : " + amount);
                Console.WriteLine("Your updated Balance: "+Balance);
            }
        }

        public override void DisplayDetails ()
        {
            Console.WriteLine("Name: " + AccountHolderName);
            Console.WriteLine("AccountNumber:" + AccountNo);
            Console.WriteLine("Balance: " + Balance);
            Console.WriteLine($"Account type:{"Saving Account"}" );
        }

        public  void CalculateInterest (double year)
        {
            double intrest = Balance * year * Rate / 100;
            double TotalAmount = Balance + intrest;
            Console.WriteLine("Your Calculated Intrest: " + intrest);
            Console.WriteLine("Total Amount: " + TotalAmount);
        }


        /*public override void TransferMoney (Account recever, double Amount)
        {
            if (recever == null)
            {
                Console.WriteLine("Not avaliable Data");
            }
            if (Amount <= 0)
            {
                Console.WriteLine("Can't be negative money");
            }
            Balance -= Amount;
            recever.Deposit(Amount);
        }*/

    }
}

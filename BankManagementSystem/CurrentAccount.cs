using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BankManagementSystem
{
    internal class CurrentAccount:Account
    {
        public static double OverdraftLimit = 50000;
        public CurrentAccount (string AccountHolderName, string AccountNo) : base(AccountHolderName, AccountNo)
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
            if (amount > Balance+OverdraftLimit)
            {
                Console.WriteLine("Insufficient Balance");
            }
            else
            {
                if (amount > Balance) 
                {
                    if (Balance == 0 && amount <= OverdraftLimit)
                    {
                        OverdraftLimit-= amount;
                        Console.WriteLine("You have Withdraw money from Overdraft: " + amount);
                        Console.WriteLine("Your Current OverDraftLimit is:" + OverdraftLimit);
                        Balance -= amount;
                    }
                    else
                    {
                        Balance = Balance + OverdraftLimit - amount;
                        Console.WriteLine("You have WithDraw amount of : " + amount);
                        Console.WriteLine("Your updated Balance: " + Balance);
                    }
                    
                }
                else
                {
                    Balance -= amount;
                    Console.WriteLine("You have WithDraw amount of : " + amount);
                    Console.WriteLine("Your updated Balance: " + Balance);
                }
                
                
            }
        }

        public override void DisplayDetails ()
        {
            Console.WriteLine("Name: " + AccountHolderName);
            Console.WriteLine("AccountNumber:" + AccountNo);
            Console.WriteLine("Balance: " + Balance);
            Console.WriteLine("Your OverdraftLimit: " + OverdraftLimit);
            Console.WriteLine($"Account type:{"Current Account"}");
        }


        public override void TransferMoney (Account receiver, double Amount)
        {
            if (receiver == null)
            {
                Console.WriteLine("Not avaliable Data");
            }
            if (Amount <= 0)
            {
                Console.WriteLine("Can't be negative money");
            }
            if (Amount > Balance + OverdraftLimit)
            {
                Console.WriteLine("Transfer failed: insufficient balance and overdraft limit.");
                return;
            }
            if (Amount <= Balance)
            {
                Balance -= Amount;
            }
            else
            {
                double extra = Amount - Balance;
                Balance = 0;
                OverdraftLimit -= extra;
            }
            receiver.Deposit(Amount);

            Console.WriteLine($"Transferred {Amount} from {AccountNo} to {receiver.AccountNo}");
            Console.WriteLine($"Remaining balance: {Balance}, Overdraft Limit: {OverdraftLimit}");
        }
    }
}

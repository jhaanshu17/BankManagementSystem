using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem
{
    internal abstract class Account : INotification
    {
        public string AccountNo { get; private set; }
        public string AccountHolderName { get; private set; }
        public double Balance { get; protected set; }

       

        public Account (string AccountHolderName, string AccountNo) 
        { 
            Balance = 0;
            this.AccountHolderName = AccountHolderName;
            this. AccountNo=AccountNo;

        }
        public abstract void Deposit (double amount);
        public abstract void Withdraw (double amount);
        public abstract void DisplayDetails ();


        public void getMessage()
        {
            Console.WriteLine("You have Create Successfully Your Account");
        }

        public abstract void TransferMoney (Account recever, double Amount);
        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem
{
    internal abstract class Account
    {
        public string  AccountNo;
        public  string AccountHolderName;
        public double Balance;
        public Account (string AccountHolderName, string AccountNo) 
        { 
            Balance = 0;
           this.AccountHolderName = AccountHolderName;
            this. AccountNo=AccountNo;

        }
        public abstract void Deposit (double amount);
        public abstract void Withdraw (double amount);
        public abstract void DisplayDetails ();
      

    }
}

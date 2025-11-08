using BankManagementSystem;
using System.Linq.Expressions;
string accNumber;
Account account = null;
string name;
string mobileNo;
do
{
    Console.WriteLine("------------------Welcome to our State Bank Of India--------------");
    Console.WriteLine("Enter 1 For Create Account");
    Console.WriteLine("Enter 2 For Deposit Money");
    Console.WriteLine("Enter 3 For Withdraw Money");
    Console.WriteLine("Enter 4 For View Account Details");
    Console.WriteLine("Enter 5 For View All Account");
    Console.WriteLine("Enter 6 For Calculate Intrest for Saving Accounts");
    Console.WriteLine("Enter 7 For Exit ");

    Console.Write("Enter Your Options:");
    int option = Convert.ToInt32(Console.ReadLine());
   

    if (option == 1)
    {
        Console.WriteLine("Enter 1 for Saving Account");
        Console.WriteLine("Enter 2 for Current Account");
        Console.Write("Enter Your Options:");
        int op = Convert.ToInt32(Console.ReadLine());

        if (op == 1)
        {
            try
            {


                while (true)
                {
                    Console.Write("Enter Your Name: ");
                    name = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(name) && name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid Name (letters and spaces only).");
                    }

                }



                while (true)
                {
                    Console.WriteLine("Enter your Mobile Number");
                    mobileNo = Console.ReadLine();

                    if (mobileNo.Length == 10 && mobileNo.All(char.IsDigit))
                    {
                       
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter valid Mobile Number");
                    }
                    
                }
                while (true)
                {
                    if (Bank.AddMobileNumber(mobileNo))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This Number already exists!");
                        Console.WriteLine("Please enter another Number!");
                        mobileNo = Console.ReadLine();
                    }
                }
                accNumber = Bank.GenerateAccountNo(mobileNo);
                Console.WriteLine("Your AccountNo Is:" + accNumber);
                account = new SavingAccount(name, accNumber);
                Bank.AddAccount(account);
                account.getMessage();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Data");
            }
        }
        else
        {
            try
            {
                while (true)
                {
                    Console.Write("Enter Your Name: ");
                    name = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(name) && name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid Name (letters and spaces only).");
                    }

                }
                while (true)
                {
                    Console.WriteLine("Enter your Mobile Number");
                    mobileNo = Console.ReadLine();
                    if (mobileNo.Length == 10 && mobileNo.All(char.IsDigit))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter valid Mobile Number");
                    }

                }

                while (true)
                {
                    if (Bank.AddMobileNumber(mobileNo))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This Number already exists!");
                        Console.WriteLine("Please enter another Number!");
                        mobileNo = Console.ReadLine();
                    }
                }

                accNumber = Bank.GenerateAccountNo(mobileNo);
                Console.WriteLine("Your AccountNo Is:" + accNumber);

                account = new CurrentAccount(name, accNumber);
                Bank.AddAccount(account);
                account.getMessage();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Data");
            }
           

        }
    }
    else if (option == 2)
    {
        Console.Write("Enter your AccountNumber");
        string accountnumber= Console.ReadLine();
        Account a=  Bank.SeachAccontNo(accountnumber);
        if (a != null)
        {
            Console.WriteLine("Enter your Amount");
            double amount=Convert.ToDouble(Console.ReadLine());
            a.Deposit(amount);
        }
        else
        {
            Console.WriteLine("Account not find");
        }
    }
    else if (option == 3)
    {
        Console.Write("Enter your AccountNumber");
        string accountnumber = Console.ReadLine();
        Account a = Bank.SeachAccontNo(accountnumber);
        if (a != null)
        {
            Console.WriteLine("Enter your Amount");
            double amount = Convert.ToDouble(Console.ReadLine());
            a.Withdraw(amount);
        }
        else
        {
            Console.WriteLine("Account not find");
        }
    }else if (option == 4)
    {
        Console.Write("Enter your AccountNumber");
        string accountnumber = Console.ReadLine();
        Account a = Bank.SeachAccontNo(accountnumber);
        if (a != null)
        {
            a.DisplayDetails();
        }
        else
        {
            Console.WriteLine("Account not find");
        }
    }else if (option == 5)
    {
        Bank.ShowAllAccount();
    }else if (option==6)
    {
        try
        {
            Console.Write("Enter your AccountNumber");
            string accountnumber = Console.ReadLine();
            SavingAccount a = (SavingAccount)Bank.SeachAccontNo(accountnumber);
            if (a != null)
            {
                Console.WriteLine("Enter your Period of time for: ");
                double year = Convert.ToDouble(Console.ReadLine());
                a.CalculateInterest(year);
            }
            else
            {
                Console.WriteLine("Account not find");
            }
        }
        catch (Exception ex) 
        {
            Console.WriteLine("Your Account is Current! No Intrest on Current Acccount");
        }
       
    }
    else
    {
        break;
    }
} while (true);


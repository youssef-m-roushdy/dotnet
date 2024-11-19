using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advanced_csharp
{
    public class Program
    {
        public static void Main()
        {
            //Abstract Class
            // SavingAccount savingAccount = new SavingAccount();
            // savingAccount.GetMessage();
            // savingAccount.Balance();
            // savingAccount.Deposite();
            // savingAccount.Withdraw();
            // Console.WriteLine();

            //Interface
            // SavingAcc savingAcc = new SavingAcc();
            // savingAcc.Balance();
            // savingAcc.Deposite();
            // savingAcc.Withdraw();
            // savingAcc.OpenAccount();
            // savingAcc.CloseAccount();
            // Console.WriteLine();

            //Static Class
            // Console.WriteLine(Calculate.Increament());
            // Console.WriteLine(Calculate.Increament());
            // Console.WriteLine(Calculate.Increament());
            // Console.WriteLine(Calculate.Increament());
            // Console.WriteLine(Calculate.Decreament());
            // Console.WriteLine();

            //Extension Methods
            // int a = 5;
            // Console.WriteLine(a.IsGreaterThan(3));
            // Console.WriteLine();

            //Partial Class
            var employee = new Employee();
            employee.DisplayDetails();

            //Properties CSarp
            User user = new User();
            user.Name = "Youssef";
            // Exception Error
            // user.Age = 17;
            user.Age = 20;
            Console.WriteLine(user.Name);
            Console.WriteLine(user.CompanyName);
            Console.WriteLine(user.Age);
        }
    }
}
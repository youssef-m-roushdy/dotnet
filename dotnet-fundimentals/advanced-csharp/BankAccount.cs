using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advanced_csharp
{
    //Abstract Class
    public abstract class BankAccount
    {
        public void GetMessage()
        {
            Console.WriteLine("Welcome to Alpha Bank");
        }
        public abstract void Deposite();
        public abstract void Withdraw();
        public abstract void Balance();
    }

    public class SavingAccount : BankAccount
    {
        public override void Deposite()
        {
            Console.WriteLine("Deposite in Saving Account");
        }
        public override void Withdraw()
        {
            Console.WriteLine("Withdraw in Saving Account");
        }
        public override void Balance()
        {
            Console.WriteLine("Balance in Saving Account");
        }
    }
}
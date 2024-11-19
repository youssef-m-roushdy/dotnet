using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advanced_csharp
{
    public interface IManageBank
    {

        void OpenAccount();
        void CloseAccount();
    }
    public interface IBankAccount
    {

        void Deposite();
        void Withdraw();
        void Balance();
    }

    public class SavingAcc : IBankAccount, IManageBank
    {
        public void Balance()
        {
            Console.WriteLine("Balance in Saving Account");
        }

        public void CloseAccount()
        {
            Console.WriteLine("Closing Saving Account");
        }

        public void Deposite()
        {
            Console.WriteLine("Deposite in Saving Account");
        }

        public void OpenAccount()
        {
            Console.WriteLine("Opening Saving Account");
        }

        public void Withdraw()
        {
            Console.WriteLine("Withdraw in Saving Account");
        }
    }
}
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
            SavingAccount savingAccount = new SavingAccount();
            savingAccount.GetMessage();
            savingAccount.Balance();
            savingAccount.Deposite();
            savingAccount.Withdraw();
        }
    }
}
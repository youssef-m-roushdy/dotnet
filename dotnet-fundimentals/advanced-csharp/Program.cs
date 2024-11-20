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
            // var employee = new Employee();
            // employee.DisplayDetails();
            // Console.WriteLine();

            //Properties CSarp
            // User user = new User();
            // user.Name = "Youssef";
            // // Exception Error
            // // user.Age = 17;
            // user.Age = 20;
            // Console.WriteLine(user.Name);
            // Console.WriteLine(user.CompanyName);
            // Console.WriteLine(user.Age);
            // Console.WriteLine();

            //Indexer
            // StringIndexerType stringIndexerType = new StringIndexerType();
            // stringIndexerType[0] = "String One";
            // stringIndexerType[1] = "String Two";
            // stringIndexerType[2] = "String Three";
            // stringIndexerType[3] = "String Four";

            // for (int i = 0; i < 10; i++)
            //     Console.WriteLine(stringIndexerType[i]);
            // Console.WriteLine();

            //Enum
            // EnumDemo enumDemo = new EnumDemo();
            // enumDemo.Display();
            // Console.WriteLine();

            //Exception Handling
            // Calculation calculation = new Calculation();
            // calculation.Calculate(100, 20);
            // calculation.Calculate(100, 0);
            // calculation.Calculate(20, 4);

            // calculation.CalculateAnother();
            // Console.WriteLine();

            //Anonymous Type
            // var obj = new 
            // {
            //     firstName = "Youssef",
            //     lastName = "Mahmoud",
            //     salary = 12000,
            //     address = new
            //     {
            //         streetName= "Warraq",
            //         city = "Giza"
            //     },
            //     projects = new[]
            //     {
            //         new {name = "E-Commerce", duration = "40 Hours"},
            //         new {name = "Admin Portal", duration = "25 Hours"},
            //         new {name = "Accounting", duration = "30 Hours"},
            //     }
            // };
            // Console.WriteLine($"{obj.firstName} {obj.lastName} {obj.salary}");
            // Console.WriteLine($"{obj.address.streetName} {obj.address.city}");
            // foreach (var item in obj.projects)
            // {
            //     Console.WriteLine($"Project: {item.name}, Duration: {item.duration}");
            // }
            // Console.WriteLine();

            //Delegate

            //Single Delegation
            // CalculateDelegate c1 = new CalculateDelegate(DelegateExample.Addition);
            // CalculateDelegate c2 = new CalculateDelegate(DelegateExample.Multiplication);

            // c1(100);
            // Console.WriteLine(DelegateExample.GetNumber());

            // c2(200);
            // Console.WriteLine(DelegateExample.GetNumber());

            //Multi Delegation
            // CalculateDelegate c1 = new CalculateDelegate(DelegateExample.Addition);
            // c1(100);
            // Console.WriteLine(DelegateExample.GetNumber());

            // c1 += new CalculateDelegate(DelegateExample.Addition);
            // c1 += new CalculateDelegate(DelegateExample.Multiplication);
            // c1(100);
            // Console.WriteLine(DelegateExample.GetNumber());

            //Event
            // The Subscriber Model
            //EventExample events = new EventExample();
            //Delegate_OddNumber pointers null so
            //Make Delegate_OddNumber pointer in method EventMessage
            // events.Event_OddNumber += new EventExample.Delegate_OddNumber(EventMessage);
            // events.Addition();
            // Console.ReadLine();
            // Console.WriteLine();

            //Anonymous Method
            //AnonymousMethodExample.InvokeMethod();
            // Console.WriteLine();
            
            //Lambda Expression

            //Expression Lambda
            var numbers = new int[] {2, 4, 6, 8, 1, 3, 5, 7};
            var count = numbers.Count(x => x == 5);
            Console.WriteLine(count);

            //Statement Lambda
            List<int> numbers2 = new List<int>{2, 4, 6, 8, 1, 5, 3, 5, 7, 5};
            count = numbers2.Count(x => {return x == 5;});
            Console.WriteLine(count);

        }

        // Event Message for Event
        static void EventMessage()
        {
            Console.WriteLine("Event Executed: Odd Number");
        }
    }
}
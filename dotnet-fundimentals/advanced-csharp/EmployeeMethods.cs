using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advanced_csharp
{
    public partial class Employee
    {
        public partial void DisplayDetails()
        {
            Console.WriteLine($"Employee Id: {this.EmpId}");
            Console.WriteLine($"Employee Name: {this.EmpName}");
        }
    }
}
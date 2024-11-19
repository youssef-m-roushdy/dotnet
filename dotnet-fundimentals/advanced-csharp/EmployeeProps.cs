using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advanced_csharp
{
    public partial class Employee
    {
        public int EmpId { get; set; }
        public string? EmpName { get; set; }
        public partial void DisplayDetails();
    }
}
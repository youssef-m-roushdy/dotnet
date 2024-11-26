using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebAPIProject.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? PhoneNumber { get; set; }
        public double Salary { get; set; }
    }
}
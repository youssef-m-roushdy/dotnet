using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebAPIProject.Dtos
{
    public class EmployeeDto
    {
        public string? EmployeeName { get; set; }
        public string? PhoneNumber { get; set; }
        public double Salary { get; set; }
    }
}
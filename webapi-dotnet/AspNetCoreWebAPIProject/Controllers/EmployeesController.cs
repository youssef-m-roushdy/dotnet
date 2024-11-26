using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAPIProject.Dtos;
using AspNetCoreWebAPIProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

namespace AspNetCoreWebAPIProject.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        public static List<Employee> employees = new List<Employee>
        {
            new Employee() {EmployeeId = 1, EmployeeName = "Employee One", Salary = 15000},
            new Employee() {EmployeeId = 2, EmployeeName = "Employee Two", Salary = 17000},
            new Employee() {EmployeeId = 3, EmployeeName = "Employee Three", Salary = 20000},
            new Employee() {EmployeeId = 4, EmployeeName = "Employee Four", Salary = 22500},
            new Employee() {EmployeeId = 5, EmployeeName = "Employee Five", Salary = 40000},
            new Employee() {EmployeeId = 6, EmployeeName = "Employee Six", Salary = 27000},
            new Employee() {EmployeeId = 7, EmployeeName = "Employee Seven", Salary = 30000},
            new Employee() {EmployeeId = 8, EmployeeName = "Employee Eight", Salary = 35000},
            new Employee() {EmployeeId = 9, EmployeeName = "Employee Nine", Salary = 57000},
            new Employee() {EmployeeId = 10, EmployeeName = "Employee Ten", Salary = 60000}
        };
        
        [Route("all")]
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(employees.ToList());
        }

        [Route("id/{id:int}")]
        [HttpGet]
        public IActionResult GetEmployeeById([FromRoute]int id)
        {
            var employee = employees.Find(x => x.EmployeeId == id);
            return Ok(employee);
        }

        [Route("add")]
        [HttpPost]
        public IActionResult AddNewEmployee([FromBody]EmployeeDto employeeDto)
        {
            
            var employeeId = employees.Count + 1;
            var newEmployee = new Employee()
            {EmployeeId = employeeId,
            EmployeeName = employeeDto.EmployeeName,
            PhoneNumber = employeeDto.PhoneNumber,
            Salary = employeeDto.Salary};
            employees.Add(newEmployee);
            var createdUri = Url.Action("GetProductById", new { id = newEmployee.EmployeeId });
            return CreatedAtAction(createdUri, newEmployee);
        }
    }
}
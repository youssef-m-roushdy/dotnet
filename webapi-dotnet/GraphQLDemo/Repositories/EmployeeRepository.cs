using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.Data;
using GraphQLDemo.DTOs;
using GraphQLDemo.Interfaces;
using GraphQLDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Employee> Create(CreateEmployeeDto newEmployee)
        {
            Employee newEmp = new()
            {
                FirstName = newEmployee.FirstName,
                LastName = newEmployee.LastName,
                Email = newEmployee.Email
            };

            await _context.Employees.AddAsync(newEmp);
            await _context.SaveChangesAsync();
            return newEmp;
        }

        public async Task<Employee> Update(int id, UpdateEmployeeDto employee)
        {
            var emp = await GetById(id);
            if (emp is null)
                throw new Exception(nameof(emp));
            
            emp.FirstName = employee.FirstName is null ? emp.FirstName : employee.FirstName;
            emp.LastName = employee.LastName is null ? emp.LastName : employee.LastName;
            emp.Email = employee.Email is null ? emp.Email : employee.Email;

            await _context.SaveChangesAsync();
            return emp;
        }
        

        public async Task Delete(int id)
        {
            var emp = await GetById(id);
            
            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
        }
    }
}
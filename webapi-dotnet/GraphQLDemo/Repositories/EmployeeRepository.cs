using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.Data;
using GraphQLDemo.DTOs;
using GraphQLDemo.Interfaces;
using GraphQLDemo.Models;

namespace GraphQLDemo.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Employee>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Create(CreateEmployeeDto newEmployee)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, UpdateEmployeeDto employee)
        {
            throw new NotImplementedException();
        }
        

        public Task<bool> Delete()
        {
            throw new NotImplementedException();
        }
    }
}
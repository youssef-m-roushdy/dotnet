using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.DTOs;
using GraphQLDemo.Models;

namespace GraphQLDemo.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<bool> Create(CreateEmployeeDto newEmployee);
        Task<bool> Update(int id, UpdateEmployeeDto employee);
        Task<bool> Delete();
    }
}
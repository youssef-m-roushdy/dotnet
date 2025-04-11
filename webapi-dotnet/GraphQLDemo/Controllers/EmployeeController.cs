using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.DTOs;
using GraphQLDemo.Interfaces;
using GraphQLDemo.Models;
using GraphQLDemo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Employee>> GetAll()
        {
            return Ok(await _employeeRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var employee = await _employeeRepository.GetById(id);

            return Ok(employee);
        }

        // POST: api/employee
        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeDto employee)
        {
            await _employeeRepository.Create(employee);
            return Ok();
        }

        // PUT: api/employee/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateEmployeeDto employee)
        {
            await _employeeRepository.Update(id, employee);
            return NoContent();
        }

        // DELETE: api/employee/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeRepository.Delete(id);
            return NoContent();
        }
    }
}
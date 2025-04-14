using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLHotChocolate.Data;
using GraphQLHotChocolate.DTOs.Course;
using GraphQLHotChocolate.DTOs.Student;
using GraphQLHotChocolate.Interfaces;
using GraphQLHotChocolate.Models;
using GraphQLHotChocolate.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace GraphQLHotChocolate.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            return await _context.Students.Select(x => new StudentDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
                PhoneNumber = x.PhoneNumber 
            }).ToListAsync();
        }

        public async Task<StudentWithCoursesDto> GetStudentByIdAsync(int id)
        {
            var student = await _context.Students.Include(x => x.Courses).Select(x => new StudentWithCoursesDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
                PhoneNumber = x.PhoneNumber,
                Courses = x.Courses.Select(c => new CourseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Price = c.Price
                }).ToList()
            }).FirstOrDefaultAsync(x => x.Id == id);
            if(student == null)
                throw new KeyNotFoundException("Can't find this student");
            return student;
        }
    }
}
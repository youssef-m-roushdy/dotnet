using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLHotChocolate.Data;
using GraphQLHotChocolate.DTOs.Course;
using GraphQLHotChocolate.DTOs.Student;
using GraphQLHotChocolate.Interfaces;
using GraphQLHotChocolate.Interfaces.Common;
using GraphQLHotChocolate.Models;
using GraphQLHotChocolate.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace GraphQLHotChocolate.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly AppDbContext _context;
        public CourseRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync()
        {
            return await _context.Courses.Select(x => new CourseDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price
            }).ToListAsync();
        }

        public async Task<CourseWithStudentsDto> GetCourseByIdAsync(int id)
        {
            var course = await _context.Courses.Include(x => x.Students).Select(x => new CourseWithStudentsDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Students = x.Students.Select(s => new StudentDto
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Address = s.Address,
                    PhoneNumber = s.PhoneNumber 
                }).ToList()
            }).FirstOrDefaultAsync(x => x.Id == id);
            if (course == null)
                throw new KeyNotFoundException($"Can't find this course");
            return course;
        }

    }
}
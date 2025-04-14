using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLHotChocolate.Data;
using GraphQLHotChocolate.Interfaces;
using GraphQLHotChocolate.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLHotChocolate.Repositories
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly AppDbContext _context;

        public StudentCourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task RegisterStudentToCourseAsync(int studentId, int courseId)
        {
            var student = await _context.Students
                .Include(s => s.Courses)
                .FirstOrDefaultAsync(s => s.Id == studentId);

            var course = await _context.Courses
                .Include(c => c.Students) // <-- Optional, only needed if you plan to manipulate course.Students
                .FirstOrDefaultAsync(c => c.Id == courseId);

            if (student == null || course == null)
            {
                throw new KeyNotFoundException("Student or Course not found.");
            }

            // Prevent duplicate registration
            if (!student.Courses.Any(c => c.Id == courseId))
            {
                student.Courses.Add(course);
                await _context.SaveChangesAsync();
            }
        }
    }
}
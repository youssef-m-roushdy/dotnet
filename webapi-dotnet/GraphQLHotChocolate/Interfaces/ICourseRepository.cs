using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLHotChocolate.DTOs.Course;
using GraphQLHotChocolate.Interfaces.Common;
using GraphQLHotChocolate.Models;

namespace GraphQLHotChocolate.Interfaces
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<IEnumerable<CourseDto>> GetAllCoursesAsync();
        Task<CourseWithStudentsDto> GetCourseByIdAsync(int id);
    }
}
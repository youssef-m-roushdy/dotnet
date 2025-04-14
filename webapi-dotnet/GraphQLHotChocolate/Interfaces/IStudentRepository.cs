using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLHotChocolate.DTOs.Student;
using GraphQLHotChocolate.Interfaces.Common;
using GraphQLHotChocolate.Models;

namespace GraphQLHotChocolate.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
        Task<StudentWithCoursesDto> GetStudentByIdAsync(int id);
    }
}
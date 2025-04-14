using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLHotChocolate.Data;
using GraphQLHotChocolate.DTOs.Student;
using GraphQLHotChocolate.Interfaces;
using GraphQLHotChocolate.Models;

namespace GraphQLHotChocolate.GraphQL.Queries
{
    public class StudentQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IEnumerable<StudentDto>> GetStudents([Service(ServiceKind.Synchronized)] IStudentRepository _studentRepository)
        {
            return await _studentRepository.GetAllStudentsAsync();
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<StudentWithCoursesDto> GetStudentById([Service(ServiceKind.Synchronized)] IStudentRepository _studentRepository, int id)
        {
            return await _studentRepository.GetStudentByIdAsync(id);
        }
    }
}
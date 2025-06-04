using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLHotChocolate.Data;
using GraphQLHotChocolate.DTOs.Student;
using GraphQLHotChocolate.GraphQL.Types;
using GraphQLHotChocolate.Interfaces;
using GraphQLHotChocolate.Mappers.StudentMapper;
using GraphQLHotChocolate.Models;

namespace GraphQLHotChocolate.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class StudentMutation
    {
        public async Task<Student> CreateStudent([Service(ServiceKind.Synchronized)] IStudentRepository _studentRepository
        , CreateStudentDto studentDto)
        {
            var student = studentDto.FromCreateStudentDtoToStudent();
            await _studentRepository.AddAsync(student);
            return student;
        }

        public async Task<Student> UpdateStudent([Service(ServiceKind.Synchronized)] AppDbContext _context
        , int id, UpdateStudentDto studentDto)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);

            if (studentDto.FirstName != null) student.FirstName = studentDto.FirstName;
            if (studentDto.LastName != null) student.LastName = studentDto.LastName;
            if (studentDto.Address != null) student.Address = studentDto.Address;
            if (studentDto.PhoneNumber != null) student.PhoneNumber = studentDto.PhoneNumber;

            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<DeleteResultType> DeleteStudent([Service(ServiceKind.Synchronized)] AppDbContext _context
        , int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);
            if (student != null)
            {
                _context.Remove(student);
            }
            await _context.SaveChangesAsync();
            var deleteObj = new DeleteResultType
            {
                Success = true,
                DeletedStudent = student!
            };
            return deleteObj;
        }
    }
}
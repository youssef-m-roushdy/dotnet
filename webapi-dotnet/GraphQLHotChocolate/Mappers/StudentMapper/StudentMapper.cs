using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLHotChocolate.DTOs.Course;
using GraphQLHotChocolate.DTOs.Student;
using GraphQLHotChocolate.Models;

namespace GraphQLHotChocolate.Mappers.StudentMapper
{
    public static class StudentMapper
    {
        public static Student FromCreateStudentDtoToStudent(this CreateStudentDto studentDto)
        {
            return new Student
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Address = studentDto.Address,
                PhoneNumber = studentDto.PhoneNumber
            };
        }

        public static Student FromUpdateStudentDtoToStudent(this UpdateStudentDto studentDto, int id)
        {
            return new Student
            {
                Id = id,
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Address = studentDto.Address,
                PhoneNumber = studentDto.PhoneNumber
            };
        }

        public static StudentDto FromStudentToStudentDto(this Student student, int id)
        {
            return new StudentDto
            {
                Id = id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Address = student.Address,
                PhoneNumber = student.PhoneNumber
            };
        }

    }
}
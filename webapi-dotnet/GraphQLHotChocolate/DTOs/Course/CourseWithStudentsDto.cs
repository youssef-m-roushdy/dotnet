using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLHotChocolate.DTOs.Student;

namespace GraphQLHotChocolate.DTOs.Course
{
    public class CourseWithStudentsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<StudentDto> Students { get; set; }
    }
}
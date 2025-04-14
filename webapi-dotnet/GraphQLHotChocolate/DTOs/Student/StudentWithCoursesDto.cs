using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLHotChocolate.DTOs.Course;

namespace GraphQLHotChocolate.DTOs.Student
{
    public class StudentWithCoursesDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<CourseDto> Courses { get; set; }
    }
}
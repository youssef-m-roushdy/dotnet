using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLHotChocolate.DTOs.StudentCourse
{
    public class RegisterStudentToCourseDto
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
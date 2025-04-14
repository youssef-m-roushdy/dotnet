using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLHotChocolate.Models;

namespace GraphQLHotChocolate.Interfaces
{
    public interface IStudentCourseRepository
    {
        
        Task RegisterStudentToCourseAsync(int studentId, int courseId);
    }
}
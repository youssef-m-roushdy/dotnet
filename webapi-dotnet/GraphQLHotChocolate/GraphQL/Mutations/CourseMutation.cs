using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLHotChocolate.Data;
using GraphQLHotChocolate.DTOs.Course;
using GraphQLHotChocolate.GraphQL.Types;
using GraphQLHotChocolate.Interfaces;
using GraphQLHotChocolate.Models;

namespace GraphQLHotChocolate.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class CourseMutation
    {
        public async Task<CreateCourseType> AddCourse([Service(ServiceKind.Synchronized)] AppDbContext _context, CreateCourseDto courseDto)
        {
            var course = new Course
            {
                Name = courseDto.Name,
                Description = courseDto.Description,
                Price = courseDto.Price,
            };
            await _context.AddAsync(course);
            await _context.SaveChangesAsync();
            var returnObj = new CreateCourseType
            {
                Message = "Course created successfully",
            };
            return returnObj;
        }
    }
}
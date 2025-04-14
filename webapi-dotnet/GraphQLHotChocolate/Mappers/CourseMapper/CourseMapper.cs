using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLHotChocolate.DTOs.CourseDto;
using GraphQLHotChocolate.Models;

namespace GraphQLHotChocolate.Mappers.CourseMapper
{
    public static class CourseMapper
    {
        public static Course FromCreateCourseDtoToCourse(this CreateCourseDto courseDto)
        {
            return new Course
            {
                Name = courseDto.Name,
                Description = courseDto.Description,
                Price = courseDto.Price
            };
        }

        public static Course FromUpdateCourseDtoToCourse(this UpdateCourseDto courseDto, int id)
        {
            return new Course
            {
                Id = id,
                Name = courseDto.Name,
                Description = courseDto.Description,
                Price = courseDto.Price
            };
        }
    }
}
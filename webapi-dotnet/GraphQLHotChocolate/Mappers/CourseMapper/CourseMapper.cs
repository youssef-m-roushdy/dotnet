using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLHotChocolate.DTOs.Course;
using GraphQLHotChocolate.DTOs.Course;
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

        public static CourseDto FromCourseToCourseDto(this Course course)
        {
            return new CourseDto
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Price = course.Price
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLHotChocolate.DTOs.Course;
using GraphQLHotChocolate.Interfaces;
using GraphQLHotChocolate.Mappers.CourseMapper;
using GraphQLHotChocolate.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLHotChocolate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetAll()
        {
            var courses = await _courseRepository.GetAllCoursesAsync();
            return Ok(courses);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById([FromRoute] int id)
        {
            try
            {
                var course = await _courseRepository.GetCourseByIdAsync(id);
                return Ok(course);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCourseDto courseDto)
        {
            var course = courseDto.FromCreateCourseDtoToCourse();
            await _courseRepository.AddAsync(course);
            return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCourseDto courseDto)
        {
            try
            {
                await _courseRepository.UpdateAsync(courseDto.FromUpdateCourseDtoToCourse(id));
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _courseRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
// Controllers/StudentCourseController.cs
using System.Threading.Tasks;
using GraphQLHotChocolate.DTOs.StudentCourse;
using GraphQLHotChocolate.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLHotChocolate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentCourseController : ControllerBase
    {
        private readonly IStudentCourseRepository _studentCourseRepository;

        public StudentCourseController(IStudentCourseRepository studentCourseRepository)
        {
            _studentCourseRepository = studentCourseRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterStudentToCourse([FromBody] RegisterStudentToCourseDto dto)
        {
            try
            {
                await _studentCourseRepository.RegisterStudentToCourseAsync(dto.StudentId, dto.CourseId);
                return Ok("Student registered to course successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

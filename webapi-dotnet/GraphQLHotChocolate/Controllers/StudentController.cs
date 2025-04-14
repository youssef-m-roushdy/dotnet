using GraphQLHotChocolate.DTOs.StudentDto;
using GraphQLHotChocolate.Interfaces;
using GraphQLHotChocolate.Mappers.StudentMapper;
using GraphQLHotChocolate.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLHotChocolate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: api/student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            var students = await _studentRepository.GetAllAsync();
            return Ok(students);
        }

        // GET: api/student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById([FromRoute] int id)
        {
            try
            {
                var student = await _studentRepository.GetByIdAsync(id);
                return Ok(student);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/student
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentDto studentDto)
        {
            var student = studentDto.FromCreateStudentDtoToStudent();
            await _studentRepository.AddAsync(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        // PUT: api/student
        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStudentDto student)
        {
            try
            {
                await _studentRepository.UpdateAsync(student.FromUpdateStudentDtoToStudent(id));
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _studentRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

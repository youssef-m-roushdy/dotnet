using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using teacher_service.Interfaces;

namespace teacher_service.Controllers
{
    [Route("api/[controller]")]
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public IActionResult GetAllTeachers()
        {
            var teachers = _teacherRepository.GetAll();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public IActionResult GetAllTeachers([FromRoute]int id)
        {
            var teacher = _teacherRepository.Get(id);
            if(teacher == null)
                return NotFound("This teacher not registred in database");
            return Ok(teacher);
        }
    }
}
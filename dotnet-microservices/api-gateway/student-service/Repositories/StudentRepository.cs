using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using student_service.Data;
using student_service.Interfaces;
using student_service.Models;

namespace student_service.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _studentContext;
        public StudentRepository(StudentDbContext studentContext)
        {
            _studentContext = studentContext;
        }
        public Student Get(int id)
        {
            var student = _studentContext.Students.FirstOrDefault(x => x.Id == id);
            if(student == null)
                return null;
            return student;
        }

        public List<Student> GetAll()
        {
            var student = _studentContext.Students.Where(x => true).ToList();
            return student;
        }
    }
}
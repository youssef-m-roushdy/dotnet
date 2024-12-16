using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teacher_service.Data;
using teacher_service.Interfaces;
using teacher_service.Models;

namespace teacher_service.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly TeacherDbContext _teacherContext;
        public TeacherRepository(TeacherDbContext teacherContext)
        {
            _teacherContext = teacherContext;
        }

        public Teacher Get(int id)
        {
            var teacher = _teacherContext.Teachers.FirstOrDefault(x => x.Id == id);
            if(teacher == null)
                return null;
            return teacher;
        }

        public List<Teacher> GetAll()
        {
            var teachers = _teacherContext.Teachers.Where(x => true).ToList();
            return teachers;
        }
    }
}
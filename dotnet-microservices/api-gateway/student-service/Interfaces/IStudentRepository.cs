using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using student_service.Models;

namespace student_service.Interfaces
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student Get(int id);
    }
}
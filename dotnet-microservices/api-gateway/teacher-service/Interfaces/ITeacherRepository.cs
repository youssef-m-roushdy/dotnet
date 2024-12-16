using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teacher_service.Models;

namespace teacher_service.Interfaces
{
    public interface ITeacherRepository
    {
        List<Teacher> GetAll();
        Teacher Get(int id);   
    }
}
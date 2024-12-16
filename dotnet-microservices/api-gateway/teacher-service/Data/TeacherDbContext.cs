using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using teacher_service.Models;

namespace teacher_service.Data
{
    public class TeacherDbContext : DbContext
    {
        
        public DbSet<Teacher> Teachers { get; set; }
        public TeacherDbContext(DbContextOptions<TeacherDbContext> options):
        base(options)
        {
            
        }
    }
}
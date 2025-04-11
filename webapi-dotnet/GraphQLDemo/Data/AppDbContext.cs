using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees {get; set;}
    }
}
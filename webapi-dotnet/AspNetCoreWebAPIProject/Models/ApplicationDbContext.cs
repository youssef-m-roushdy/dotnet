using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebAPIProject.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products {get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        :base(options)
        {
            
        }
        
    }
}
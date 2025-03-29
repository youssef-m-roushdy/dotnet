using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlatformService.Data;
using PlatformService.Interfaces;
using PlatformService.Models;

namespace PlatformService.Repositories
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly AppDbContext _dbContext;
        public PlatformRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Platform> GetAll()
        {
            var platforms = _dbContext.Platforms.ToList();
            return platforms;
        }

        public Platform GetById(int id)
        {
            var platform = _dbContext.Platforms.FirstOrDefault(x => x.Id == id);
            return platform;
        }

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() >= 0;
        }
        public void Create(Platform platform)
        {
            _dbContext.Add(platform);
        }

        
    }
}
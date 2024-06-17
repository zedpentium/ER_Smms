using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ER_Smms.Data;
using ER_Smms.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ER_Smms.Models.Repositories
{
    public class DbServiceTypeRepo : IServiceTypeRepo
    {
        private readonly AppDbContext _dbContext;

        public DbServiceTypeRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task Create(ServiceType obj)
        {
            _dbContext.Add(obj);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<List<ServiceType>> ReadAll()
        {
            return await _dbContext.ServiceTypes.ToListAsync();
        }


        public async Task<List<ServiceType>> ReadAllForType(string type)
        {
            return await _dbContext.ServiceTypes
                .Where(bs => bs.Type == type)
                .ToListAsync();
        }


        public async Task<ServiceType> Read(int id)
        {
            return await _dbContext.ServiceTypes
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Update(ServiceType obj)
        {
            _dbContext.ServiceTypes.Update(obj);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(ServiceType obj)
        {
            _dbContext.ServiceTypes.Remove(obj);
            await _dbContext.SaveChangesAsync();
        }


    }
}

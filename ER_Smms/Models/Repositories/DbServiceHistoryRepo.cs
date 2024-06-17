using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ER_Smms.Data;
using ER_Smms.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ER_Smms.Models.Repositories
{
    public class DbServiceHistoryRepo : IServiceHistoryRepo
    {
        private readonly AppDbContext _dbContext;

        public DbServiceHistoryRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task Create(ServiceHistory obj)
        {
            _dbContext.Add(obj);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<List<ServiceHistory>> ReadAll()
        {
            return await _dbContext.ServiceHistories.ToListAsync();
        }

        public async Task<ServiceHistory> Read(int id)
        {
            return await _dbContext.ServiceHistories.FindAsync(id);
        }

        public async Task Update(ServiceHistory obj)
        {
            _dbContext.ServiceHistories.Update(obj);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(ServiceHistory obj)
        {
            _dbContext.ServiceHistories.Remove(obj);
            await _dbContext.SaveChangesAsync();
        }


    }
}

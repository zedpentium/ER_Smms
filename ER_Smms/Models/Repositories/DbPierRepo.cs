using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ER_Smms.Data;
using ER_Smms.Models.Interfaces;
using System.Threading.Tasks;

namespace ER_Smms.Models.Repositories
{
    public class DbPierRepo : IPierRepo
    {
        private readonly AppDbContext _dbContext;

        public DbPierRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task Create(Pier obj)
        {
            _dbContext.Add(obj);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<List<Pier>> ReadAll()
        {
            return await _dbContext.Piers
                .Include(d => d.Harbour)
                .ToListAsync();
        }


        public async Task<Pier> Read(int id)
        {
            return await _dbContext.Piers
                .Where(c => c.Id == id)
                .Include(i => i.Harbour)
                .FirstOrDefaultAsync();
        }


        public async Task Update(Pier obj)
        {
            _dbContext.Piers.Update(obj);
            await _dbContext.SaveChangesAsync();
        }


        public async Task Delete(Pier obj)
        {
            _dbContext.Piers.Remove(obj);
            await _dbContext.SaveChangesAsync();
        }

    }
}

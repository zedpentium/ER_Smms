using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ER_Smms.Data;
using ER_Smms.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ER_Smms.Models.Repositories
{
    public class DbHarbourRepo : IHarbourRepo
    {
        private readonly AppDbContext _dbContext;

        public DbHarbourRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task Create(Harbour obj)
        {
            _dbContext.Add(obj);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<List<Harbour>> ReadAll()
        {
            return await _dbContext.Harbours.ToListAsync();
        }

        public async Task<Harbour> Read(int id)
        {
            return await _dbContext.Harbours.FindAsync(id);
        }

        public async Task Update(Harbour obj)
        {
            _dbContext.Harbours.Update(obj);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Harbour obj)
        {
            _dbContext.Harbours.Remove(obj);
            await _dbContext.SaveChangesAsync();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ER_Smms.Data;
using ER_Smms.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ER_Smms.Models.Repositories
{
    public class DbMooringTypeRepo : IMooringTypeRepo
    {
        private readonly AppDbContext _dbContext;

        public DbMooringTypeRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task Create(MooringType obj)
        {
            _dbContext.Add(obj);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<List<MooringType>> ReadAll()
        {
            return await _dbContext.MooringTypes.ToListAsync();
        }

        public async Task<MooringType> Read(int id)
        {
            return await _dbContext.MooringTypes
             .Where(c => c.Id == id)
             .FirstOrDefaultAsync();
        }

        public async Task Update(MooringType obj)
        {
            _dbContext.MooringTypes.Update(obj);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(MooringType obj)
        {
            _dbContext.MooringTypes.Remove(obj);
            await _dbContext.SaveChangesAsync();
        }

    }
}

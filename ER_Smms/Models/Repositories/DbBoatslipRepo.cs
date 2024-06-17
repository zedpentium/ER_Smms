using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using ER_Smms.Data;
using ER_Smms.Models.Interfaces;
using System.Threading.Tasks;

namespace ER_Smms.Models.Repositories
{
    public class DbBoatslipRepo : IBoatslipRepo
    {
        private readonly AppDbContext _dbContext;

        public DbBoatslipRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task Create(Boatslip obj)
        {
            _dbContext.Add(obj);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<List<Boatslip>> ReadAll()
        {
            return await _dbContext.Boatslips
                .Include(bs => bs.Pier).ThenInclude(p => p.Harbour)
                .Include(bs => bs.ServiceType)
                .Include(bs => bs.MooringType)
                //.Include(bs => bs.BoatData).ThenInclude(ti => ti.Customer)
                .ToListAsync();
        }


        public async Task<Boatslip> Read(int id)
        {
            return await _dbContext.Boatslips
                .Where(bs => bs.Id == id)
                .Include(bs => bs.ServiceType)
                .Include(bs => bs.Pier)
                .Include(bs => bs.MooringType)
                //.Include(bs => bs.BoatData).ThenInclude(ti => ti.Customer)
                .FirstOrDefaultAsync();
        }


        //public async Task<List<Boatslip>> FindUserBoatslip(string id)
        //{
        //    return await _dbContext.Boatslips
        //        .Where(bs => bs.BoatData.Customer.Id == id)
        //        .Include(bs => bs.Pier).ThenInclude(p => p.Harbour)
        //        .Include(bs => bs.ServiceType)
        //        //.Include(bs => bs.BoatData).ThenInclude(ti => ti.Customer)
        //        .ToListAsync();
        //}


        public async Task<List<Boatslip>> ReadAllEmpty()
        {
            return await _dbContext.Boatslips
                .Where(bs => bs.BoatDataIdRef == 0)
                .Include(bs => bs.Pier).ThenInclude(p => p.Harbour)
                .Include(bs => bs.ServiceType)
                .Include(bs => bs.MooringType)
                .ToListAsync();
        }


        public async Task<int> Update(Boatslip obj)
        {
            _dbContext.Boatslips.Update(obj);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(Boatslip obj)
        {
            _dbContext.Boatslips.Remove(obj);
            return await _dbContext.SaveChangesAsync();
        }


    }
}

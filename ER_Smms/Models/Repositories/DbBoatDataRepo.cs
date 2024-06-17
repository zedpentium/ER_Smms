using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using ER_Smms.Data;
using ER_Smms.Models.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ER_Smms.Models.Repositories
{
    public class DbBoatDataRepo : IBoatDataRepo
    {
        private readonly AppDbContext _dbContext;

        public DbBoatDataRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;

            //BoatDatas = _dbContext.BoatDatas.Include(x => x.Customer);
                        //.Include(x => x.BoBoatslip).ThenInclude(ti => ti.);

        }


        public async Task<int> Create(BoatData obj)
        {
            _dbContext.Add(obj);
            return await _dbContext.SaveChangesAsync();
        }


        public async Task<List<BoatData>> ReadAll()
        {
            return await _dbContext.BoatDatas
                .Include(x => x.Customer)
                .Include(x => x.Boatslip).ThenInclude(y => y.Pier)
                .Include(x => x.Boatslip).ThenInclude(y => y.ServiceType)
                .Include(x => x.WinterstoreSpot).ThenInclude(y => y.ServiceType)
                .OrderBy(x => x.Customer.UserName)
                .ToListAsync();
        }


        public async Task<List<BoatData>> ReadAllForCurrentUser(string userName)
        {
            return await _dbContext.BoatDatas
                .Where(x => x.Customer.UserName == userName)
                .Include(x => x.Customer)
                .Include(x => x.Boatslip.Pier)
                //.ThenInclude(y => y.Pier)
                .Include(x => x.Boatslip.ServiceType)
                //.ThenInclude(y => y.ServiceType)
                .Include(x => x.WinterstoreSpot).ThenInclude(y => y.ServiceType)
                .ToListAsync();
        }


        public async Task<BoatData> Read(int id)
        {
            return await _dbContext.BoatDatas
                .Where(x => x.Id == id)
                .Include(x => x.Customer)
                .Include(x => x.Boatslip).ThenInclude(y => y.Pier)
                .Include(x => x.Boatslip).ThenInclude(y => y.ServiceType)
                .Include(x => x.WinterstoreSpot).ThenInclude(y => y.ServiceType)
                .SingleOrDefaultAsync();
        }


        public async Task<BoatData> ReadCustomerUserName(string userName)
        {
            return await _dbContext.BoatDatas
                .Where(x => x.Customer.UserName == userName)
                .Include(x => x.Customer)
                .Include(x => x.Boatslip).ThenInclude(y => y.Pier)
                .Include(x => x.Boatslip).ThenInclude(y => y.ServiceType)
                .Include(x => x.WinterstoreSpot).ThenInclude(y => y.ServiceType)
                .SingleOrDefaultAsync();
        }


        public async Task Update(BoatData obj)
        {
            _dbContext.BoatDatas.Update(obj);
            _dbContext.Entry<BoatData>(obj).Property(pr => pr.CreatedDate).IsModified = false;

            await _dbContext.SaveChangesAsync();
        }


        public async Task Delete(BoatData obj)
        {
            _dbContext.BoatDatas.Remove(obj);
            await _dbContext.SaveChangesAsync();
        }

        
        //private IQueryable<BoatData> BoatDatas { get; }


    }
}

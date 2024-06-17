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
    public class DbServiceApplicationRepo : IServiceApplicationRepo
    {
        private readonly AppDbContext _dbContext;

        public DbServiceApplicationRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<int> Create(ServiceApplication obj)
        {
            _dbContext.Add(obj);
            return await _dbContext.SaveChangesAsync();
        }


        public async Task<List<ServiceApplication>> ReadAll() // ReadAll that InQueue = 0 (not in queue)
        {
            return await _dbContext.ServiceApplications
                .Where(d => d.InQueue == 0)
                .Include(d => d.BoatData)
                .Include(d => d.Customer)
                .Include(d => d.ServiceType)
                .Include(d => d.Applicant)
                .ToListAsync();
        }


        public async Task<List<ServiceApplication>> ReadAllQueued() // ReadAll that InQueue = 1 (that ARE in queue)
        {
            return await _dbContext.ServiceApplications
                .Where(d => d.InQueue == 1)
                .Include(d => d.BoatData)
                .Include(d => d.Customer)
                .Include(d => d.ServiceType)
                .Include(d => d.Applicant)
                .ToListAsync();
        }


        public async Task<ServiceApplication> Read(int id)
        {
            return await _dbContext.ServiceApplications
                .Where(i => i.Id == id)
                .Include(i => i.BoatData)
                .Include(i => i.Customer)
                .Include(i => i.ServiceType)
                .Include(d => d.Applicant)
                .FirstOrDefaultAsync();
        }


        public async Task<ServiceApplication> ReadApplicantEmail(string email)
        {
            return await _dbContext.ServiceApplications
                .Where(i => i.Applicant.Email == email)
                .Include(i => i.BoatData)
                .Include(i => i.Customer)
                .Include(i => i.ServiceType)
                .Include(d => d.Applicant)
                .FirstOrDefaultAsync();
        }


        public async Task<List<ServiceApplication>> ReadAllForCurrentUser(string userId)
        {
            return await _dbContext.ServiceApplications
                .Where(d => d.Customer.UserName == userId)
                .Include(d => d.BoatData)
                .Include(i => i.Customer)
                .Include(d => d.ServiceType)
                .ToListAsync();
        }
        

        public async Task<int> Update(ServiceApplication obj)
        {
            _dbContext.ServiceApplications.Update(obj);
            return await _dbContext.SaveChangesAsync();
        }


        public async Task<int> Delete(ServiceApplication obj)
        {
            _dbContext.ServiceApplications.Remove(obj);
            return await _dbContext.SaveChangesAsync();
        }

    }
}

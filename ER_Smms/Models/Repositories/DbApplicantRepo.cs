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
    public class DbApplicantRepo : IApplicantRepo
    {
        private readonly AppDbContext _dbContext;

        public DbApplicantRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task Create(Applicant obj)
        {
            _dbContext.Add(obj);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<List<Applicant>> ReadAll()
        {
            return await _dbContext.Applicants
                .ToListAsync();
        }


        //public async Task<List<Applicant>> ReadAllForCurrentUser(string userId)
        //{
        //    return await _dbContext.Applicants
        //        .Where(x => x.Customer.Id == userId)
        //        .Include(x => x.Customer)
        //        .ToListAsync();
        //}


        public async Task<Applicant> Read(int id)
        {
            return await _dbContext.Applicants
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }


        public async Task<Applicant> Read(DateTime dateTime)
        {
            return await _dbContext.Applicants
                .Where(x => x.CreatedDate == dateTime)
                .SingleOrDefaultAsync();
        }


        public async Task Update(Applicant obj)
        {
            _dbContext.Applicants.Update(obj);
            _dbContext.Entry<Applicant>(obj).Property(pr => pr.CreatedDate).IsModified = false;

            await _dbContext.SaveChangesAsync();
        }


        public async Task Delete(Applicant obj)
        {
            _dbContext.Applicants.Remove(obj);
            await _dbContext.SaveChangesAsync();
        }

       
    }
}

using ER_Smms.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepo _repo;

        public ApplicantService(IApplicantRepo repo)
        {
            _repo = repo;
        }


        public async Task Create(Applicant obj)
        {
            await _repo.Create(obj);
        }


        public async Task<List<Applicant>> ReadAll()
        {
            return await _repo.ReadAll();
        }


        public async Task<Applicant> FindBy(int id)
        {
            return await _repo.Read(id);
        }


        public async Task<Applicant> FindByDateTime(DateTime dateTime)
        {
            return await _repo.Read(dateTime);
        }

        
        //public async Task<List<Applicant>> ReadAllForCurrentUser(string userId)
        //{
        //    return await _repo.ReadAllForCurrentUser(userId);
        //}



        public async Task Update(Applicant obj)
        {
            await _repo.Update(obj);
        }


        public async Task Remove(int id)
        {
             await _repo.Delete(await _repo.Read(id));
        }


    }


}

using ER_Smms.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Services
{
    public class ServiceApplicationService : IServiceApplicationService
    {
        private readonly IServiceApplicationRepo _repo;

        public ServiceApplicationService(IServiceApplicationRepo repo)
        {
            _repo = repo;
        }


        public async Task<int> Create(ServiceApplication obj)
        {
            return await _repo.Create(obj);
        }


        public async Task<List<ServiceApplication>> ReadAll()
        {
            return await _repo.ReadAll();
        }


        public async Task<List<ServiceApplication>> ReadAllQueued()
        {
            return await _repo.ReadAllQueued();
        }


        public async Task<ServiceApplication> FindBy(int id)
        {
            return await _repo.Read(id); ;
        }


        public async Task<ServiceApplication> FindByApplicantEmail(string email)
        {
            return await _repo.ReadApplicantEmail(email); ;
        }


        public async Task<List<ServiceApplication>> ReadAllForCurrentUser(string userId)
        {
            return await _repo.ReadAllForCurrentUser(userId);
        }


        public async Task<int> Update(ServiceApplication obj)
        {
            return await _repo.Update(obj);
        }


        public async Task<int> Remove(int id)
        {
            return await _repo.Delete(await _repo.Read(id));
        }

    }

}

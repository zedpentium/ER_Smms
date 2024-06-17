using ER_Smms.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Services
{
    public class ServiceHistoryService : IServiceHistoryService
    {
        private readonly IServiceHistoryRepo _repo;

        public ServiceHistoryService(IServiceHistoryRepo repo)
        {
            _repo = repo;
        }

        public async Task Create(ServiceHistory obj)
        {
            await _repo.Create(obj);
        }


        public async Task<List<ServiceHistory>> ReadAll()
        {
            return await _repo.ReadAll();
        }


        public async Task Update(ServiceHistory obj)
        {
            await _repo.Update(obj);
        }


        public async Task<ServiceHistory> FindBy(int id)
        {
            return await _repo.Read(id);
        }

        public async Task Remove(int id)
        {
            await _repo.Delete(await _repo.Read(id));
        }

    }


}

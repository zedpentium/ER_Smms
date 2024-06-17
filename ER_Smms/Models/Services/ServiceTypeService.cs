using ER_Smms.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Services
{
    public class ServiceTypeService : IServiceTypeService
    {
        private readonly IServiceTypeRepo _repo;

        public ServiceTypeService(IServiceTypeRepo repo)
        {
            _repo = repo;
        }


        public async Task Create(ServiceType obj)
        {
            await _repo.Create(obj);
        }


        public async Task<List<ServiceType>> ReadAll()
        {
            return await _repo.ReadAll();
        }


        public async Task<List<ServiceType>> ReadAllForType(string type)
        {
            return await _repo.ReadAllForType(type);
        }


        public async Task Update(ServiceType obj)
        {
            await _repo.Update(obj);
        }


        public async Task<ServiceType> FindBy(int id)
        {
            return await _repo.Read(id);
        }


        public async Task Remove(int id)
        {
            await _repo.Delete(await _repo.Read(id));
        }


    }

}

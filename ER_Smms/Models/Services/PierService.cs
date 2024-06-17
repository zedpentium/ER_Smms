using ER_Smms.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Services
{
    public class PierService : IPierService
    {
        private readonly IPierRepo _repo;

        public PierService(IPierRepo repo)
        {
            _repo = repo;
        }


        public async Task Create(Pier obj)
        {
            await _repo.Create(obj);

        }


        public async Task<List<Pier>> ReadAll()
        {
            return await _repo.ReadAll();
        }


        public async Task<Pier> FindBy(int id)
        {
            return await _repo.Read(id);
        }


        public async Task Update(Pier obj)
        {
            await _repo.Update(obj);
        }


        public async Task Remove(int id)
        {
            await _repo.Delete(await _repo.Read(id));
        }


    }

}

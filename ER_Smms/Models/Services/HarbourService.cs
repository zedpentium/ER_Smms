using ER_Smms.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Services
{
    public class HarbourService : IHarbourService
    {
        private readonly IHarbourRepo _repo;

        public HarbourService(IHarbourRepo repo)
        {
            _repo = repo;
        }

        public async Task Create(Harbour obj)
        {
            await _repo.Create(obj);
        }


        public async Task<List<Harbour>> ReadAll()
        {
            return await _repo.ReadAll();
        }


        public async Task Update(Harbour obj)
        {
            await _repo.Update(obj);
        }


        public async Task<Harbour> FindBy(int id)
        {
            return await _repo.Read(id);
        }

        public async Task Remove(int id)
        {
            await _repo.Delete(await _repo.Read(id));
        }

    }


}

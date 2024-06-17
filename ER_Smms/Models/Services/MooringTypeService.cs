using ER_Smms.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Services
{
    public class MooringTypeService : IMooringTypeService
    {
        private readonly IMooringTypeRepo _repo;

        public MooringTypeService(IMooringTypeRepo repo)
        {
            _repo = repo;
        }


        public async Task Create(MooringType obj)
        {
            await _repo.Create(obj);
        }


        public async Task<List<MooringType>> ReadAll()
        {
            return await _repo.ReadAll();
        }

        public async Task Update(MooringType obj)
        {
            await _repo.Update(obj);
        }


        public async Task<MooringType> FindBy(int id)
        {
            return await _repo.Read(id);
        }


        public async Task Remove(int id)
        {
            await _repo.Delete(await _repo.Read(id));
        }

    }


}

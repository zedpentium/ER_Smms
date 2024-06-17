using ER_Smms.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Services
{
    public class BoatslipService : IBoatslipService
    {
        private readonly IBoatslipRepo _repo;

        public BoatslipService(IBoatslipRepo repo)
        {
            _repo = repo;
        }


        public async Task Create(Boatslip obj)
        {
            await _repo.Create(obj);
        }


        public async Task<List<Boatslip>> ReadAll()
        {
            return await _repo.ReadAll();
        }


        public async Task<Boatslip> FindBy(int id)
        {
            return await _repo.Read(id);
        }


        //public async Task<List<Boatslip>> FindUserBoatslip(string id)
        //{
        //    return await _repo.FindUserBoatslip(id);
        //}


        public async Task<List<Boatslip>> ReadAllEmpty()
        {
            return await _repo.ReadAllEmpty();
        }
        

        public async Task<int> Update(Boatslip obj)
        {
            return await _repo.Update(obj);
        }


        public async Task<int> Remove(int id)
        {
            return await _repo.Delete(await _repo.Read(id));
        }

    }


}

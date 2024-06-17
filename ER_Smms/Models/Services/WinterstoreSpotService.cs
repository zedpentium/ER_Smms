using ER_Smms.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Services
{
    public class WinterstoreSpotService : IWinterstoreSpotService
    {
        private readonly IWinterstoreSpotRepo _repo;

        public WinterstoreSpotService(IWinterstoreSpotRepo repo)
        {
            _repo = repo;
        }


        public async Task Create(WinterstoreSpot obj)
        {
            await _repo.Create(obj);
        }


        public async Task<List<WinterstoreSpot>> ReadAll()
        {
            return await _repo.ReadAll();
        }


        public async Task Update(WinterstoreSpot obj)
        {
            await _repo.Update(obj);
        }


        public async Task<WinterstoreSpot> FindBy(int id)
        {
            return await _repo.Read(id);
        }


        //public async Task<List<WinterstoreSpot>> FindUserWinterstoreSpot(string id)
        //{
        //    return await _repo.FindUserWinterstoreSpot(id);
        //}


        public async Task<List<WinterstoreSpot>> ReadAllEmptyWinterstoreSpotByType(string type)
        {
            return await _repo.ReadAllEmptyWinterstoreSpotByType(type);
        }


        public async Task Remove(int id)
        {
            await _repo.Delete(await _repo.Read(id));
        }


    }

}

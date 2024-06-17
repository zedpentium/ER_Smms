using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IWinterstoreSpotRepo
    {
        Task Create(WinterstoreSpot obj);

        Task<List<WinterstoreSpot>> ReadAll();

        Task<WinterstoreSpot> Read(int id);

        //Task<List<WinterstoreSpot>> FindUserWinterstoreSpot(string id);

        Task<List<WinterstoreSpot>> ReadAllEmptyWinterstoreSpotByType(string type);

        Task Update(WinterstoreSpot obj);

        Task Delete(WinterstoreSpot obj);
    }
}

using ER_Smms.Models.ViewModels.Admin;
using ER_Smms.Models.ViewModels.Frontend;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IWinterstoreSpotService
    {
        Task Create(WinterstoreSpot obj);

        Task<List<WinterstoreSpot>> ReadAll();

        Task<WinterstoreSpot> FindBy(int id);

        //Task<List<WinterstoreSpot>> FindUserWinterstoreSpot(string id);

        Task<List<WinterstoreSpot>> ReadAllEmptyWinterstoreSpotByType(string type);

        Task Update(WinterstoreSpot obj);

        Task Remove(int id);

    }
}

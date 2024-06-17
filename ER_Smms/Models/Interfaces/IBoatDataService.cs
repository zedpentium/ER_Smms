using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IBoatDataService
    {
        Task<int> Create(BoatData obj);

        Task<List<BoatData>> ReadAll();

        Task<List<BoatData>> ReadAllForCurrentUser(string userName);

        Task<BoatData> FindBy(int id);

        Task<BoatData> FindByCustomerUserName(string userName);

        Task Update(BoatData obj);

        Task Remove(int id);
    }
}

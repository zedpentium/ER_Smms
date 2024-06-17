using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IBoatDataRepo
    {
        Task<int> Create(BoatData obj);

        Task<List<BoatData>> ReadAll();

        Task<List<BoatData>> ReadAllForCurrentUser(string userName);

        Task<BoatData> Read(int id);

        Task<BoatData> ReadCustomerUserName(string userName);

        Task Update(BoatData obj);

        Task Delete(BoatData obj);
    }
}

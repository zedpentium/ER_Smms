using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IServiceHistoryService
    {
        Task Create(ServiceHistory obj);

        Task<List<ServiceHistory>> ReadAll();

        Task<ServiceHistory> FindBy(int id);

        Task Update(ServiceHistory obj);

        Task Remove(int id);
    }
}

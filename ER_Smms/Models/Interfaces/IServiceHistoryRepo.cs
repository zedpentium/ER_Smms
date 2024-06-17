using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IServiceHistoryRepo
    {
        Task Create(ServiceHistory obj);

        Task<List<ServiceHistory>> ReadAll();

        Task<ServiceHistory> Read(int id);

        Task Update(ServiceHistory obj);

        Task Delete(ServiceHistory obj);
    }
}

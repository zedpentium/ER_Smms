using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IServiceTypeRepo
    {
        Task Create(ServiceType obj);

        Task<List<ServiceType>> ReadAll();

        Task<List<ServiceType>> ReadAllForType(string type);

        Task<ServiceType> Read(int id);

        Task Update(ServiceType obj);

        Task Delete(ServiceType obj);
    }
}

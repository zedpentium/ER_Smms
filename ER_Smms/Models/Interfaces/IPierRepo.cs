using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IPierRepo
    {
        Task Create(Pier obj);

        Task<List<Pier>> ReadAll();

        Task<Pier> Read(int id);

        Task Update(Pier obj);

        Task Delete(Pier obj);
    }
}

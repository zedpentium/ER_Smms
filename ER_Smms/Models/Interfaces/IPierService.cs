using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IPierService
    {
        Task Create(Pier obj);

        Task<List<Pier>> ReadAll();

        Task<Pier> FindBy(int id);

        Task Update(Pier obj);

        Task Remove(int id);
    }
}

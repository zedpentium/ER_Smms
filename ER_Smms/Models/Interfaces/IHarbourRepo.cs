using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IHarbourRepo
    {
        Task Create(Harbour obj);

        Task<List<Harbour>> ReadAll();

        Task<Harbour> Read(int id);

        Task Update(Harbour obj);

        Task Delete(Harbour obj);
    }
}

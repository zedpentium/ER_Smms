using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IHarbourService
    {
        Task Create(Harbour obj);

        Task<List<Harbour>> ReadAll();

        Task<Harbour> FindBy(int id);

        Task Update(Harbour obj);

        Task Remove(int id);
    }
}

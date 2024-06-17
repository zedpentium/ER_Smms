using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IMooringTypeService
    {
        Task Create(MooringType obj);

        Task<List<MooringType>> ReadAll();

        Task<MooringType> FindBy(int id);

        Task Update(MooringType obj);

        Task Remove(int id);
    }
}

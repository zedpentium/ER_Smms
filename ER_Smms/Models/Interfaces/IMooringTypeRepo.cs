using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IMooringTypeRepo
    {
        Task Create(MooringType obj);

        Task<List<MooringType>> ReadAll();

        Task<MooringType> Read(int id);

        Task Update(MooringType obj);

        Task Delete(MooringType obj);
    }
}

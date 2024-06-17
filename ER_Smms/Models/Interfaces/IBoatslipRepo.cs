using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IBoatslipRepo
    {
        Task Create(Boatslip obj);

        Task<List<Boatslip>> ReadAll();

        Task<Boatslip> Read(int id);

        //Task<List<Boatslip>> FindUserBoatslip(string id);

        Task<List<Boatslip>> ReadAllEmpty();

        Task<int> Update(Boatslip obj);

        Task<int> Delete(Boatslip obj);
    }
}

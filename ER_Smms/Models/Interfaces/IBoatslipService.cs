using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IBoatslipService
    {
        Task Create(Boatslip obj);

        Task<List<Boatslip>> ReadAll();

        Task<Boatslip> FindBy(int id);

        //Task<List<Boatslip>> FindUserBoatslip(string id);

        Task<List<Boatslip>> ReadAllEmpty();

        Task<int> Update(Boatslip obj);

        Task<int> Remove(int id);

    }
}

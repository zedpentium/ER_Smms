using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IServiceApplicationRepo
    {
        Task<int> Create(ServiceApplication obj);

        Task<List<ServiceApplication>> ReadAll();

        Task<List<ServiceApplication>> ReadAllQueued();

        Task<ServiceApplication> Read(int id);

        Task<List<ServiceApplication>> ReadAllForCurrentUser(string userID);

        Task<ServiceApplication> ReadApplicantEmail(string email);

        Task<int> Update(ServiceApplication obj);

        Task<int> Delete(ServiceApplication obj);
    }
}

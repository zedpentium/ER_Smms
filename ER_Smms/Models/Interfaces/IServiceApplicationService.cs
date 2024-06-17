using ER_Smms.Models.ViewModels.Admin;
using ER_Smms.Models.ViewModels.Frontend;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IServiceApplicationService
    {
        Task<int> Create(ServiceApplication obj);

        Task<List<ServiceApplication>> ReadAll();

        Task<List<ServiceApplication>> ReadAllQueued();

        Task<ServiceApplication> FindBy(int id);

        Task<List<ServiceApplication>> ReadAllForCurrentUser(string userId);

        Task<ServiceApplication> FindByApplicantEmail(string email);

        Task<int> Update(ServiceApplication obj);

        Task<int> Remove(int id);
    }
}

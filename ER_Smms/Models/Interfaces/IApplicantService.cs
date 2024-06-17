using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IApplicantService
    {
        Task Create(Applicant obj);

        Task<List<Applicant>> ReadAll();

        //Task<List<Applicant>> ReadAllForCurrentUser(string userId);

        Task<Applicant> FindBy(int id);

        Task<Applicant> FindByDateTime(DateTime dateTime);

        Task Update(Applicant obj);

        Task Remove(int id);
    }
}

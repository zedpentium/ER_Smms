using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IApplicantRepo
    {
        Task Create(Applicant obj);

        Task<List<Applicant>> ReadAll();

        //Task<List<Applicant>> ReadAllForCurrentUser(string userId);

        Task<Applicant> Read(int id);

        Task<Applicant> Read(DateTime dateTime);

        Task Update(Applicant obj);

        Task Delete(Applicant obj);
    }
}

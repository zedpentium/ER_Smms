using ER_Smms.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER_Smms.Models.Services
{
    public class BoatDataService : IBoatDataService
    {
        private readonly IBoatDataRepo _repo;

        public BoatDataService(IBoatDataRepo repo)
        {
            _repo = repo;
        }


        public async Task<int> Create(BoatData obj)
        {
            return await _repo.Create(obj);
        }


        public async Task<List<BoatData>> ReadAll()
        {
            return await _repo.ReadAll();
        }


        public async Task<List<BoatData>> ReadAllForCurrentUser(string userName)
        {
            return await _repo.ReadAllForCurrentUser(userName);
        }
        

        public async Task<BoatData> FindBy(int id)
        {
            return await _repo.Read(id);
        }


        public async Task<BoatData> FindByCustomerUserName(string userName)
        {
            return await _repo.ReadCustomerUserName(userName);
        }


        public async Task Update(BoatData obj)
        {
            await _repo.Update(obj);
        }
        
        
        public async Task Remove(int id)
        {
             await _repo.Delete(await _repo.Read(id));
        }


        // Pagination
        //public DataResultViewModel<BoatDataViewModel> GetWithPagination(Pagination pagination,
        //Expression<Func<BoatData, DateTime>> fieldName)
        //{
        //    var result = new DataResultViewModel<BoatDataViewModel>();

        //    using (var db = new MiscellaneousEntities())
        //    {
        //        var persons = db.Person.AsQueryable();

        //        result.Pagination = pagination;
        //        result.Pagination.TotalItems = persons.Count();
        //        result.Pagination.RouteInfo = new RouteInfo()
        //        {
        //            ActionName = "Index",
        //            ControllerName = "Person"
        //        };

        //        if (pagination.SortBy == null)
        //            pagination.SortBy = "CreateDate";
        //        persons = persons.UseOrdering(pagination, fieldName);
        //        persons = persons.UsePagination(pagination);

        //        result.Items = persons
        //            .Select(s => new BoatDataViewModel()
        //            {
        //                ID = s.ID,
        //                FirstName = s.FirstName,
        //                LastName = s.LastName
        //            })
        //            .ToList();

        //        return result;
        //    }
        //}



    }


}

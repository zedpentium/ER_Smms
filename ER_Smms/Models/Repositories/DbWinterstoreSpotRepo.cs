using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using ER_Smms.Data;
using ER_Smms.Models.Interfaces;
using System.Threading.Tasks;

namespace ER_Smms.Models.Repositories
{
    public class DbWinterstoreSpotRepo : IWinterstoreSpotRepo
    {
        private readonly AppDbContext _winterstoreSpotDbContext;

        public DbWinterstoreSpotRepo(AppDbContext winterstoreSpotDbContext)
        {
            _winterstoreSpotDbContext = winterstoreSpotDbContext;
        }


        public async Task Create(WinterstoreSpot obj)
        {
            _winterstoreSpotDbContext.Add(obj);
            await SaveChangesHandleIfError(_winterstoreSpotDbContext);
        }


        public async Task<List<WinterstoreSpot>> ReadAll()
        {
            return await _winterstoreSpotDbContext.WinterstoreSpots
                //.Include(d => d.BoatDataIdRef)
                .Include(d => d.ServiceType)
                .ToListAsync();
        }


        public async Task<WinterstoreSpot> Read(int id)
        {
            return await _winterstoreSpotDbContext.WinterstoreSpots
                .Where(i => i.Id == id)
                //.Include(i => i.BoatDataIdRef)
                .Include(i => i.ServiceType)
                .FirstOrDefaultAsync();
        }


        //public async Task<List<WinterstoreSpot>> FindUserWinterstoreSpot(string id)
        //{
        //    return await _winterstoreSpotDbContext.WinterstoreSpots
        //        .Where(c => c.BoatData.Customer.Id == id)
        //        .Include(c => c.BoatData).ThenInclude(bd => bd.Customer)
        //        .Include(c => c.ServiceType)
        //        .ToListAsync();
        //}


        public async Task<List<WinterstoreSpot>> ReadAllEmptyWinterstoreSpotByType(string type)
        {
            return await _winterstoreSpotDbContext.WinterstoreSpots
                .Where(c => c.BoatDataIdRef == 0)
                .Where(c => c.ServiceType.Type == type)
                .Include(c => c.ServiceType)
                .ToListAsync();
        }


        public async Task Update(WinterstoreSpot obj)
        {
            _winterstoreSpotDbContext.WinterstoreSpots.Update(obj);
            await SaveChangesHandleIfError(_winterstoreSpotDbContext);
        }


        public async Task Delete(WinterstoreSpot obj)
        {
             _winterstoreSpotDbContext.WinterstoreSpots.Remove(obj);
            await SaveChangesHandleIfError(_winterstoreSpotDbContext);

        }


        private async Task SaveChangesHandleIfError(AppDbContext theContext)
        {
            await theContext.SaveChangesAsync();
        }

        
    }
}

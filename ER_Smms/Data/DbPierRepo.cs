using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using ER_Smms.Models;
using ER_Smms.Models.ViewModels;
using ER_Smms.Models.Interfaces;

namespace ER_Smms.Data
{
    public class DbPierRepo : IPierRepo
    {
        private readonly AppDbContext _pierDbContext;

        public DbPierRepo(AppDbContext pierDbContext)
        {
            _pierDbContext = pierDbContext;

        }

        public DbPierRepo()
        {
        }


        public string Create(Pier obj, Harbour selectedObj)
        {
            obj.Harbour = selectedObj;

            _pierDbContext.Add(obj);
            string handleMessage = SaveChangesHandleIfError(_pierDbContext);

            return handleMessage;
        }


        public List<Pier> ReadAll()
        {
            List<Pier> pierList;

            try
            {
                pierList = _pierDbContext.Piers
                .Include(d => d.Harbour)
                //.Include(e => e.City.Country)
                //.Include(f => f.PersonLanguages).ThenInclude(g => g.Language)
                .ToList();

                return pierList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);

                pierList = null;
                return pierList;
            }

        }

        public Pier Read(int id)
        {
            Pier obj;

            obj = _pierDbContext.Piers
             .Include(i => i.Harbour)
             .Where(x => x.Id == id)
             .First();

            return obj; //_pierListContext.Piers.Find(id);
        }

        public string Update(Pier pier)
        {
            //Pier objFromDB = _pierDbContext.Piers.Find(pier.Id);

            _pierDbContext.Piers.Update(pier);
            string handleMessage = SaveChangesHandleIfError(_pierDbContext);

            return handleMessage;
        }

        public bool Delete(Pier pier)
        {
            int nrStates;

            _pierDbContext.Piers.Remove(pier);
            nrStates = _pierDbContext.SaveChanges();

            if (nrStates == 1)
            {
                return true;
            }

            return false;
        }



       private string SaveChangesHandleIfError(AppDbContext theContext)
        {
            try
            {
                theContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                //This either returns a error string, or null if it can’t handle that error
                //var error = (e);
                if (e != null)
                {
                    var errorInString = e.Message.ToString();
                    //Debug.WriteLine(errorInString);
                    return errorInString; //return the error string
                }
                throw; //couldn’t handle that error, so rethrow
            }

            return "success";

        }

    }
}

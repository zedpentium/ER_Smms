using ER_Smms.Models;
using ER_Smms.Models.ViewModels;
using ER_Smms.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ER_Smms.Data
{
    public class DbHarbourRepo : IHarbourRepo
    {
        private readonly AppDbContext _harbourListContext;

        public DbHarbourRepo(AppDbContext harbourListContext)
        {
            _harbourListContext = harbourListContext;

        }

        public DbHarbourRepo()
        {
        }


        public string Create(Harbour obj)
        {
            _harbourListContext.Add(obj);
            string handleMessage = SaveChangesHandleIfError(_harbourListContext);

            return handleMessage;

        }


        public List<Harbour> ReadAll()
        {
            List<Harbour> harboursList;

            try
            {
                harboursList = _harbourListContext.Harbours
                //.Include(d => d.Piers)
                //.Include(e => e.City.Country)
                //.Include(f => f.PersonLanguages).ThenInclude(g => g.Language)
                .ToList();

                return harboursList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);

                harboursList = null;
                return harboursList;
            }


            
        }

        public Harbour Read(int id)
        {
            return _harbourListContext.Harbours.Find(id);
        }

        public string Update(Harbour harbour)
        {
            _harbourListContext.Harbours.Update(harbour);
            string handleMessage = SaveChangesHandleIfError(_harbourListContext);

            return handleMessage;
        }

        public bool Delete(Harbour harbour)
        {
            int nrStates;

            _harbourListContext.Harbours.Remove(harbour);
            nrStates = _harbourListContext.SaveChanges();

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

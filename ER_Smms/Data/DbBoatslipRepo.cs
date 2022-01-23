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
    public class DbBoatslipRepo : IBoatslipRepo
    {
        private readonly AppDbContext _boatslipListContext;

        public DbBoatslipRepo(AppDbContext boatslipListContext)
        {
            _boatslipListContext = boatslipListContext;

        }

        public DbBoatslipRepo()
        {
        }


        public string Create(Boatslip obj, Pier selectedObj)
        {
            obj.Pier = selectedObj;

            _boatslipListContext.Add(obj);
            string handleMessage = SaveChangesHandleIfError(_boatslipListContext);

            return handleMessage;
        }


        public List<Boatslip> ReadAll()
        {
            List<Boatslip> boatslipList;

            try
            {
                boatslipList = _boatslipListContext.Boatslips
                .Include(d => d.Pier)
                //.Include(e => e.City.Country)
                //.Include(f => f.PersonLanguages).ThenInclude(g => g.Language)
                .ToList();

                return boatslipList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex); // InnerException.Message);

                boatslipList = null;
                return boatslipList;
            }

        }

        public Boatslip Read(int id)
        {
            return _boatslipListContext.Boatslips.Find(id);
        }

        public string Update(Boatslip obj)
        {

            _boatslipListContext.Boatslips.Update(obj);
            string handleMessage = SaveChangesHandleIfError(_boatslipListContext);

            return handleMessage;
        }

        public bool Delete(Boatslip obj)
        {
            int nrStates;

            _boatslipListContext.Boatslips.Remove(obj);
            nrStates = _boatslipListContext.SaveChanges();

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

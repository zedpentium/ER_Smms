using ER_Smms.Models;
using ER_Smms.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ER_Smms.Data
{
    public class DbCountryRepo : ICountryRepo
    {
        private readonly AppDbContext _countryListContext;

        public DbCountryRepo(AppDbContext countryListContext)
        {
            _countryListContext = countryListContext;

        }

        public DbCountryRepo()
        {
        }


        public Country Create(string countryName)
        {
            Country newCountry = new Country(countryName);

            _countryListContext.Add(newCountry);
            _countryListContext.SaveChanges();

            return newCountry;
        }


        public List<Country> Read()
        {
            List<Country> cList = _countryListContext.Countries.ToList();

            return cList;
        }

        public Country Read(int id)
        {
            return _countryListContext.Countries.Find(id);
        }

        public Country Update(Country country)
        {
            _countryListContext.Countries.Update(country);
            _countryListContext.SaveChanges();

            return country;
        }

        public bool Delete(Country country)
        {
            int nrStates;

            _countryListContext.Countries.Remove(country);
            nrStates = _countryListContext.SaveChanges();

            if (nrStates == 1)
            {
                return true;
            }

            return false;
        }

    }
}

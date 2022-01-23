using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ER_Smms.Models.Interfaces;
using ER_Smms.Models.ViewModels;
using ER_Smms.Models;

namespace ER_Smms.Models.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepo _countryRepo;

        public CountryService(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }


        public Country Add(CreateCountryViewModel country)
        {
            Country madeCountry = _countryRepo.Create(country.CountryName);

            return madeCountry;
        }

        public CountryViewModel All()
        {
            CountryViewModel coViewMod = new CountryViewModel() { CountryListView = _countryRepo.Read() };

            return coViewMod;
        }

        public Country Edit(int id, Country country)
        {
            throw new NotImplementedException();
        }

        public CountryViewModel FindBy(CountryViewModel search)
        {
            search.CountryListView.Clear();

            List<Country> countryList = _countryRepo.Read();

            foreach (Country item in countryList)
            {
                if (item.CountryName.Contains(search.FilterString, StringComparison.OrdinalIgnoreCase))
                {
                    search.CountryListView.Add(item);
                }
            }

            if (search.CountryListView.Count == 0)
            {
                search.SearchResultEmpty = $"No Person or City could be found, matching \"{search.FilterString}\" ";
            }
            else
            {
                search.SearchResultEmpty = "";
            }

            return search;

        }

        public Country FindBy(int id)
        {
            Country foundCountry = _countryRepo.Read(id);

            return foundCountry;
        }

        public bool Remove(int id)
        {
            Country countryToDelete = _countryRepo.Read(id);
            bool success = _countryRepo.Delete(countryToDelete);

            return success;
        }

        public void CreateBaseCountries()
        {
            _countryRepo.Create("Sweden");
            _countryRepo.Create("Norway");
            _countryRepo.Create("Finland");
            _countryRepo.Create("Netherlands");
        }


    }


}

using ER_Smms.Models;
using ER_Smms.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface ICityService
    {
        City Add(string cityName, Country country);

        CityViewModel All();

        CityViewModel FindBy(CityViewModel search);

        City FindBy(int id);

        City Edit(int id, City person);

        bool Remove(int id);

        void CreateBaseCities(List<Country> countries);

    }
}

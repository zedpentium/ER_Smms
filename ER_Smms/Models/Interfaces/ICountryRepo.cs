using ER_Smms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface ICountryRepo
    {
        Country Create(string countryName);


        List<Country> Read();


        Country Read(int id);


        Country Update(Country country);


        bool Delete(Country country);
    }
}

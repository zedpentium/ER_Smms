using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels
{

    public class CityViewModel : CreateCityViewModel
    {
        public List<City> CityListView { get; set; }

        public List<Country> CountryListView { get; set; }


        public string FilterString { get; set; }

        public string SearchResultEmpty { get; set; }



        public CityViewModel()
        {
            CityListView = new List<City>();
        }

    }
}

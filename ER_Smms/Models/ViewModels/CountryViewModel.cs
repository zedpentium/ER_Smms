using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ER_Smms.Models;

namespace ER_Smms.Models.ViewModels
{

    public class CountryViewModel : CreateCountryViewModel
    {
        public List<Country> CountryListView { get; set; }


        public string FilterString { get; set; }

        public string SearchResultEmpty { get; set; }



        public CountryViewModel()
        {
            CountryListView = new List<Country>();
        }

    }
}

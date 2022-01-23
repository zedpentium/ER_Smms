using ER_Smms.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IPeopleService
    {
        Person Add(CreatePersonViewModel person);

        public bool AddLanguageToPerson(PersonLanguageViewModel personLanguageViewModel);

        PeopleViewModel All();

        PeopleViewModel FindBy(PeopleViewModel search);

        Person FindBy(int id);

        Person Edit(int id, Person person);

        bool Remove(int id);

        void CreateBasePeople(List<City> cList);
    }
}

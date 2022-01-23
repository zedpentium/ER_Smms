using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ER_Smms.Models.ViewModels;
using ER_Smms.Models.Interfaces;

namespace ER_Smms.Models.Services
{
    public class PeopleService : IPeopleService
    {
        //All new InMemoryPeopleRepo() is now replaced by DI via this Constructor, and using _peopleRepo instead /ER
        private readonly IPeopleRepo _peopleRepo;

        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }


        public Person Add(CreatePersonViewModel person)
        {
            City city = person.Cities.Find(c => c.CityId == Convert.ToInt32(person.PersonCity));
            Person madePerson = _peopleRepo.Create(person.PersonName, person.PersonPhoneNumber, city);

            return madePerson;
        }

        public bool AddLanguageToPerson(PersonLanguageViewModel personLanguageViewModel)
        {

            bool success = _peopleRepo.AddLanguageToPerson(personLanguageViewModel);

            if (success)
            {
                return true;
            }
            else { return false; }
        }

        public PeopleViewModel All()
        {
            PeopleViewModel pViewMod = new PeopleViewModel()
            {
                PeopleListView = _peopleRepo.Read(),
            };

            return pViewMod;
        }

        public Person Edit(int id, Person person)
        {
            throw new NotImplementedException();
        }

        public PeopleViewModel FindBy(PeopleViewModel search)
        {
            search.PeopleListView.Clear();

            List<Person> personList = _peopleRepo.Read();

            foreach (Person item in personList)
            {
                if (item.PersonName.Contains(search.FilterString, StringComparison.OrdinalIgnoreCase) ||
                    item.City.CityName.Contains(search.FilterString, StringComparison.OrdinalIgnoreCase) /*||
                    item.PersonLanguages.LanguageName.Contains(search.FilterString, StringComparison.OrdinalIgnoreCase)*/)
                {
                    search.PeopleListView.Add(item);
                }
            }

            if (search.PeopleListView.Count == 0)
            {
                search.SearchResultEmpty = $"No Person or City could be found, matching \"{search.FilterString}\" ";
            }
            else
            {
                search.SearchResultEmpty = "";
            }

            return search;

        }

        public Person FindBy(int id)
        {
            Person foundPerson = _peopleRepo.Read(id);

            return foundPerson;
        }

        public bool Remove(int id)
        {
            Person personToDelete = _peopleRepo.Read(id);

            if (personToDelete != null)
            {
                bool success = _peopleRepo.Delete(personToDelete);

                return success;
            }

            return false;
        }

        public void CreateBasePeople(List<City> cities)
        {
            _peopleRepo.Create("Eric Rönnhult", "0777 777777", cities[0]);
            _peopleRepo.Create("Bosse Bus", "0777 777777", cities[1]);
            _peopleRepo.Create("Kjell Kriminell", "0777 777777", cities[2]);
            _peopleRepo.Create("Anders Rolle", "0777 777777", cities[3]);

        }
    }

}

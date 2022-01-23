using ER_Smms.Models;
using ER_Smms.Models.Interfaces;
using ER_Smms.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ER_Smms.Data
{
    public class DbPeopleRepo : IPeopleRepo
    {
        private readonly AppDbContext _peopleListContext;

        public DbPeopleRepo(AppDbContext peopleListContext)
        {
            _peopleListContext = peopleListContext;

        }


        public Person Create(string personName, string personPhoneNumber, City city)
        {
            Person newPerson = new Person(personName, personPhoneNumber, city);

            _peopleListContext.Add(newPerson);
            _peopleListContext.SaveChanges();

            return newPerson;
        }

        public bool AddLanguageToPerson(PersonLanguageViewModel personLanguageViewModel)
        {
            int nrStates;

            Person updatePersonLang = _peopleListContext.People // load person with languages
                .Where(c => c.PersonId == personLanguageViewModel.PersonId)
                .Include(f => f.PersonLanguages)
                .ThenInclude(g => g.Language)
                .First();

            List<Language> dbLangList = _peopleListContext.Languages.ToList();

            Language foundLang = new Language();

            // Make new list of PersonLanguage associated with that PersonId above.
            // And make the correct object-path build.   Person.List<PersonLanguage>.PersonLanguage.Language 
            List<PersonLanguage> addPersonLang = new List<PersonLanguage> { };

            foreach (string id in personLanguageViewModel.SelectedListBoxView)
            {
                foundLang = dbLangList.Find(la => la.LanguageId == Convert.ToInt32(id));
                PersonLanguage personLanguage = new PersonLanguage() { Language = foundLang };
                addPersonLang.Add(personLanguage);
            }

            updatePersonLang.PersonLanguages = addPersonLang;


            nrStates = _peopleListContext.SaveChanges();

            if (nrStates > 0)
            {
                return true;
            }

            return false;
        }



        public List<Person> Read()
        {
            List<Person> pList = _peopleListContext.People
                .Include(d => d.City)
                .Include(e => e.City.Country)
                .Include(f => f.PersonLanguages).ThenInclude(g => g.Language)
                .ToList();

            return pList;
        }

        public Person Read(int id)
        {
            Person person = _peopleListContext.People
                .Where(c => c.PersonId == id)
                .Include(d => d.City)
                .Include(e => e.City.Country)
                .Include(f => f.PersonLanguages).ThenInclude(g => g.Language)
                .FirstOrDefault();

            return person;
        }

        public Person Update(Person person)
        {
            _peopleListContext.People.Update(person);
            _peopleListContext.SaveChanges();

            return person;
        }

        public bool Delete(Person person)
        {
            int nrStates;

            _peopleListContext.People.Remove(person);
            nrStates = _peopleListContext.SaveChanges();

            if (nrStates > 0)
            {
                return true;
            }

            return false;


        }

    }
}

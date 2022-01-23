using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ER_Smms.Models;
using ER_Smms.Models.Interfaces;
using ER_Smms.Models.ViewModels;

namespace ER_Smms.Models.Services
{
    public class LanguageService : ILanguageService
    {
        //All new InMemoryPeopleRepo() is now replaced by DI via this Constructor, and using _peopleRepo instead /ER
        private readonly ILanguageRepo _languageRepo;

        public LanguageService(ILanguageRepo languageRepo)
        {
            _languageRepo = languageRepo;
        }


        public Language Add(CreateLanguageViewModel createLanguageViewModel)
        {
            Language madeLanguage = _languageRepo.Create(createLanguageViewModel.LanguageName);

            return madeLanguage;
        }

        public LanguageViewModel All()
        {
            LanguageViewModel languageViewModel = new LanguageViewModel() { LanguageListView = _languageRepo.Read() };

            return languageViewModel;
        }

        public Language Edit(int id, Language language)
        {
            throw new NotImplementedException();
        }

        public LanguageViewModel FindBy(LanguageViewModel search)
        {
            search.LanguageListView.Clear();

            List<Language> languageList = _languageRepo.Read();

            foreach (Language item in languageList)
            {
                if (item.LanguageName.Contains(search.FilterString, StringComparison.OrdinalIgnoreCase))
                {

                    search.LanguageListView.Add(item);
                }
            }

            if (search.LanguageListView.Count == 0)
            {
                search.SearchResultEmpty = $"No Person or City could be found, matching \"{search.FilterString}\" ";
            }
            else
            {
                search.SearchResultEmpty = "";
            }

            return search;

        }

        public Language FindBy(int id)
        {
            Language foundLanguage = _languageRepo.Read(id);

            return foundLanguage;
        }

        public bool Remove(int id)
        {
            Language languageToDelete = _languageRepo.Read(id);
            bool success = _languageRepo.Delete(languageToDelete);

            return success;
        }

        public void CreateBaseLanguages()
        {
            _languageRepo.Create("Swedish");
            _languageRepo.Create("Norwegian");
            _languageRepo.Create("Finnish");
            _languageRepo.Create("Dutch");
        }


    }
}

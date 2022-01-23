using ER_Smms.Models;
using ER_Smms.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface ILanguageService
    {
        Language Add(CreateLanguageViewModel createLanguageViewModel);

        LanguageViewModel All();

        LanguageViewModel FindBy(LanguageViewModel search);

        Language FindBy(int id);

        Language Edit(int id, Language language);

        bool Remove(int id);

        void CreateBaseLanguages();

    }
}

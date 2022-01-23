using ER_Smms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface ILanguageRepo
    {
        Language Create(string languageName);


        List<Language> Read();


        Language Read(int id);


        Language Update(Language language);


        bool Delete(Language language);

    }
}

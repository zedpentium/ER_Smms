using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ER_Smms.Models
{
    public class Language
    {
        private int _languageId;
        private string _languageName;

        public Language()
        { }

        public Language(List<Person> people)
        {
            People = people;
        }

        public Language(string languageName)
        {
            LanguageName = languageName;
        }

        //public Language(List<PersonLanguage> people)
        //{
        //    People = people;
        //}


        public int LanguageId
        {
            get { return _languageId; }
            set { _languageId = value; }
        }


        public string LanguageName
        {
            get { return _languageName; }
            set { _languageName = value; }
        }

        public List<Person> People { get; set; }  // commented out to get many-to-many to work in EF Core  /ER

        [JsonIgnore]
        public List<PersonLanguage> PersonLanguages { get; set; } = new List<PersonLanguage>(); // Join table-navigation-relation EF Core Specific with no lazy loading /ER

    }
}

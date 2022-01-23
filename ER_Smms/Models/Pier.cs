using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ER_Smms.Models
{
    public class Pier
    {
        public Pier()
        { }

        public Pier(string label, string info)
        {
            Label = label;
            Info = info;
        }

        public Pier(string label, string info, Harbour obj)
        {
            Label = label;
            Info = info;
            Harbour = obj;
        }

        public int Id { get; set; }

        public string Label { get; set; }

        public string Info { get; set; }


        //public Pier PierId { get; set; }

        public Harbour Harbour { get; set; }

        //public List<HarbourPier> HarbourPiers { get; set; } //= new List<PersonLanguage>();// Join table-navigation-relation EF Core Specific with no lazy loading /ER

    }


}

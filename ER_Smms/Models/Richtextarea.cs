using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using ER_Smms.Models.ViewModels;

namespace ER_Smms.Models
{
    public class Richtextarea
    {
        //public Harbour()
        //{ }

        //public Harbour(string label, string info)
        //{
        //    Label = label;
        //    Info = info;
        //}

        public int Id { get; set; }

        public string Label { get; set; }

        public string Info { get; set; }

        public string MapURL { get; set; }


        public List<Pier> Piers { get; set; }


    }



}

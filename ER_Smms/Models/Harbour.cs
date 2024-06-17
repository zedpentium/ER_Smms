using System.Collections.Generic;
//using Newtonsoft.Json;
using System.Text.Json.Serialization;


namespace ER_Smms.Models
{
    public class Harbour : DateCreatedEdited
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

        [JsonIgnore]
        public List<Pier> Piers { get; set; }


    }



}

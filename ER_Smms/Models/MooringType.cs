using System.Collections.Generic;
//using Newtonsoft.Json;
using System.Text.Json.Serialization;


namespace ER_Smms.Models
{
    public class MooringType
    {

        public MooringType()
        { }

        public MooringType(string label, string info)
        {
            Label = label;
            Info = info;
        }

        public int Id { get; set; }

        public string Label { get; set; }

        public string Info { get; set; }


        [JsonIgnore]
        public List<Boatslip> Boatslips { get; set; }
    }



}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ER_Smms.Models
{
    public class HistoryPier
    {

        public int Id { get; set; }

        public string Note { get; set; }

        public string Boatslip { get; set; }

        public string Winterstorespot { get; set; }

    }

}

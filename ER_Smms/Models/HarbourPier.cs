using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ER_Smms.Models
{
    public class HarbourPier // this is a join entity class for the many-to-many table.
                             // Can be used as One.to.Many
                             // Quote: "In EF Core up to and including 3.x, it is necessary to include an entity in the model
                             // to represent the join table, and then add navigation properties to either side of the
                             // many-to-many relations that point to the join entity."  /ER
    {

        public int HarbourId { get; set; }

        public Harbour Harbour { get; set; }


        public int PierId { get; set; }

        public Pier Pier { get; set; }

    }

}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ER_Smms.Models
{
    public class UserBoatslip // this is a join entity class for the many-to-many table.
    //                            // Quote: "In EF Core up to and including 3.x, it is necessary to include an entity in the model
    //                            // to represent the join table, and then add navigation properties to either side of the
    //                            // many-to-many relations that point to the join entity."  /ER
    {

        public int IdentityAppUser_Id { get; set; }

        public IdentityAppUser IdentityAppUser { get; set; }


        public int Boatslip_Id { get; set; }

        public Boatslip Boatslip { get; set; }

    }

}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ER_Smms.Models
{
    public class ServiceHistory : DateCreatedEdited
    {
        public int Id { get; set; }

        public IdentityAppUser Customer { get; set; }

        public BoatData BoatData { get; set; }

        public ServiceType ServiceType { get; set; }

        public Boatslip Boatslip { get; set; }

        public WinterstoreSpot WinterstoreSpot { get; set; }
}

}

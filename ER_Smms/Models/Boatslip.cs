using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ER_Smms.Models
{
    public class Boatslip
    {
        public Boatslip(string label, int lenght, int width, int depth, string mooringType)
        {
            Label = label;
            Lenght = lenght;
            Width = width;
            Depth = depth;
            MooringType = mooringType;

        }


        public int Id { get; set; }

        public string Label { get; set; }

        public int Lenght { get; set; }

        public int Width { get; set; }

        public int Depth { get; set; }

        public string MooringType { get; set; }



        public Pier Pier { get; set; }

    }

}

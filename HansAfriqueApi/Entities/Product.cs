using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Entities
{
    public class Product : BaseEntity
    {

        public int OEM { get; set; }
        public string PCB { get; set; }
        public string Other_OEM { get; set; }
        public string HFR { get; set; }
        public string LUK { get; set; }
        public string Miba { get; set; }
        public string Dimensions { get; set; }
        public string PictureUrl { get; set; }
        public Part Part { get; set; }
        public int PartId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }
        public decimal Price { get; set; }
        public string Category_List { get; set; }

    }
}

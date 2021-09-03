using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Entities
{
    public class Product : BaseEntity
    {
        public string OEM_Part { get;set;}
        public string PCB_Part { get;set;}
        public string HFR_Part { get;set;}
        public string LUK_Part { get; set; }
        public string Dimensies { get;set;}
        public string Foto { get; set; }
        public string PartType { get; set; }
        public string Part_Description { get; set; }
        public string Tractor_Model { get; set; }
        public string Tractor { get; set; }
        public string Miba { get; set; }
        public string VehicleType { get; set; }
        public string Part_Price_Exc { get; set; }
        public string ALP_Part { get; set; }

    }
}

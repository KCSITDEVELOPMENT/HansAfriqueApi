using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Dto
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string OEM_Part_Number { get; set; }
        public string HFR_Part_Number { get; set; }
        public string PCB_Part_Number { get; set; }
        public string LUK_Part_Number { get; set; }
        public int Brandid { get; set; }
        public int Vehicleid { get; set; }
        public int Supplierid { get; set; }
        public string PictureULR { get; set; }
    }
}

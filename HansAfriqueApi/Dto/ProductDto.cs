using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Dto
{
    public class ProductDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Vehicle { get; set; }
        public string Supplier { get; set; }
        public string PictureULR { get; set; } 
        public decimal Price { get; set; }
        public string PartCategory { get; set; }
        public string PartCode { get; set; }
        public string VehicleModel { get; set; }
        public string PartNumber { get; set; }
    }
}

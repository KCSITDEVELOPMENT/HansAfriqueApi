using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Dto
{
    public class CreateProductDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Brand { get; set; }
        public int Vehicle { get; set; }
        public int Supplier { get; set; }
        public string PictureULR { get; set; }
        public decimal Price { get; set; }
        public int PartCategory { get; set; }
        public string PartCode { get; set; }
        public string VehicleModel { get; set; }
        public int PartNumber { get; set; }
    }
}

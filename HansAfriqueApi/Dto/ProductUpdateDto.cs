using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Dto
{
    public class ProductUpdateDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Brandid { get; set; }
        public int Vehicleid { get; set; }
        public int Supplierid { get; set; }
        public string PictureULR { get; set; }
        public decimal Price { get; set; }
        public int PartCategoryid { get; set; }
        public string PartCode { get; set; }
        public int PartNumberid { get; set; }
        public string VehicleModel { get; set; }
    }
}

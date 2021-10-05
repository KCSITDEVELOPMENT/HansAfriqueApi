using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Entities
{
    public class Part : BaseEntity
    {
        public string Name { get; set; }
        public Brand Brand { get; set; }
        public int Brandid { get; set; }
        public Vehicle Vehicle { get; set; }
        public int Vehicleid { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public Supplier Supplier { get; set; }
        public int Supplierid { get; set; }
        public PartCategory PartCategory { get; set; }
        public int PartCategoryid { get; set; }
        public decimal Price { get; set; }
        public string PartCode { get; set; }
        public int PartNumberid { get; set; }
        public PartNumber PartNumber { get; set; }
        public string VehicleModel { get; set; }
        public string PictureULR { get; set; }
    }
}

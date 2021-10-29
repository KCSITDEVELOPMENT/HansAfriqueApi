using HansAfriqueApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Specifications
{
    public class ProductFiltersCountSpecification : BaseSpecification<Part>
    {
        public ProductFiltersCountSpecification(ProductSpecParams productParams)
            : base(x =>
             (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.BrandId.HasValue || x.Brandid == productParams.BrandId) &&
            (!productParams.VehicleId.HasValue || x.Vehicleid == productParams.VehicleId) &&
            (!productParams.SupplierId.HasValue || x.Supplierid == productParams.SupplierId) &&
            (!productParams.PartCategoryId.HasValue || x.PartCategoryid == productParams.PartCategoryId) &&
            (!productParams.PartNumerid.HasValue || x.PartNumberid == productParams.PartNumerid)
            )
        {


        }
    }
}

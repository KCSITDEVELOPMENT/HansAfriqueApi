using HansAfriqueApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HansAfriqueApi.Specifications
{
    public class ProductSpecifications : BaseSpecification<Part>
    {
        public ProductSpecifications(ProductSpecParams productParams)
                : base(x =>
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search))&&
            (!productParams.BrandId.HasValue || x.Brandid == productParams.BrandId) &&
            (!productParams.VehicleId.HasValue || x.Vehicleid == productParams.VehicleId) &&
            (!productParams.SupplierId.HasValue || x.Supplierid == productParams.SupplierId) &&
            (!productParams.PartCategoryId.HasValue || x.PartCategoryid == productParams.PartCategoryId)&&
            (!productParams.PartNumerid.HasValue || x.PartNumberid== productParams.PartNumerid)
            )
        {
            AddInclude(x => x.Brand);
            AddInclude(x => x.PartCategory);
            AddInclude(x => x.Supplier);
            AddInclude(x => x.Vehicle);
            AddInclude(x => x.PartNumber);
            AddInclude(x => x.Photo);
            AddOrderBy(x => x.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1),
                productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ProductSpecifications(int id): base(x =>x.id == id)
        {
            AddInclude(x => x.Brand);
            AddInclude(x => x.PartCategory);
            AddInclude(x => x.Supplier);
            AddInclude(x => x.Vehicle);
            AddInclude(x => x.PartNumber); 
            AddInclude(x => x.Photo);
        }
    }
}

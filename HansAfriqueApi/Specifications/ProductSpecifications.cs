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
        public ProductSpecifications(string sort, int? brandid, int? vehicleid, int? supplierid, int? partCategoryid)
            : base(x =>
            (!brandid.HasValue || x.Brandid == brandid) &&
            (!vehicleid.HasValue || x.Vehicleid == vehicleid) &&
            (!supplierid.HasValue || x.Supplierid == supplierid) &&
            (!partCategoryid.HasValue || x.PartCategoryid == partCategoryid)
            )
        {
            AddInclude(x => x.Brand);
            AddInclude(x => x.PartCategory);
            AddInclude(x => x.Supplier);
            AddInclude(x => x.Vehicle);
            AddInclude(x => x.PartNumber);
            AddInclude(x => x.Photo);
            AddOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(sort)) 
            {
                switch (sort)
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

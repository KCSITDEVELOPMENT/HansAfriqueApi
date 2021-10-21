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
        public ProductSpecifications()
        {
            AddInclude(x => x.Brand);
            AddInclude(x => x.PartCategory);
            AddInclude(x => x.Supplier);
            AddInclude(x => x.Vehicle);
            AddInclude(x => x.PartNumber);
            AddInclude(x => x.Photo);
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

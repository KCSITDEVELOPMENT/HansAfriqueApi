using HansAfriqueApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Interface
{
    public interface IProduct
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductsBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}

using HansAfriqueApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Interface
{
    public interface IProduct
    {
        Task<Part> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Part>> GetProductsAsync();
        Task<IReadOnlyList<Brand>> GetProductsBrandsAsync();
        Task<IReadOnlyList<Supplier>> GetProductsSuppliersAsync();
        Task<IReadOnlyList<Vehicle>> GetVehicleAsync();
    }
}

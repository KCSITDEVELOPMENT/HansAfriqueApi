using HansAfriqueApi.Data;
using HansAfriqueApi.Entities;
using HansAfriqueApi.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Repositories
{
    public class ProductsRepository : IProduct
    {
        private DataContext _context;

        public ProductsRepository(DataContext context) 
        {
            _context = context;
        }


        public async Task<Part> GetProductByIdAsync(int id)
        {
            return await _context.Parts
                .Include(p => p.Brand)
                .Include(p => p.Vehicle)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync( p => p.id == id);
        }

        public async Task<IReadOnlyList<Part>> GetProductsAsync()
        {
            return await _context.Parts
                .Include(p  => p.Brand)
                .Include(p => p.Vehicle)
                .Include(p => p.Supplier)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Brand>> GetProductsBrandsAsync()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<IReadOnlyList<Supplier>> GetProductsSuppliersAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<IReadOnlyList<Vehicle>> GetVehicleAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }


    }
}

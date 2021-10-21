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

        public async Task<IReadOnlyList<PartCategory>> GetCategoryAsync()
        {
            return await _context.PartCategories.ToListAsync();
        }

        public async Task<Part> GetProductByIdAsync(int id)
        {
            return await _context.Parts
                .Include(p => p.Brand)
                .Include(p => p.Vehicle)
                .Include(p => p.Supplier)
                //.Include(p => p.FileData)
                .FirstOrDefaultAsync( p => p.id == id);
        }

        public async Task<IReadOnlyList<Part>> GetProductsAsync()
        {
            return await _context.Parts
                .Include(p  => p.Brand)
                .Include(p => p.Vehicle)
                .Include(p => p.Supplier)
                //.Include(p => p.FileData)
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


        public async Task AddProduct(Part part)
        {
            _context.Parts.Add(part);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Part part)
        {
            var ProductToUpdate = await _context.Parts.FindAsync(part.id);
            if (ProductToUpdate == null)
                throw new NullReferenceException();

            ProductToUpdate.Name = part.Name;
            ProductToUpdate.PartNumberid = part.PartCategoryid;
            ProductToUpdate.PartCode = part.PartCode;
            ProductToUpdate.PartNumberid = part.PartNumberid;
            ProductToUpdate.Price = part.Price;
            ProductToUpdate.VehicleModel = part.VehicleModel;
            await _context.SaveChangesAsync();
        }


        public async Task DeleteProduct(Part part)
        {
            var ProductToUpdate = await _context.Parts.FindAsync(part.id);
            if (ProductToUpdate == null)
                throw new NullReferenceException();

            _context.Parts.Remove(ProductToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}

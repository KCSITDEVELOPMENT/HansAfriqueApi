using HansAfriqueApi.Data;
using HansAfriqueApi.Entities;
using HansAfriqueApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Repositories
{
    public class ProductOperationsRepository : IProductOperationsInterface
    {
        private readonly DataContext _context;

        public ProductOperationsRepository(DataContext context)
        {
            _context = context;
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


        public async Task DeleteProduct(int id)
        {
            var ProductToUpdate = await _context.Parts.FindAsync(id);
            if (ProductToUpdate == null)
                throw new NullReferenceException();

            _context.Parts.Remove(ProductToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}

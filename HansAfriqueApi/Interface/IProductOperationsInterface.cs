using HansAfriqueApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Interface
{
    public interface IProductOperationsInterface
    {
        Task AddProduct(Part part);
        Task UpdateProduct(Part part);
        Task DeleteProduct(int id);
    }
}

using HansAfriqueApi.Entities;
using HansAfriqueApi.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Interface
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecifications<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecifications<T> spec);
        Task<int> CountAsync(ISpecifications<T> spec);
    }
}

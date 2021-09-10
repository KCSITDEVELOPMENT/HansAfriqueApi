using HansAfriqueApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Interface
{
    public interface IUserRepository
    {
        void Update(Person person);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Person>> GetUsersAsync();
        Task<Person> GetUserByIdAsync( int id);
        Task <Person> GetUsersByUsernameAsync( string username);
    }
}

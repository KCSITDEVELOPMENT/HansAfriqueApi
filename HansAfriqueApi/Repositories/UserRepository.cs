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
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository( DataContext context) 
        {
            _context = context;
        }



        public async Task<Person> GetUserByIdAsync(int id)
        {
            return await _context.People.FindAsync(id);
        }

        public async Task<IEnumerable<Person>> GetUsersAsync()
        {
            return await _context.People.ToListAsync();
        }

        public async Task<Person> GetUsersByUsernameAsync(string username)
        {
            return await _context.People.SingleOrDefaultAsync( x => x.Username == username);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
        }
    }
}

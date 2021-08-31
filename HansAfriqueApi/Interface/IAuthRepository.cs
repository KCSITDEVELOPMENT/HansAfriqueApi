using HansAfriqueApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Interface
{
    public interface IAuthRepository
    {
        Task<Person> Register(Person person, string password);
        Task<Person> Login(string username, string password);
        Task<bool> UserExist(string Username);
    }
}

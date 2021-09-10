using AutoMapper;
using HansAfriqueApi.Data;
using HansAfriqueApi.Dto;
using HansAfriqueApi.Entities;
using HansAfriqueApi.Interface;
using HansAfriqueApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static HansAfriqueApi.Controllers.BaseController;

namespace HansAfriqueApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController :  ControllerBase
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenservice;
        private readonly IAuthRepository _repo;
        private readonly IMapper _mapper;
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository, DataContext context, ITokenService tokenservice, IAuthRepository repo, IMapper mapper)
            {
                _context = context;
            _tokenservice = tokenservice;
            _repo = repo;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<Person>> GetUser(string username)
        {

            return await _userRepository.GetUsersByUsernameAsync(username);
        }

        // GET: api/People/5
        [Authorize]
            [HttpGet("{id}")]
            public async Task<ActionResult<User>> GetPerson(int id)
            {
                var getperson = await _context.Users.FindAsync(id);
                return getperson;
            }


        // PUT: api/People/5
        [HttpPut("{id}")]
            public async Task<IActionResult> PutPerson(int id, Person person)
            {
                if (id != person.Id)
                {
                    return BadRequest();
                }

                _context.Entry(person).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }

            // POST: api/People
            [HttpPost]
            public async Task<ActionResult<User>> PostPerson(User user)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPerson", new { id = user.Id }, user);
            }

            // DELETE: api/People/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<User>> DeletePerson(int id)
            {
                var person = await _context.Users.FindAsync(id);
                if (person == null)
                {
                    return NotFound();
                }

                _context.Users.Remove(person);
                await _context.SaveChangesAsync();

                return person;
            }

            private bool PersonExists(int id)
            {
                return _context.People.Any(e => e.Id == id);
            }
        }
    }


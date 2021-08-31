using HansAfriqueApi.Data;
using HansAfriqueApi.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HansAfriqueApi.Controllers.BaseController;

namespace HansAfriqueApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController :  ControllerBase
    {
        private readonly DataContext _context;
   

            public UserController(DataContext context)
            {
                _context = context;
            }
            // GET api/values
            [HttpGet]
            public ActionResult<IEnumerable<Person>> GetUsers()
            {
                var people = _context.People.ToList();
                return people; 
            }

            // GET: api/People/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Person>> GetPerson(int id)
            {
                var getperson = await _context.People.FindAsync(id);
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
            public async Task<ActionResult<Person>> PostPerson(Person user)
            {
                _context.People.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPerson", new { id = user.Id }, user);
            }

            // DELETE: api/People/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<Person>> DeletePerson(int id)
            {
                var person = await _context.People.FindAsync(id);
                if (person == null)
                {
                    return NotFound();
                }

                _context.People.Remove(person);
                await _context.SaveChangesAsync();

                return person;
            }

            private bool PersonExists(int id)
            {
                return _context.People.Any(e => e.Id == id);
            }
        }
    }


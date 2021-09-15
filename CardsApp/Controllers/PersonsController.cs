using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CardsApp.Data;
using CardsApp.Models;

namespace CardsApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly CardsContext _context;

        public PersonsController(CardsContext context)
        {
            _context = context;
        }


        // POST: api/Persons
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person Person)
        {
            _context.Person.Add(Person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = Person.IdPerson }, Person);
        }

        // GET: api/Persons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            return await _context.Person.ToListAsync();
        }

        // GET: api/Persons/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var Person = await _context.Person.FindAsync(id);

            if (Person == null)
            {
                return NotFound();
            }

            return Person;
        }


        // DELETE: api/Persons/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var Person = await _context.Person.FindAsync(id);
            if (Person == null)
            {
                return NotFound();
            }

            _context.Person.Remove(Person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Persons/2
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person Person)
        {
            if (id != Person.IdPerson)
            {
                return BadRequest();
            }

            _context.Entry(Person).State = EntityState.Modified;

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

      

      

        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.IdPerson == id);
        }
    }
}

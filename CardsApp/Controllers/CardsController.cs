using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CardsApp.Data;
using CardsApp.Helpers;
using CardsApp.Models;

namespace CardsApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly CardsContext _context;

        public CardsController(CardsContext context)
        {
            _context = context;
        }


        // POST: api/Cards
        [HttpPost]
        public async Task<ActionResult<Card>> PostCard(Card Card)
        {
            _context.Card.Add(Card);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCard", new { id = Card.IdCard }, Card);
        }

        // Invoke a method that returns all the information of a Card
        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetCard(int id)
        {
            var Card = await _context.Card.FindAsync(id);

            if (Card == null)
            {
                return NotFound();
            }

            return Card;
        }


        //all the Cards that a Person has requested
        [HttpGet("DePerson/{IdPerson}")]
        public async Task<ActionResult<IEnumerable<Card>>> GetCards(int IdPerson)
        {
            return await _context.Card.Where(x => x.IdPerson == IdPerson).ToListAsync();
        }

        //todas las Cards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> GetCards()
        {
            return await _context.Card.ToListAsync();
        }

        // DELETE: api/Cards/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            var Card = await _context.Card.FindAsync(id);
            if (Card == null)
            {
                return NotFound();
            }

            _context.Card.Remove(Card);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardExists(int id)
        {
            return _context.Card.Any(e => e.IdCard == id);
        }

        // PUT: api/Cards/2
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCard(int id, Card Card)
        {
            if (id != Card.IdCard)
            {
                return BadRequest();
            }

            _context.Entry(Card).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(id))
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

        //Report if an operation is valid
        [HttpGet("OperacionValida/{amount}")]
        public ActionResult<bool> TransactionIsValid(double amount)
        {
            return TransactionHelpers.IsTransactionValid(amount);
        }

        //Inform if a Card is valid to operate
        [HttpGet("CardIsValid/{id}")]
        public async Task<ActionResult<bool>> CardIsValid(int id)
        {
            var Card = await _context.Card.FindAsync(id);
            return CardHelpers.IsCardValid(Card);
        }

    }
}

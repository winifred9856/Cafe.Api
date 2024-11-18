using Cafe.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkController : ControllerBase
    {
        private readonly cafecontext _context;

        public DrinkController(cafecontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllDrink()
        {
            return Ok(await _context.Drink.ToArrayAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDrink(int id)
        {
            var Drink = await _context.Drink.FindAsync(id);
            if (Drink == null)
            {
                return NotFound();
            }
            return Ok(Drink);
        }

        [HttpPost]
        public async Task<ActionResult<Drink>> PostDrink(Drink Drink)
        {
            /*
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            */
            _context.Drink.Add(Drink);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetDrink",
                new { id = Drink.Id },
                Drink);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutDrink(int id, Drink Drink)
        {
            if (id != Drink.Id)
            {
                return BadRequest();
            }

            _context.Entry(Drink).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Drink.Any(p => p.Id == id))
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<Drink>> DeleteBook(int id)
        {
            var Drink = await _context.Drink.FindAsync(id);
            if (Drink == null)
            {
                return NotFound();
            }

            _context.Drink.Remove(Drink);
            await _context.SaveChangesAsync();

            return Drink;
        }
    }
}

using Cafe.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnackController : ControllerBase
    {
        private readonly cafecontext _context;

        public SnackController(cafecontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllSnack()
        {
            return Ok(await _context.Snack.ToArrayAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSnack(int id)
        {
            var Snack = await _context.Snack.FindAsync(id);
            if (Snack == null)
            {
                return NotFound();
            }
            return Ok(Snack);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostSnack(Snack Snack)
        {
            /*
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            */
            _context.Snack.Add(Snack);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetSnack",
                new { id = Snack.Id },
                Snack);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutSnack(int id, Snack Snack)
        {
            if (id != Snack.Id)
            {
                return BadRequest();
            }

            _context.Entry(Snack).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Snack.Any(p => p.Id == id))
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
        public async Task<ActionResult<Snack>> DeleteSnack(int id)
        {
            var Snack = await _context.Snack.FindAsync(id);
            if (Snack == null)
            {
                return NotFound();
            }

            _context.Snack.Remove(Snack);
            await _context.SaveChangesAsync();

            return Snack;
        }
    }
}
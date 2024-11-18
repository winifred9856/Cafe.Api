
using Cafe.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly cafecontext _context;

        public OrderController(cafecontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllOrder()
        {
            return Ok(await _context.Order.ToArrayAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrder(int id)
        {
            var Order = await _context.Order.FindAsync(id);
            if (Order == null)
            {
                return NotFound();
            }
            return Ok(Order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order Order)
        {
            /*
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            */
            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetOrder",
                new { id = Order.Id },
                Order);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutOrder(int id, Order Order)
        {
            if (id != Order.Id)
            {
                return BadRequest();
            }

            _context.Entry(Order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Order.Any(p => p.Id == id))
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
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var Order = await _context.Order.FindAsync(id);
            if (Order == null)
            {
                return NotFound();
            }

            _context.Order.Remove(Order);
            await _context.SaveChangesAsync();

            return Order;
        }
    }
}
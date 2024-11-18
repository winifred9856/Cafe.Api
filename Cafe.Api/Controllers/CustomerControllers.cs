
using Cafe.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly  cafecontext _context;

        public CustomerController(cafecontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCustomer()
        {
            return Ok(await _context.Customer.ToArrayAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCustomer(int id)
        {
            var Customer = await _context.Customer.FindAsync(id);
            if (Customer == null)
            {
                return NotFound();
            }
            return Ok(Customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer Customer)
        {
            /*
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            */
            _context.Customer.Add(Customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetCustomer",
                new { id = Customer.Id },
                Customer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutCustomer(int id, Customer Customer)
        {
            if (id != Customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(Customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Customer.Any(p => p.Id == id))
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
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var Customer = await _context.Customer.FindAsync(id);
            if (Customer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(Customer);
            await _context.SaveChangesAsync();

            return Customer;
        }
    }
}
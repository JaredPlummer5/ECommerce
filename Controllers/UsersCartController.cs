using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersCartController : ControllerBase
    {
        private readonly ECommerceDbContext _context;

        public UsersCartController(ECommerceDbContext context)
        {
            _context = context;
        }

        // GET: api/UsersCart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersCart>>> GetCarts()
        {
            if (_context.Carts == null)
            {
                return NotFound();
            }
            return await _context.Carts.ToListAsync();
        }

        // GET: api/UsersCart/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersCart>> GetUsersCart(int id)
        {
            if (_context.Carts == null)
            {
                return NotFound();
            }
            var usersCart = await _context.Carts.FindAsync(id);

            if (usersCart == null)
            {
                return NotFound();
            }

            return usersCart;
        }

        // PUT: api/UsersCart/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsersCart(int id, UsersCart usersCart)
        {
            if (id != usersCart.Id)
            {
                return BadRequest();
            }

            _context.Entry(usersCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersCartExists(id))
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

        // POST: api/UsersCart
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsersCart>> PostUsersCart(UsersCart usersCart)
        {
            if (_context.Carts == null)
            {
                return Problem("Entity set 'ECommerceDbContext.Carts'  is null.");
            }
            _context.Carts.Add(usersCart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsersCart", new { id = usersCart.Id }, usersCart);
        }

        // DELETE: api/UsersCart/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsersCart(int id)
        {
            if (_context.Carts == null)
            {
                return NotFound();
            }
            var usersCart = await _context.Carts.FindAsync(id);
            if (usersCart == null)
            {
                return NotFound();
            }

            _context.Carts.Remove(usersCart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersCartExists(int id)
        {
            return (_context.Carts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

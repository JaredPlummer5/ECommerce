using System;
using ECommerce.Data;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.Controllers;
[ApiController]
[Route("[controller]")]

public class CategeoriesController : Controller
{
    private readonly ECommerceDbContext _context;
    public CategeoriesController(ECommerceDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    [AllowAnonymous]
    public async Task<IEnumerable<Category>> GetCategeories()
    {
        var categeories = _context.Categories.Include(c => c.Products).ToList();
        return categeories.ToArray();
    }

    [HttpPost]
    [Route("CreateCategory")]
    [Authorize(Policy = "Admin")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<ActionResult> CreateCategeory([FromBody] Category categeoryFromBody)
    {

        Category categeory = new Category(categeoryFromBody.Name, categeoryFromBody.Description);
        _context.Categories.Add(categeory);
        _context.SaveChanges();
        return Ok(categeory);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategoryDetails(int id)
    {
        var categeory = await _context.Categories
                                      .Include(c => c.Products) // Assuming a navigation property for products
                                      .FirstOrDefaultAsync(c => c.Id == id);

        if (categeory == null)
        {
            return NotFound();
        }

        return categeory;
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "Admin")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<ActionResult> DeleteCategory(int id)
    {
        var categeory = await _context.Categories
                                        .Include(c => c.Products) // Include products
                                        .SingleOrDefaultAsync(c => c.Id == id);
        if (categeory == null)
        {
            return NotFound();
        }

        _context.Categories.Remove(categeory);
        await _context.SaveChangesAsync();

        return Ok(categeory);
    }

    [HttpPut("{id}")]
    [Authorize(Policy = "Editor")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<ActionResult> UpdateCategory(int id, [FromBody] Category updatedCategeory)
    {
        //if (id != updatedCategeory.Id)
        //{
        //    return BadRequest("Category ID mismatch");
        //}

        var categeory = await _context.Categories
                                        .Include(c => c.Products) // Include products
                                        .SingleOrDefaultAsync(c => c.Id == id);
        if (categeory == null)
        {
            return NotFound();
        }

        // Update the category's properties with the new values

        categeory.Name = updatedCategeory.Name;
        categeory.Description = updatedCategeory.Description;
        // ... (update other properties as needed) ...

        _context.Entry(categeory).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
            return Ok(categeory);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Categories.Any(c => c.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        // return NoContent();
    }
}



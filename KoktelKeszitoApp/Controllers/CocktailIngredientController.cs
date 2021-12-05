using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoktelKeszitoApp.Models;

namespace KoktelKeszitoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CocktailIngredientController : ControllerBase
    {
        private readonly CocktailContextDb _context;

        public CocktailIngredientController(CocktailContextDb context)
        {
            _context = context;
        }

        // GET: api/CocktailIngredient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CocktailIngredient>>> GetCocktailIngredients()
        {
            return await _context.CocktailIngredients.ToListAsync();
        }

        // GET: api/CocktailIngredient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CocktailIngredient>> GetCocktailIngredient(int id)
        {
            var cocktailIngredient = await _context.CocktailIngredients.FindAsync(id);

            if (cocktailIngredient == null)
            {
                return NotFound();
            }

            return cocktailIngredient;
        }

        // PUT: api/CocktailIngredient/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCocktailIngredient(int id, CocktailIngredient cocktailIngredient)
        {
            if (id != cocktailIngredient.Id)
            {
                return BadRequest();
            }

            _context.Entry(cocktailIngredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CocktailIngredientExists(id))
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

        // POST: api/CocktailIngredient
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CocktailIngredient>> PostCocktailIngredient(CocktailIngredient cocktailIngredient)
        {
            _context.CocktailIngredients.Add(cocktailIngredient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCocktailIngredient", new { id = cocktailIngredient.Id }, cocktailIngredient);
        }

        // DELETE: api/CocktailIngredient/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCocktailIngredient(int id)
        {
            var cocktailIngredient = await _context.CocktailIngredients.FindAsync(id);
            if (cocktailIngredient == null)
            {
                return NotFound();
            }

            _context.CocktailIngredients.Remove(cocktailIngredient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CocktailIngredientExists(int id)
        {
            return _context.CocktailIngredients.Any(e => e.Id == id);
        }
    }
}

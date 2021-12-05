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
    public class CocktailController : ControllerBase
    {
        private readonly CocktailContextDb _context;

        public CocktailController(CocktailContextDb context)
        {
            _context = context;
        }

        // GET: api/Cocktails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cocktail>>> GetCocktails()
        {
            return await _context.Cocktails.ToListAsync();
        }

        // GET: api/Cocktails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cocktail>> GetCocktail(int id)
        {
            var cocktail = await _context.Cocktails.FindAsync(id);

            if (cocktail == null)
            {
                return NotFound();
            }

            return cocktail;
        }

        // PUT: api/Cocktails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCocktail(int id, Cocktail cocktail)
        {
            if (id != cocktail.CocktailId)
            {
                return BadRequest();
            }

            _context.Entry(cocktail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CocktailExists(id))
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

        // POST: api/Cocktails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cocktail>> PostCocktail(Cocktail cocktail)
        {
            _context.Cocktails.Add(cocktail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCocktail", new { id = cocktail.CocktailId }, cocktail);
        }

        // DELETE: api/Cocktails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCocktail(int id)
        {
            var cocktail = await _context.Cocktails.FindAsync(id);
            if (cocktail == null)
            {
                return NotFound();
            }

            _context.Cocktails.Remove(cocktail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CocktailExists(int id)
        {
            return _context.Cocktails.Any(e => e.CocktailId == id);
        }
    }
}

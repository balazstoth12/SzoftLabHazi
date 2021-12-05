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
    public class UserCocktailController : ControllerBase
    {
        private readonly CocktailContextDb _context;

        public UserCocktailController(CocktailContextDb context)
        {
            _context = context;
        }

        // GET: api/UserCocktail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCocktail>>> GetUserCocktails()
        {
            return await _context.UserCocktails.ToListAsync();
        }

        // GET: api/UserCocktail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCocktail>> GetUserCocktail(int id)
        {
            var userCocktail = await _context.UserCocktails.FindAsync(id);

            if (userCocktail == null)
            {
                return NotFound();
            }

            return userCocktail;
        }

        // PUT: api/UserCocktail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCocktail(int id, UserCocktail userCocktail)
        {
            if (id != userCocktail.Id)
            {
                return BadRequest();
            }

            _context.Entry(userCocktail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCocktailExists(id))
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

        // POST: api/UserCocktail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserCocktail>> PostUserCocktail(UserCocktail userCocktail)
        {
            _context.UserCocktails.Add(userCocktail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserCocktail", new { id = userCocktail.Id }, userCocktail);
        }

        // DELETE: api/UserCocktail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCocktail(int id)
        {
            var userCocktail = await _context.UserCocktails.FindAsync(id);
            if (userCocktail == null)
            {
                return NotFound();
            }

            _context.UserCocktails.Remove(userCocktail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserCocktailExists(int id)
        {
            return _context.UserCocktails.Any(e => e.Id == id);
        }
    }
}

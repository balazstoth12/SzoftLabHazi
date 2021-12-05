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
    public class FavouriteUserController : ControllerBase
    {
        private readonly CocktailContextDb _context;

        public FavouriteUserController(CocktailContextDb context)
        {
            _context = context;
        }

        // GET: api/FavouriteUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavouriteUser>>> GetFavouriteUser()
        {
            return await _context.FavouriteUser.ToListAsync();
        }

        // GET: api/FavouriteUser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavouriteUser>> GetFavouriteUser(int id)
        {
            var favouriteUser = await _context.FavouriteUser.FindAsync(id);

            if (favouriteUser == null)
            {
                return NotFound();
            }

            return favouriteUser;
        }

        // PUT: api/FavouriteUser/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavouriteUser(int id, FavouriteUser favouriteUser)
        {
            if (id != favouriteUser.FavouriteUserId)
            {
                return BadRequest();
            }

            _context.Entry(favouriteUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavouriteUserExists(id))
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

        // POST: api/FavouriteUser
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FavouriteUser>> PostFavouriteUser(FavouriteUser favouriteUser)
        {
            _context.FavouriteUser.Add(favouriteUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavouriteUser", new { id = favouriteUser.FavouriteUserId }, favouriteUser);
        }

        // DELETE: api/FavouriteUser/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavouriteUser(int id)
        {
            var favouriteUser = await _context.FavouriteUser.FindAsync(id);
            if (favouriteUser == null)
            {
                return NotFound();
            }

            _context.FavouriteUser.Remove(favouriteUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavouriteUserExists(int id)
        {
            return _context.FavouriteUser.Any(e => e.FavouriteUserId == id);
        }
    }
}

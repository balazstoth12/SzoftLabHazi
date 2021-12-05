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
    public class UserFavouriteUserController : ControllerBase
    {
        private readonly CocktailContextDb _context;

        public UserFavouriteUserController(CocktailContextDb context)
        {
            _context = context;
        }

        // GET: api/UserFavouriteUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserFavouriteUser>>> GetUserFavouriteUsers()
        {
            return await _context.UserFavouriteUsers.ToListAsync();
        }

        // GET: api/UserFavouriteUser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserFavouriteUser>> GetUserFavouriteUser(int id)
        {
            var userFavouriteUser = await _context.UserFavouriteUsers.FindAsync(id);

            if (userFavouriteUser == null)
            {
                return NotFound();
            }

            return userFavouriteUser;
        }

        // PUT: api/UserFavouriteUser/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserFavouriteUser(int id, UserFavouriteUser userFavouriteUser)
        {
            if (id != userFavouriteUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(userFavouriteUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserFavouriteUserExists(id))
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

        // POST: api/UserFavouriteUser
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserFavouriteUser>> PostUserFavouriteUser(UserFavouriteUser userFavouriteUser)
        {
            _context.UserFavouriteUsers.Add(userFavouriteUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserFavouriteUser", new { id = userFavouriteUser.Id }, userFavouriteUser);
        }

        // DELETE: api/UserFavouriteUser/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserFavouriteUser(int id)
        {
            var userFavouriteUser = await _context.UserFavouriteUsers.FindAsync(id);
            if (userFavouriteUser == null)
            {
                return NotFound();
            }

            _context.UserFavouriteUsers.Remove(userFavouriteUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserFavouriteUserExists(int id)
        {
            return _context.UserFavouriteUsers.Any(e => e.Id == id);
        }
    }
}

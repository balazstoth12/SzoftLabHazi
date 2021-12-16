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
    public class UserController : ControllerBase
    {
        private readonly CocktailContextDb _context;

        public UserController(CocktailContextDb context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}/GetUserFavUsers")]
        public async Task<ActionResult<IEnumerable<FavouriteUser>>> GetUserFavUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            List<UserFavouriteUser> userfavuser = new List<UserFavouriteUser>();
            List<FavouriteUser> favuserList = new List<FavouriteUser>();

            foreach (var item in _context.UserFavouriteUsers)
            {
                if (item.UserId==user.UserId)
                {
                    userfavuser.Add(item);
                }
            }

            foreach (var item2 in userfavuser)
            {
                var favouriteUser = await _context.FavouriteUser.FindAsync(item2.FavouriteUserId);
                if (favouriteUser == null)
                {
                    return NotFound();

                }
                if (item2.FavouriteUserId == favouriteUser.FavouriteUserId)
                {
                    favuserList.Add(item2.FavouriteUser);
                }

            }

                return favuserList;
        }
        [HttpGet("{id}/GetUserWhoFavouriteUs")]
        public async Task<ActionResult<IEnumerable<FavouriteUser>>> GetUserWhoFavouriteUs(int id)
        {
            var user = await _context.Users.FindAsync(id);

            List<UserFavouriteUser> userfavuser = new List<UserFavouriteUser>();
            List<FavouriteUser> favuserList = new List<FavouriteUser>();

            foreach (var item in _context.UserFavouriteUsers)
            {
                if (item.UserId != user.UserId && item.FavouriteUserId==user.UserId)
                {
                    userfavuser.Add(item);
                }
            }

            foreach (var item2 in userfavuser)
            {
                var favouriteUser = await _context.FavouriteUser.FindAsync(item2.FavouriteUserId);
                if (favouriteUser == null)
                {
                    return NotFound();

                }
                if (item2.FavouriteUserId == favouriteUser.FavouriteUserId)
                {
                    favuserList.Add(item2.FavouriteUser);
                }
            }
            return favuserList;
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        [HttpPost("{uId}/{fId}/UserFavouriteUser")]
        public async Task<ActionResult<Cocktail>> AddUserIdAndFavouriteUserId(int uId, int fId)
        {
            UserFavouriteUser userFavouriteUser = new UserFavouriteUser();
            var user = await _context.Users.FindAsync(uId);
            var favouriteUser = await _context.FavouriteUser.FindAsync(fId);

            if (user == null || favouriteUser == null)
            {
                return NotFound();
            }
            foreach (var item in _context.UserFavouriteUsers)
            {
                if (item.UserId == uId && item.FavouriteUserId == fId)
                {
                    return NoContent();
                }
            }
            userFavouriteUser.UserId = uId;
            userFavouriteUser.FavouriteUserId = fId;


            _context.UserFavouriteUsers.Add(userFavouriteUser);
            await _context.SaveChangesAsync();
            return NoContent();

        }
        [HttpGet("{id}/UserFavouriteUser")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserFavouriteUser(int id)
        {
            var favouriteUser = await _context.FavouriteUser.FindAsync(id);


            if (favouriteUser == null)
            {
                return NotFound();
            }
            List<UserFavouriteUser> userfavuserlist = new List<UserFavouriteUser>();
            List<User> userList = new List<User>();
            foreach (var _ in _context.UserFavouriteUsers)
            {
                if (_.FavouriteUserId == favouriteUser.FavouriteUserId)
                {
                    userfavuserlist.Add(_);
                }
            }
            foreach (var item in userfavuserlist)
            {
                var user = await _context.Users.FindAsync(item.UserId);
                if (user == null)
                {
                    return NotFound();

                }
                if (item.UserId == user.UserId)
                {
                    userList.Add(item.User);
                }

            }

            return userList;
        }
        [HttpGet("{id}/GetUserCocktails")]
        public async Task<ActionResult<IEnumerable<Cocktail>>> GetUserCocktails(int id)
        {
            var user = await _context.Users.FindAsync(id);


            if (user == null)
            {
                return NotFound();
            }
            List<UserCocktail> userCocktail = new List<UserCocktail>();
            List<Cocktail> CocktailList = new List<Cocktail>();
            foreach (var _ in _context.UserCocktails)
            {
                if (_.UserId == user.UserId)
                {
                    userCocktail.Add(_);
                }
            }
            foreach (var item in userCocktail)
            {
                var cocktail = await _context.Cocktails.FindAsync(item.CocktailId);
                if (cocktail == null)
                {
                    return NotFound();

                }
                if (item.CocktailId == cocktail.CocktailId)
                {
                    CocktailList.Add(item.Cocktail);
                }

            }

            return CocktailList;
        }
        [HttpDelete("{usid}/{fid}/userFavouriteUser")]
        public async Task<IActionResult> DeleteUserFavouriteUser(int usid, int fid)
        {
            var user = await _context.Users.FindAsync(usid);
            var favouriteUser = await _context.FavouriteUser.FindAsync(fid);

            if (user == null || favouriteUser==null)
            {
                return NotFound();
            }
            foreach (var item in _context.UserFavouriteUsers)
            {
                if (item.UserId==user.UserId && item.FavouriteUserId==favouriteUser.FavouriteUserId)
                {
                    _context.UserFavouriteUsers.Remove(item);
                    break;
                    
                }
            }
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpGet("{Username}/{Password}")]
        public async Task<ActionResult<User>> LoginCheck(string Username, string Password)
        {

            if (Username == null || Password == null)
            {
                return NotFound();
            }


            foreach (var item in _context.Users)
            {
                if (item.Username==Username && item.Password==Password)

                {
                    return item;
                }
            }

            return NotFound();
        }

    }
}

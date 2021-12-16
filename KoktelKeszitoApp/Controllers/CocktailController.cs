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

        [HttpPost("PostCocktailWithIngredients")]
        public async Task<ActionResult<Cocktail>> PostCocktailWithIngredients(HelpClassForCocktailController cocktailAndIngredients)
        {
            _context.Cocktails.Add(cocktailAndIngredients.cocktail);
            await _context.SaveChangesAsync();


            foreach (var item in cocktailAndIngredients.ingredients)
            {
                CocktailIngredient cocktailIngredient = new CocktailIngredient();
                cocktailIngredient.CocktailId = cocktailAndIngredients.cocktail.CocktailId;
                cocktailIngredient.IngredientsId = item.Id;

                _context.CocktailIngredients.Add(cocktailIngredient);
            }
            await _context.SaveChangesAsync();


            return Ok();
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

        [HttpPost("{uId}/{cId}/UserCocktail")]
        public async Task<ActionResult<Cocktail>> AddUserIdAndCocktailId(int uId, int cId)
        {
            UserCocktail usercocktail = new UserCocktail();
            var user = await _context.Users.FindAsync(uId);
            var cocktail = await _context.Cocktails.FindAsync(cId);

            if (user == null || cocktail == null)
            {
                return NotFound();
            }
            foreach (var item in _context.UserCocktails)
            {
                if (item.UserId == uId && item.CocktailId == cId)
                {
                    return NoContent();
                }
            }
            usercocktail.UserId = uId;
            usercocktail.CocktailId = cId;


            _context.UserCocktails.Add(usercocktail);
            await _context.SaveChangesAsync();
            return NoContent();

        }


        // GET: api/Cocktail/3
        [HttpGet("{id}/UserCocktail")]
        public async Task<ActionResult<IEnumerable<Cocktail>>> GetUserCocktails(int id)
        {
            var user = await _context.Users.FindAsync(id);


            if (user == null)
            {
                return NotFound();
            }
            List<UserCocktail> userList = new List<UserCocktail>();
            List<Cocktail> cocktailList = new List<Cocktail>();
            foreach (var _ in _context.UserCocktails)
            {
                if (_.UserId == user.UserId)
                {
                    userList.Add(_);
                }
            }
            foreach (var item in userList)
            {
                var cocktail = await _context.Cocktails.FindAsync(item.CocktailId);
                if (cocktail == null)
                {
                    return NotFound();

                }
                if (item.CocktailId == cocktail.CocktailId)
                {
                    cocktailList.Add(item.Cocktail);
                }

            }

            return cocktailList;
        }

        [HttpPost("{coId}/{IId}/CocktailIngredient")]
        public async Task<ActionResult<Cocktail>> AddCocktailIdAndIngredientId(int coId, int IId)
        {
            CocktailIngredient cocktailIngredient = new CocktailIngredient();
            var cocktail = await _context.Cocktails.FindAsync(coId);
            var ingredient = await _context.Ingredients.FindAsync(IId);

            if (cocktail == null || ingredient == null)
            {
                return NotFound();
            }
            foreach (var item in _context.CocktailIngredients)
            {
                if (item.CocktailId == coId && item.IngredientsId == IId)
                {
                    return NoContent();
                }
            }
            cocktailIngredient.CocktailId = coId;
            cocktailIngredient.IngredientsId = IId;


            _context.CocktailIngredients.Add(cocktailIngredient);
            await _context.SaveChangesAsync();
            return NoContent();

        }
        // GET: api/Cocktail/2
        [HttpGet("{id}/CocktailIngredient")]
        public async Task<ActionResult<IEnumerable<Cocktail>>> GetCocktailIngredient(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);


            if (ingredient == null)
            {
                return NotFound();
            }
            List<CocktailIngredient> ingredientList = new List<CocktailIngredient>();

            List<Cocktail> cocktailList = new List<Cocktail>();

            foreach (var _ in _context.CocktailIngredients)
            {
                if (_.IngredientsId == ingredient.Id)
                {
                    ingredientList.Add(_);
                }
            }
            foreach (var item in ingredientList)
            {
                var cocktail = await _context.Cocktails.FindAsync(item.CocktailId);
                if (cocktail == null)
                {
                    return NotFound();

                }
                if (item.CocktailId == cocktail.CocktailId)
                {
                    cocktailList.Add(item.Cocktail);
                }

            }

            return cocktailList;
        }
    }
}


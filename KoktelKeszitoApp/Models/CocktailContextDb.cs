using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoktelKeszitoApp.Models;

namespace KoktelKeszitoApp.Models
{
    public class CocktailContextDb:DbContext
    {
        public CocktailContextDb(DbContextOptions<CocktailContextDb>options):base(options)
        {

        }
        public DbSet<Cocktail> Cocktails { get; set; }
        public DbSet<CocktailIngredient> CocktailIngredients { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCocktail> UserCocktails { get; set; }
        public DbSet<UserFavouriteUser> UserFavouriteUsers { get; set; }
        public DbSet<FavouriteUser> FavouriteUser { get; set; }

    }
}

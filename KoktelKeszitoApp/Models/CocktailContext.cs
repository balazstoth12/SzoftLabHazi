using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoktelKeszitoApp.Models
{
    public class CocktailContext:DbContext
    {
        public CocktailContext(DbContextOptions<CocktailContext>options):base(options)
        {

        }
        public DbSet<Cocktail> Cocktails { get; set; }
    }
}

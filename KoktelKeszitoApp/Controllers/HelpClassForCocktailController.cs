using KoktelKeszitoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoktelKeszitoApp.Controllers
{
    public class HelpClassForCocktailController
    {
        public Cocktail cocktail { get; set; }
        public List<Ingredient> ingredients { get; set; }
    }
}

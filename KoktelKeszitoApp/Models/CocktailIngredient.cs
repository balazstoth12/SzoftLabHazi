using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KoktelKeszitoApp.Models
{
    public class CocktailIngredient
    {
        [Key]
        public int Id { get; set; }
        public int CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }
        public int IngredientsId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}

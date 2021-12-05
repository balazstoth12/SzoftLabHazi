using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KoktelKeszitoApp.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }

        [InverseProperty(nameof(CocktailIngredient.Ingredient))] // A navigáció másik oldalát jelezzük vele
        public ICollection<CocktailIngredient> CocktailIngredients { get; set; }
    }
}

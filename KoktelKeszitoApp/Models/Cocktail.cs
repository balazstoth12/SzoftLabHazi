using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KoktelKeszitoApp.Models
{
    public class Cocktail
    {
        [Key]
        public int CocktailId { get; set; }

        [Column (TypeName ="nvarchar(50)")]
        public string CocktailName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public User  MadeBy { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string MadeDate { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; }
       
        [InverseProperty(nameof(UserCocktail.Cocktail))] // A navigáció másik oldalát jelezzük vele
        public ICollection<UserCocktail> UserCocktails { get; set; }

        [InverseProperty(nameof(CocktailIngredient.Cocktail))] // A navigáció másik oldalát jelezzük vele
        public ICollection<CocktailIngredient> CocktailIngredients { get; set; }
        


    }
}

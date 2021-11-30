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

        [Required]
        [Column (TypeName ="nvarchar(100)")]
        public string CocktailName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string  MadeBy { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string MadeDate { get; set; }


        [Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; }
        [Required]
        public int Ingredients { get; set; }
    }
}

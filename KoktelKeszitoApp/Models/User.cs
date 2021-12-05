using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KoktelKeszitoApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string password  { get; set; }


        [InverseProperty(nameof(UserCocktail.User))] // A navigáció másik oldalát jelezzük vele
        public ICollection<UserCocktail> UserCocktails { get; set; }

        [InverseProperty(nameof(UserFavouriteUser.User))] // A navigáció másik oldalát jelezzük vele
        public ICollection<UserFavouriteUser> UserFavouriteUsers { get; set; }
    }
}

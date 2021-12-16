using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KoktelKeszitoApp.Models
{
    public class FavouriteUser
    {
        [Key]
        public int FavouriteUserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        [InverseProperty(nameof(UserFavouriteUser.FavouriteUser))] // A navigáció másik oldalát jelezzük vele
        public ICollection<UserFavouriteUser> UserFavouriteUsers { get; set; }
    }
}

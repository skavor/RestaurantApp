using Microsoft.AspNetCore.Identity;
using RestaurantApp.API.Data.DataAccess.Interfaces;

namespace RestaurantApp.API.Data.Entities
{
    public class User : IdentityUser, IRestaurantAppEntity<string>
    {

        public bool? IsEnabled { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    
}

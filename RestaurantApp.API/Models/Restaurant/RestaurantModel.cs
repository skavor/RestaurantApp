using RestaurantApp.API.Data.Entities;
using RestaurantApp.API.Response;

namespace RestaurantApp.API.Models.Restaurant
{
    public class RestaurantModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public UserResponse? Responsable { get; set; }
        public  Address? Address { get; set; }
    }
}

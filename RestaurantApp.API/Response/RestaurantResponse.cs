using RestaurantApp.API.Data.Entities;

namespace RestaurantApp.API.Response
{
    public class RestaurantResponse
    {
        public UserResponse? Responsable { get; set; }
        public Address? Address { get; set; }

        public string? Name { get; set; }
        public Guid Id { get; set; }
    }
}

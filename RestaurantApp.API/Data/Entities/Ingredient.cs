using RestaurantApp.API.Data.DataAccess.Interfaces;

namespace RestaurantApp.API.Data.Entities
{
    public class Ingredient : IRestaurantAppEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? Element { get; set; }
    }
}

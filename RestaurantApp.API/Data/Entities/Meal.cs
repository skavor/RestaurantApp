using RestaurantApp.API.Data.DataAccess.Interfaces;

namespace RestaurantApp.API.Data.Entities
{
    public class Meal : IRestaurantAppEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public int Quantity { get; set; }
        public string? Image { get; set; }

        public virtual Restaurant? Restaurant { get; set; }

        public virtual List<Ingredient>? Ingredients { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

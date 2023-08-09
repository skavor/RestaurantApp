using RestaurantApp.API.Data.Entities;

namespace RestaurantApp.API.Response
{
    public class MealDetailResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public int Quantity { get; set; }
        public string? Image { get; set; }

        public List<Ingredient>? Ingredients { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

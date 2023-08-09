using RestaurantApp.API.Data.Entities;

namespace RestaurantApp.API.Models.Meals
{
    public class MealModel
    {
       
        public string? Name { get; set; }
        public string? Category { get; set; }
        public int Quantity { get; set; }
        public string? Image { get; set; }

        public List<Ingredient>? Ingredients { get; set; }

    }
}

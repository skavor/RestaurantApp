using MediatR;
using RestaurantApp.API.Data.Entities;
using RestaurantApp.API.Models.Meals;

namespace RestaurantApp.API.Commands
{
    public class AddMealToRestaurantCommand : IRequest<Meal>
    {
        public Guid RestaurantIdFromRoute   { get; set; }
        
        public string? Name { get; set; }
        public string? Category { get; set; }
        public int Quantity { get; set; }
        public string? Image { get; set; }

        public  List<Ingredient>? Ingredients { get; set; }

        public Restaurant? Restaurant { get; set; }

        
        public AddMealToRestaurantCommand(MealModel mealModel, Guid RestaurantId)
        {
            Name = mealModel.Name;
            Category = mealModel.Category;
            Quantity = mealModel.Quantity;
            Image = mealModel.Image;
            Ingredients = mealModel.Ingredients;
            Ingredients = mealModel.Ingredients;
            RestaurantIdFromRoute = RestaurantId;    
        }
    }
}

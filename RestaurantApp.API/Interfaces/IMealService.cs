using RestaurantApp.API.Data.Entities;
using RestaurantApp.API.Response;

namespace RestaurantApp.API.Interfaces
{
    public interface IMealService
    {
        Task<Meal> AddMealAsync(Meal meal);

        Task<List<MealListResponse>> GetMealsByRestaurantsAsync(Guid RestaurantId);
        Task<List<string>> GetCategories();

        Task<List<string>> GetIngredients();

        Task<MealDetailResponse> GetMealByIdAsync(Guid MealId);
    }
}

using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using RestaurantApp.API.Data.DataAccess;
using RestaurantApp.API.Data.Entities;
using RestaurantApp.API.Interfaces;
using RestaurantApp.API.Response;
using RestSharp;
using System.Text.Json;

namespace RestaurantApp.API.Services
{
    
    public class MealService : IMealService
    {

        private AppDbContext _dbContext;

        public MealService(AppDbContext dbContext)
        {

            _dbContext = dbContext;
        }

        //Add meal service
        public async Task<Meal> AddMealAsync(Meal meal)
        {
            var result = _dbContext.Meals.Add(meal);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        //Get meals by restaurant Id service
        public async Task<List<MealListResponse>> GetMealsByRestaurantsAsync(Guid RestaurantId)
        {
            List<MealListResponse> result = new List<MealListResponse>();
            var data = await _dbContext.Meals.Where(meal => meal.Restaurant.Id == RestaurantId).ToArrayAsync();
            foreach (var meal in data)
            {
                MealListResponse mealListResponse = new MealListResponse()
                {
                    Image = meal.Image,
                    Name = meal.Name
                };
               
                result.Add(mealListResponse);

            }
            return result;
        }


        //Get meal by Id service
        public async Task<MealDetailResponse> GetMealByIdAsync(Guid MealId)
        {
            
            var data = await _dbContext.Meals.Where(meal => meal.Id == MealId).FirstOrDefaultAsync();

            MealDetailResponse mealDetailResponse = new MealDetailResponse()
            {
                Id = data.Id,
                Name = data.Name,
                Category = data.Category,
                Quantity = data.Quantity,
                Image = data.Image,
                Ingredients = data.Ingredients,
                CreatedAt = data.CreatedAt,
                UpdatedAt = data.UpdatedAt,
            };
             return mealDetailResponse;
        }

        // Get categories list service from external API
        public async Task<List<string>> GetCategories()
        {
            List<string> result = new List<string>();
            var client = new RestClient($"https://www.themealdb.com/api/json/v1/1/list.php?c=list");
            RestResponse response = await client.ExecuteAsync(new RestRequest());
            
            // Convert JSON string to JObject
            JObject JsonObject = JObject.Parse(response.Content);
            JArray MealsArray = JsonObject["meals"] as JArray;
            foreach (JToken meal in MealsArray)
            {
                string category = meal["strCategory"]?.ToString();
                result.Add(category);
            }
            return result;
        }


        // Get ingredients list service from external API
        public async Task<List<string>> GetIngredients()
        {
            List<string> result = new List<string>();
            var client = new RestClient($"https://www.themealdb.com/api/json/v1/1/list.php?i=list");
            RestResponse response = await client.ExecuteAsync(new RestRequest());

            // Convert JSON string to JObject
            JObject JsonObject = JObject.Parse(response.Content);
            JArray MealsArray = JsonObject["meals"] as JArray;
            foreach (JToken meal in MealsArray)
            {
                string ingredient = meal["strIngredient"]?.ToString();
                result.Add(ingredient);
            }
            
            return result;
        }
    }
}

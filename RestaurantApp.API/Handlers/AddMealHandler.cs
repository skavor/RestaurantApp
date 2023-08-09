using MediatR;
using RestaurantApp.API.Commands;
using RestaurantApp.API.Data.Entities;
using RestaurantApp.API.Interfaces;

namespace RestaurantApp.API.Handlers
{
    
    public class AddMealHandler : IRequestHandler<AddMealToRestaurantCommand, Meal>
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IMealService _mealService;

        public AddMealHandler(
            IRestaurantService restaurantService,
            IMealService mealService
            )
        {
            _restaurantService = restaurantService;
            _mealService = mealService;
        }
        public async Task<Meal> Handle(AddMealToRestaurantCommand command, CancellationToken cancellationToken)
        {
            
            var Restaurant = await _restaurantService.GetRestaurantByIdAsync(command.RestaurantIdFromRoute);            
            var mealToAdd = new Meal()
            {
                Quantity = command.Quantity,
                Category = command.Category,
                Image = command.Image,
                CreatedAt = DateTime.Now,
                Ingredients = command.Ingredients,
                Name = command.Name,
                Id = new Guid(),
                UpdatedAt = DateTime.Now,
                Restaurant = Restaurant
            };

            return await _mealService.AddMealAsync(mealToAdd);
        }
    }
}

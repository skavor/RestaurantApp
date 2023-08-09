using MediatR;
using RestaurantApp.API.Interfaces;
using RestaurantApp.API.Queries;
using RestaurantApp.API.Response;

namespace RestaurantApp.API.Handlers
{
    public class GetMealsListHandler : IRequestHandler<GetMealsListByRestaurantQuery, List<MealListResponse>>
    {
        private readonly IMealService _mealRepository;

        public GetMealsListHandler(IMealService mealRepository)
        {
            _mealRepository = mealRepository;
        }

        public async Task<List<MealListResponse>> Handle(GetMealsListByRestaurantQuery query, CancellationToken cancellationToken)
        {
            return await _mealRepository.GetMealsByRestaurantsAsync(query.RestaurantId);
        }
    }
}

using MediatR;
using RestaurantApp.API.Data.Entities;
using RestaurantApp.API.Interfaces;
using RestaurantApp.API.Queries;
using RestaurantApp.API.Response;

namespace RestaurantApp.API.Handlers
{
    public class GetMealByIdHandler : IRequestHandler<GetMealByIdQuery, MealDetailResponse>
    {
        private readonly IMealService _mealRepository;

        public GetMealByIdHandler(IMealService mealRepository)
        {
            _mealRepository = mealRepository;
        }

        public async Task<MealDetailResponse> Handle(GetMealByIdQuery query, CancellationToken cancellationToken)
        {
            return await _mealRepository.GetMealByIdAsync(query.MealId);
        }
    }
}

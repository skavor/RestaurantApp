using MediatR;
using RestaurantApp.API.Interfaces;
using RestaurantApp.API.Queries;

namespace RestaurantApp.API.Handlers
{
  
    public class GetIngredientsListHandler : IRequestHandler<GetIngredientsListQuery, List<string>>
    {
        private readonly IMealService _mealService;
        public GetIngredientsListHandler(IMealService mealService)
        {
            _mealService = mealService;
        }

        public async Task<List<string>> Handle(GetIngredientsListQuery query, CancellationToken cancellationToken)
        {
            return await _mealService.GetIngredients();
        }
    }
}

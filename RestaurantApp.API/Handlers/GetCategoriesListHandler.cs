using MediatR;
using RestaurantApp.API.Interfaces;
using RestaurantApp.API.Queries;

namespace RestaurantApp.API.Handlers
{
    public class GetCategoriesListHandler : IRequestHandler<GetCategoriesListQuery, List<string>>
    {
        private readonly IMealService _mealService;
        public GetCategoriesListHandler(IMealService mealService)
        {
            _mealService = mealService;
        }

        public async Task<List<string>> Handle(GetCategoriesListQuery query, CancellationToken cancellationToken)
        {
            return await _mealService.GetCategories();
        }
    }

   
}

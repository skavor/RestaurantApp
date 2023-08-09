using MediatR;
using RestaurantApp.API.Data.Entities;
using RestaurantApp.API.Interfaces;
using RestaurantApp.API.Queries;
using RestaurantApp.API.Response;

namespace RestaurantApp.API.Handlers
{
    public class GetRestaurantListHandler : IRequestHandler<GetRestaurantListQuery, List<RestaurantResponse>>
    {
        private readonly IRestaurantService _restaurantRepository;

        public GetRestaurantListHandler(IRestaurantService restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<List<RestaurantResponse>> Handle(GetRestaurantListQuery query, CancellationToken cancellationToken)
        {
            return await _restaurantRepository.GetRestaurantListAsync();
        }
    }

    
}

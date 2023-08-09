using MediatR;
using RestaurantApp.API.Data.Entities;
using RestaurantApp.API.Response;

namespace RestaurantApp.API.Queries
{
    public class GetRestaurantListQuery : IRequest<List<RestaurantResponse>>
    {
    }
}

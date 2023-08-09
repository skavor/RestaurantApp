using MediatR;
using RestaurantApp.API.Data.Entities;

namespace RestaurantApp.API.Queries
{
    public class GetRestaurantByIdQuery : IRequest<Restaurant>
    {
        public int Id { get; set; }
    }
}

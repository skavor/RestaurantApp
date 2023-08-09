using RestaurantApp.API.Data.Entities;
using RestaurantApp.API.Response;

namespace RestaurantApp.API.Interfaces
{
    public interface IRestaurantService
    {

        Task<List<RestaurantResponse>> GetRestaurantListAsync();
        Task<Restaurant> AddRestaurantAsync(Restaurant restaurant);

        Task<Restaurant> GetRestaurantByIdAsync(Guid Id);
    }
}

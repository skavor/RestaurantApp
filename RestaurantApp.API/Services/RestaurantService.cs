using Microsoft.EntityFrameworkCore;
using RestaurantApp.API.Data.DataAccess;
using RestaurantApp.API.Data.Entities;
using RestaurantApp.API.Interfaces;
using RestaurantApp.API.Response;

namespace RestaurantApp.API.Services
{
    public class RestaurantService : IRestaurantService
    {
       
        private AppDbContext _dbContext;


        public RestaurantService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Add restaurant service
        public async Task<Restaurant> AddRestaurantAsync(Restaurant restaurant)
        {
            var result = _dbContext.Restaurants.Add(restaurant);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        
        //Get Restaurant list service 
        public async Task<List<RestaurantResponse>> GetRestaurantListAsync()
        {
            List<RestaurantResponse> result = new List<RestaurantResponse>();
            var data = await _dbContext.Restaurants.ToListAsync();
            foreach(var restaurant in data)
            {
                UserResponse userResponse = new UserResponse()
                {
                    Lastname = restaurant?.Responsable?.Lastname,
                    Email = restaurant?.Responsable?.Email,
                    Firstname = restaurant?.Responsable?.Firstname,
                    PhoneNumber = restaurant?.Responsable?.PhoneNumber
                };
                RestaurantResponse restaurantResponse = new RestaurantResponse()
                {
                    Address = restaurant!.Address,
                    Id = restaurant.Id,
                    Name = restaurant?.Name,
                    Responsable = userResponse
                };
                result.Add(restaurantResponse);

            }
            return result;
        }

        //Get restaurant by Id service
        public async Task<Restaurant> GetRestaurantByIdAsync(Guid Id)
        {
            return await _dbContext.Restaurants.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

    }
}

using RestaurantApp.API.Data.Entities;
using RestaurantApp.API.Response;

namespace RestaurantApp.API.Interfaces
{
    public interface IUserService
    {
        
        UserResponse GetUserData(User user);
    }
}

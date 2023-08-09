
using RestaurantApp.API.Data.Entities;
using RestaurantApp.API.Interfaces;
using RestaurantApp.API.Models.Restaurant;
using RestaurantApp.API.Response;

namespace RestaurantApp.API.Services
{
    public class UserService : IUserService
    {
        
        //Formatting user data for a specific response
        public UserResponse GetUserData(User user)
        {

            UserResponse userResponse = new UserResponse()
            {
                Email = user.Email,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                PhoneNumber = user.PhoneNumber
            };

            return userResponse;
        }

    }
}

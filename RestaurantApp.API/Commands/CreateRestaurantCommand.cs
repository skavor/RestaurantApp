using MediatR;
using RestaurantApp.API.Data.Entities;
using RestaurantApp.API.Models.Restaurant;
using RestaurantApp.API.Response;

namespace RestaurantApp.API.Commands
{
    public class CreateRestaurantCommand : IRequest<Restaurant>
    {
        public string? Name { get; set; }
        public UserResponse? Responsable { get; set; }
        public Address? Address { get; set; }
        public CreateRestaurantCommand(RestaurantModel restaurantModel)
        {
            Name = restaurantModel.Name;
            Responsable = restaurantModel.Responsable;
            Address = restaurantModel.Address;

        }
    }
}

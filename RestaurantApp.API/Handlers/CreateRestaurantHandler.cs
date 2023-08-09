using MediatR;
using RestaurantApp.API.Commands;
using RestaurantApp.API.Data.Entities;
using RestaurantApp.API.Interfaces;

namespace RestaurantApp.API.Handlers
{
    public class CreateRestaurantHandler : IRequestHandler<CreateRestaurantCommand, Restaurant>
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IAddressService _addressService;

        public CreateRestaurantHandler(
            IRestaurantService restaurantService,
            IAddressService addressService
            )
        {
            _restaurantService = restaurantService;
            _addressService = addressService;
        }

        public async Task<Restaurant> Handle(CreateRestaurantCommand command, CancellationToken cancellationToken)
        {
            var newAddress = new Address()
            {
                City = command!.Address!.City,
                Street = command!.Address!.Street,
                CodePostal = command!.Address!.CodePostal,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            var address = await _addressService.AddAddressAsync(newAddress);
            var user = new User()
            {
                Firstname = command?.Responsable?.Firstname,
                Lastname= command?.Responsable?.Lastname,
                PhoneNumber = command?.Responsable?.PhoneNumber,
                Email = command?.Responsable?.Email,
            };
            var restaurantToCreate = new Restaurant()
            {
                Address = address,
                Name = command?.Name,
                Responsable = user
            };

            return await _restaurantService.AddRestaurantAsync(restaurantToCreate);
        }
    }
   
}

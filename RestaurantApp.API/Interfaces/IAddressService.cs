using RestaurantApp.API.Data.Entities;

namespace RestaurantApp.API.Interfaces
{
    public interface IAddressService
    {
        Task<Address> AddAddressAsync(Address address);

        Task<List<Address>> GetAddressListAsync();
    }
}

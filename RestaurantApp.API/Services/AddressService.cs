using Microsoft.EntityFrameworkCore;
using RestaurantApp.API.Data.DataAccess;

using RestaurantApp.API.Data.Entities;
using RestaurantApp.API.Interfaces;

namespace RestaurantApp.API.Services
{
    public class AddressService: IAddressService
    {
        
        private AppDbContext _dbContext;

        public AddressService( AppDbContext dbContext)
        {
            
            _dbContext = dbContext;
        }

        //Add address service
        public async Task<Address> AddAddressAsync(Address address)
        {
            var result = _dbContext.Address.Add(address);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        //Get address list service
        public async Task<List<Address>> GetAddressListAsync()
        {
            return await _dbContext.Address.ToListAsync();
        }
    }
}

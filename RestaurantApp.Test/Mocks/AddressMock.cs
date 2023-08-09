using Moq;
using RestaurantApp.API.Data.Entities;
using RestaurantApp.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Test.Mocks
{
    internal class AddressMock
    {
        //Mock get address list
        public static Mock<IAddressService> GetAddressList()
        {
           
            var mockAddressService = new Mock<IAddressService>();
            mockAddressService.Setup(_repository => _repository.GetAddressListAsync()).ReturnsAsync(new List<Address>());
            return mockAddressService;
        }
    }
}

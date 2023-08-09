using Moq;
using RestaurantApp.API.Data.Entities;
using RestaurantApp.API.Interfaces;
using RestaurantApp.API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Test.Mocks
{
    internal static class RestaurantMock
    {

        //Mock to get restaurant list

        public static Mock<IRestaurantService> GetRestaurantList()
        {
           

            var mockRepo = new Mock<IRestaurantService>();
            mockRepo.Setup(_repository => _repository.GetRestaurantListAsync()).ReturnsAsync(new List<RestaurantResponse>());

            return mockRepo;
        }

        //Mock to add new restaurant
        public static Mock<IRestaurantService> AddRestaurant()
        {
          
            var mockRepo = new Mock<IRestaurantService>();
            mockRepo.Setup(_repository => _repository.AddRestaurantAsync(It.IsAny<Restaurant>())).ReturnsAsync(new Restaurant());
            return mockRepo;
        }




    }
    
}

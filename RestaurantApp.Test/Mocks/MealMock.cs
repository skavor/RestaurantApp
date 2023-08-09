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
    internal class MealMock
    {
        //Mock to get meal by Id
        public static Mock<IMealService> GetMealById()
        {
            
            var mockMealService = new Mock<IMealService>();

            mockMealService.Setup(_repository => _repository.GetMealByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new MealDetailResponse());
            return mockMealService;
        }

        //Mock to get meal list by restaurant
        public static Mock<IMealService> GetMealListByRestaurant()
        {
            var mockMealService = new Mock<IMealService>();
            mockMealService.Setup(_repository => _repository.GetMealsByRestaurantsAsync(It.IsAny<Guid>())).ReturnsAsync(new List<MealListResponse>());
            return mockMealService;
        }

        
    }
}

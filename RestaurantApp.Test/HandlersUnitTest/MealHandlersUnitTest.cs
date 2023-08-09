using Moq;
using RestaurantApp.API.Handlers;
using RestaurantApp.API.Interfaces;
using RestaurantApp.API.Queries;
using RestaurantApp.API.Response;
using RestaurantApp.Test.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace RestaurantApp.Test.HandlersUnitTest
{
    public class MealHandlersUnitTest
    {
       
        
        //unit test for getting meal by Id
        [Fact]
        public async Task GetMealByIdTest()
        {
            var handler = new GetMealByIdHandler(MealMock.GetMealById().Object);
            var result = await handler.Handle(new GetMealByIdQuery(), CancellationToken.None);
            result.ShouldBeOfType<MealDetailResponse>();
            Assert.NotNull(result);
            
        }


        //unit test for getting meal list
        [Fact]
        public async Task GetMealListTest()
        {
            var handler = new GetMealsListHandler(MealMock.GetMealListByRestaurant().Object);
            var result = await handler.Handle(new GetMealsListByRestaurantQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<MealListResponse>>();
            Assert.NotNull(result);
        }
    }
}

using RestaurantApp.API.Commands;
using RestaurantApp.API.Data.Entities;
using RestaurantApp.API.Handlers;
using RestaurantApp.API.Interfaces;
using RestaurantApp.API.Models.Restaurant;
using RestaurantApp.API.Queries;
using RestaurantApp.API.Response;
using RestaurantApp.Test.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace RestaurantApp.Test.HandlersUnitTest
{
    public class RestaurantHandlersUnitTest
    {
        //unit test for retriving restaurant list data
        [Fact]
        public async Task GetRestaurantListTest()
        {
            var handler = new GetRestaurantListHandler(RestaurantMock.GetRestaurantList().Object);
            var result = await handler.Handle(new GetRestaurantListQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<RestaurantResponse>>();
            Assert.Empty(result);
        }


        //unit test for failed creating restaurant 
        [Fact]
        public async Task AddRestaurantFailedTest()
        {
            var newAddress = new Address()
            {
                City = "Nanterre",
                Street = "44 avenue du maréchal joffre",
                CodePostal = "92000",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var user = new UserResponse()
            {
                Firstname = "Iskander",
                Lastname = "Thabet",
                PhoneNumber = "0682793432",
                Email = "iskander.thabet@outlook.fr",
            };

            RestaurantModel restaurantModel = new RestaurantModel()
            {
                Name = "Mackdonalds",
                Address = newAddress,
                Responsable = user,
                Id = Guid.NewGuid(),
            };

            var handler = new CreateRestaurantHandler(RestaurantMock.GetRestaurantList().Object, AddressMock.GetAddressList().Object);
            var result = await handler.Handle(new CreateRestaurantCommand(restaurantModel), CancellationToken.None);
            var restaurants = await RestaurantMock.GetRestaurantList().Object.GetRestaurantListAsync();
            restaurants.Count.ShouldBe(0);


        }

        //unit test for success creating restaurant 
        [Fact]
        public async Task AddRestaurantSuccessTest()
        {
            var newAddress = new Address()
            {
                City = "Nanterre",
                Street = "44 avenue du maréchal joffre",
                CodePostal = "92000",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var user = new UserResponse()
            {
                Firstname = "Iskander",
                Lastname = "Thabet",
                PhoneNumber = "0682793432",
                Email = "iskander.thabet@outlook.fr",
            };

            RestaurantModel restaurantModel = new RestaurantModel()
            {
                Name = "Iskander",
                Address = newAddress,
                Responsable = user,
                Id = Guid.NewGuid(),
            };

            var handler = new CreateRestaurantHandler(RestaurantMock.AddRestaurant().Object, AddressMock.GetAddressList().Object);
            var result = await handler.Handle(new CreateRestaurantCommand(restaurantModel), CancellationToken.None);

            result.ShouldBeOfType<Restaurant>();


        }


    }
}

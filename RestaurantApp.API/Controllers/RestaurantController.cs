using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.API.Commands;
using RestaurantApp.API.Models.Restaurant;
using RestaurantApp.API.Queries;
using RestSharp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public RestaurantController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }


        // This method handles an HTTP POST request to add a new restaurant.
        [HttpPost("AddRestaurant")]
        public async Task<IActionResult> AddRestaurantAsync([FromBody] RestaurantModel restaurantModel)
        {
            try
            {
                if(ModelState.IsValid) {
                    var restaurantCreated = await _mediatR.Send(new CreateRestaurantCommand(restaurantModel));
                    return Ok("Restaurant has been created!");
                }
                return BadRequest(new { Message = "Model Invalid" });
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


        // This method handles an HTTP GET request to retrive all restaurant list.
        [HttpGet("ListRestaurant")]
        public async Task<IActionResult> GetRestaurantList()
        {
            try
            {
                var RestaurantList = await _mediatR.Send(new GetRestaurantListQuery());

                return Ok(RestaurantList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}

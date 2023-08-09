using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.API.Commands;
using RestaurantApp.API.Models.Meals;
using RestaurantApp.API.Queries;


namespace RestaurantApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public MealController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }


        // This method handles an HTTP GET request to retrive all categories list.
        [HttpGet("ListCategories")]
        public async Task<IActionResult> GetCategoriesList()
        {
            try
            {
                var Categories = await _mediatR.Send(new GetCategoriesListQuery());
                return Ok(Categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        // This method handles an HTTP GET request to retrive all ingredients list.
        [HttpGet("ListIngredients")]
        public async Task<IActionResult> GetIngredientsList()
        {
            try
            {
                var Ingredients = await _mediatR.Send(new GetIngredientsListQuery());
                return Ok(Ingredients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        // This method handles an HTTP POST request to add meal.
        [HttpPost("AddMeal/{RestaurantId}")]
        public async Task<IActionResult> AddMealAsync([FromBody] MealModel mealModel, [FromRoute] Guid RestaurantId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var restaurantCreated = await _mediatR.Send(new AddMealToRestaurantCommand(mealModel, RestaurantId));
                    return Ok("Meal has been added!");
                }
                return BadRequest(new { Message = "Model Invalid" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        // This method handles an HTTP GET request to retrive all meals list.
        [HttpGet("ListMeals/{RestaurantId}")]
        public async Task<IActionResult> GetMealsList([FromRoute] Guid RestaurantId)
        {
            try
            {
                var MealsList = await _mediatR.Send(new GetMealsListByRestaurantQuery() { RestaurantId = RestaurantId });

                return Ok(MealsList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{MealId}")]
        public async Task<IActionResult> GetMealById([FromRoute] Guid MealId)
        {
            try
            {
                var MealsList = await _mediatR.Send(new GetMealByIdQuery() { MealId = MealId });

                return Ok(MealsList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}

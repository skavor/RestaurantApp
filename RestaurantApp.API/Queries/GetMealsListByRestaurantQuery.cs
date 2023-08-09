using MediatR;
using RestaurantApp.API.Response;

namespace RestaurantApp.API.Queries
{
    public class GetMealsListByRestaurantQuery : IRequest<List<MealListResponse>>
    {
        public Guid RestaurantId { get; set; }
    }

    
}

using MediatR;
using RestaurantApp.API.Response;

namespace RestaurantApp.API.Queries
{
    public class GetMealByIdQuery : IRequest<MealDetailResponse>
    {
        public Guid MealId { get; set; }
    }
}

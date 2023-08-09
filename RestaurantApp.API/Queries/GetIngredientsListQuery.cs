using MediatR;

namespace RestaurantApp.API.Queries
{
    public class GetIngredientsListQuery : IRequest<List<string>>
    {
    }
}

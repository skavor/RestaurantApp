using MediatR;

namespace RestaurantApp.API.Queries
{
    public class GetCategoriesListQuery : IRequest<List<string>>
    {
    }
}

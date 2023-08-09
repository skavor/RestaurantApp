namespace RestaurantApp.API.Data.DataAccess.Interfaces
{
   
    public interface IRestaurantAppEntity<T>
    {
        T Id { get; set; }
    }
}

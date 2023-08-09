using RestaurantApp.API.Data.DataAccess.Interfaces;

namespace RestaurantApp.API.Data.Entities
{
    public class Restaurant : IRestaurantAppEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public virtual User? Responsable { get; set; }
        public virtual Address? Address { get; set; }

    }
}

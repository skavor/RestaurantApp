using RestaurantApp.API.Data.DataAccess.Interfaces;

namespace RestaurantApp.API.Data.Entities
{
    
    public class Address : IRestaurantAppEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }

        public string? CodePostal { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.API.Data.Entities;

namespace RestaurantApp.API.Data.DataAccess
{
    public class AppDbContext : IdentityDbContext<User>, IDisposable
    {
       
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
            Database.EnsureCreated();
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Address> Address { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Meal> Meals { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }

   
}

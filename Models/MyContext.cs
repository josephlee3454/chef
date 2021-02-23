using Microsoft.EntityFrameworkCore;

namespace chefndish.Models
{
    public class ChefContext : DbContext
    {
        public ChefContext(DbContextOptions options) : base(options) { }
        // tables in db
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Dish> Dishes { get; set; }
    }
}
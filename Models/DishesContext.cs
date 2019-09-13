using Microsoft.EntityFrameworkCore;

namespace crudelicious.Models
{
    public class DishesContext : DbContext
    {
        public DishesContext(DbContextOptions options) : base(options) { }

        public DbSet<Dishes> Dishes { get; set; }
    }
}
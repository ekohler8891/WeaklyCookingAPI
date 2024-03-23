using Microsoft.EntityFrameworkCore;
using WeaklyCookingAPI.Models;

namespace WeaklyCookingAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        

    }
}

using Microsoft.EntityFrameworkCore;
using WeaklyCookingAPI.Models;

namespace WeaklyCookingAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        //Will need to run commands to update db in future to fix grammer
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }  
        public DbSet<Instruction> Instructions { get; set; }

    }
}

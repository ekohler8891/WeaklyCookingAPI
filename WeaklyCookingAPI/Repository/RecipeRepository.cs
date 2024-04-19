using Microsoft.EntityFrameworkCore;
using WeaklyCookingAPI.Data;
using WeaklyCookingAPI.Interfaces;
using WeaklyCookingAPI.Models;

namespace WeaklyCookingAPI.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ApplicationDBContext _context;
        public RecipeRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public Task<List<Recipe>> GetAllAsync()
        {
            return _context.Recipe.ToListAsync();
        }
    }
}

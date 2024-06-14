using Microsoft.EntityFrameworkCore;
using WeaklyCookingAPI.Data;
using WeaklyCookingAPI.Interfaces;
using WeaklyCookingAPI.Models;

namespace WeaklyCookingAPI.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly ApplicationDBContext _context;
        public IngredientRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Ingredient>> GetAllAsync()
        {
            return await _context.Ingredients.ToListAsync();
        }

        public async Task<Ingredient> GetByIdAsync(int id)
        {
            return await _context.Ingredients.FindAsync(id);
        }

    }
}

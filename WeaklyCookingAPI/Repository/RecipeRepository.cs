using Microsoft.EntityFrameworkCore;
using WeaklyCookingAPI.Data;
using WeaklyCookingAPI.Dtos.Recipe;
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

        public async Task<Recipe> CreateAsync(Recipe recipeModel)
        {
            await _context.Recipe.AddAsync(recipeModel);
            await _context.SaveChangesAsync();
            return recipeModel;
        }

        public async Task<Recipe?> DeleteAsync(int id)
        {
            var recipeModel = await _context.Recipe.FirstOrDefaultAsync(x => x.Id == id);
            if (recipeModel == null)
            {
                return null;
            }
            _context.Recipe.Remove(recipeModel);
            await _context.SaveChangesAsync();
            return recipeModel;
        }

        public async Task<List<Recipe>> GetAllAsync()
        {
            return await _context.Recipe.ToListAsync();
        }

        public async Task<Recipe?> GetByIdAsync(int id)
        {
            return await _context.Recipe.FirstOrDefaultAsync(i =>
                    i.Id == id);
        }

        public async Task<Recipe?> UpdateAsync(int id, UpdateRecipeRequestDto recipeDto)
        {
            var existingRecipe = await _context.Recipe.FindAsync(id);
            if (existingRecipe == null) 
            {
                return null;
            }

            existingRecipe.Title = recipeDto.Title;
            existingRecipe.Instructions = recipeDto.Instructions;
            existingRecipe.Ingredients = recipeDto.Ingredients;
            existingRecipe.Notes = recipeDto.Notes;
            existingRecipe.CookTime = recipeDto.CookTime;
            existingRecipe.PrepTime = recipeDto.PrepTime;
            existingRecipe.Servings = recipeDto.Servings;
            existingRecipe.TotalCalories = recipeDto.TotalCalories;
            existingRecipe.Group = recipeDto.Group;

            await _context.SaveChangesAsync();

            return existingRecipe;

        }
    }
}

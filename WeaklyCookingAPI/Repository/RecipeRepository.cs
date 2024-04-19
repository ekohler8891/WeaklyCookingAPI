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
            //To make sure that all ingredients are also removed.
            var ingredientModel = await _context.Ingredients.ToListAsync();

            if (ingredientModel != null)
            {
                foreach (var ingredient in ingredientModel)
                {
                    _context.Ingredients.Remove(ingredient);
                }
            }

            //To make sure that all instructions are also removed.
            var instructionModel = await _context.Instructions.ToListAsync();

            if (instructionModel != null)
            {
                foreach (var instruction in instructionModel)
                {
                    _context.Instructions.Remove(instruction);
                }
            }

            //To make sure that all quantity are also removed.
            var quantityModel = await _context.Quantities.ToListAsync();

            if (quantityModel != null)
            {
                foreach (var quantity in quantityModel)
                {
                    _context.Quantities.Remove(quantity);
                }
            }
            _context.Recipe.Remove(recipeModel);
            await _context.SaveChangesAsync();
            return recipeModel;
        }

        public async Task<List<Recipe>> GetAllAsync()
        {
            return await _context.Recipe.Include(c =>
                c.Instructions).ToListAsync();
        }

        public async Task<Recipe?> GetByIdAsync(int id)
        {
            return await _context.Recipe.Include(c =>
                c.Instructions).FirstOrDefaultAsync(i =>
                    i.Id == id);
        }

        public async Task<Recipe?> UpdateAsync(int id, UpdateRecipeRequestDto recipeDto)
        {
            var existingRecipe = await _context.Recipe.FindAsync(id);
            if (existingRecipe == null) 
            {
                return null;
            }

            existingRecipe.Name = recipeDto.Name;
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

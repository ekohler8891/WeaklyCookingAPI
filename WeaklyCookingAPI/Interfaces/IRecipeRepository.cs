using WeaklyCookingAPI.Dtos.Recipe;
using WeaklyCookingAPI.Models;

namespace WeaklyCookingAPI.Interfaces
{
    public interface IRecipeRepository
    {
        Task<List<Recipe>> GetAllAsync();
        //First or defualt can be null so we do not want to return null so we put the ? at the end of recipe.
        Task<Recipe?> GetByIdAsync(int id);
        Task<Recipe> CreateAsync(Recipe recipeModel);
        Task<Recipe?> UpdateAsync(int id, UpdateRecipeRequestDto recipeDto);
        Task<Recipe?> DeleteAsync(int id);
    }
}

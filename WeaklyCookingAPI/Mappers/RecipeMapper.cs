using WeaklyCookingAPI.Dtos.Recipe;
using WeaklyCookingAPI.Models;

namespace WeaklyCookingAPI.Mappers
{
    public static class RecipeMapper
    {
        public static RecipeDto ToRecipeDto(this Recipe recipeModel)
        {
            return new RecipeDto
            {
                Id = recipeModel.Id,
                Name = recipeModel.Name,
                Notes = recipeModel.Notes,
                CookTime = recipeModel.CookTime,
                PrepTime = recipeModel.PrepTime,
                Servings = recipeModel.Servings,
                TotalCalories = recipeModel.TotalCalories,
                Group = recipeModel.Group
            };
        }
    }
}

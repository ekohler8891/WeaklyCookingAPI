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
                Group = recipeModel.Group,
                Instructions = recipeModel.Instructions.Select(i =>
                i.ToInstructionDto()).ToList()
            };
        }

        public static Recipe ToRecipeFromCreateDTO(this CreateRecipeRequestDto recipeDto)
        {
            return new Recipe
            {
                Name = recipeDto.Name,
                Notes = recipeDto.Notes,
                CookTime = recipeDto.CookTime,
                PrepTime = recipeDto.PrepTime,
                Servings = recipeDto.Servings,
                TotalCalories = recipeDto.TotalCalories,
                Group = recipeDto.Group
            };
        }
    }
}

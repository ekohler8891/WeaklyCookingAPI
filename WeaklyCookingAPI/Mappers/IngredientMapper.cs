using WeaklyCookingAPI.Dtos.Ingredients;
using WeaklyCookingAPI.Dtos.Recipe;
using WeaklyCookingAPI.Models;

namespace WeaklyCookingAPI.Mappers
{
    public static class IngredientMapper
    {
        public static IngredientDto ToIngredientDto(
            this Ingredient ingredientModel)
        {
            return new IngredientDto
            {
                recipeId = ingredientModel.recipeId,
                Id = ingredientModel.Id,
                Catagory = ingredientModel.Catagory,
                FoodName = ingredientModel.FoodName,
                Calories = ingredientModel.Calories
            };
        }
        
    }
}

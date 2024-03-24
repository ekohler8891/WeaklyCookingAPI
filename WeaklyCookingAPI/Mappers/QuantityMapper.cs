using WeaklyCookingAPI.Dtos.Quantities;
using WeaklyCookingAPI.Dtos.Recipe;
using WeaklyCookingAPI.Models;

namespace WeaklyCookingAPI.Mappers
{
    public static class QuantityMapper
    {
        public static QuantityDto ToQuantityDto(
            this Quantity quantityModel)
        {
            return new QuantityDto 
            {
                id = quantityModel.id,
                IngredientId = quantityModel.IngredientId,
                Ingredient = quantityModel.Ingredient,
                Metric = quantityModel.Metric,
                Amount = quantityModel.Amount
            };
        }
    }
}

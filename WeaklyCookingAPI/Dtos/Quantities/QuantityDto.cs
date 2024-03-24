using WeaklyCookingAPI.Models;

namespace WeaklyCookingAPI.Dtos.Quantities
{
    public class QuantityDto
    {
        public int id { get; set; }
        public int? IngredientId { get; set; }
        public Ingredient? Ingredient { get; set; }
        public string Metric { get; set; } = string.Empty;
        public float Amount { get; set; }
    }
}

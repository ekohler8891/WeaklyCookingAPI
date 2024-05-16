using System.Reflection.Metadata;

namespace WeaklyCookingAPI.Models
{
    public class Ingredient
    {
        public int? recipeId {  get; set; }
        public Recipe? Recipe { get; set; }
        public int Id { get; set; }
        public string Catagory { get; set; } = string.Empty;
        public string FoodName { get; set; } = string.Empty;
        public int Calories { get; set; }
        public string Metric { get; set; } = string.Empty;
        public float Amount { get; set; }

    }
}
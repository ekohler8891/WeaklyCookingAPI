namespace WeaklyCookingAPI.Dtos.Ingredients
{
    public class IngredientDto
    {
        public int? recipeId { get; set; }
      //  public Recipe? Recipe { get; set; }
        public int Id { get; set; }
        public string Catagory { get; set; } = string.Empty;
        public string FoodName { get; set; } = string.Empty;
        public int Calories { get; set; }
    }
}

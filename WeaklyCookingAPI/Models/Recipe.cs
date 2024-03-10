namespace WeaklyCookingAPI.Models
{
    public class Recipe
    {
        public  int Id { get; set; }

        public ICollection<string> Instructions;
        
        public ICollection<Ingredient> Ingredients;
        public string Notes { get; set; }
        public int CookTime { get; set; }
        public int PrepTime { get; set; }
        public double Servings { get; set; }
        public int TotalCalories { get; set; }
        public string Group { get; set; }
    }
}

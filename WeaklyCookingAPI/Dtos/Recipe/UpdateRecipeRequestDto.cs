namespace WeaklyCookingAPI.Dtos.Recipe
{
    public class UpdateRecipeRequestDto
    {
        //do not want the ID for this
        //   public int Id { get; set; }
        public String Name { get; set; } = String.Empty;
        //Will address later
        //     public List<Instruction> Instructions { get; set; } = new List<Instruction>();
        //      public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public string Notes { get; set; } = string.Empty;
        public int CookTime { get; set; }
        public int PrepTime { get; set; }
        public double Servings { get; set; }
        public int TotalCalories { get; set; }
        public string Group { get; set; } = string.Empty;
    }
}

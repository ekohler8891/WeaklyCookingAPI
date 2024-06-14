using WeaklyCookingAPI.Dtos.Instructions;
using WeaklyCookingAPI.Models;

namespace WeaklyCookingAPI.Dtos.Recipe
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public String Name { get; set; } = String.Empty;
        public List<InstructionDto> Instructions { get; set; }
        public string Notes { get; set; } = string.Empty;
        public int CookTime { get; set; }
        public int PrepTime { get; set; }
        public double Servings { get; set; }
        public int TotalCalories { get; set; }
        public string Group { get; set; } = string.Empty;


    }
}

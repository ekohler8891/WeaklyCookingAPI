using Microsoft.EntityFrameworkCore;

namespace WeaklyCookingAPI.Models
{
    public class Recipe
    {
        public  int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<string> Instructions { get; set; } = new List<string>();
        public List<string> Ingredients { get; set; } = new List<string>();
        public string Notes { get; set; } = string.Empty;
        public int CookTime { get; set; }
        public int PrepTime { get; set; }
        public double Servings { get; set; }
        public int TotalCalories { get; set; }
        public string Group { get; set; } = string.Empty;
        
    }
}

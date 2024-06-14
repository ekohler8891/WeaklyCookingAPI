using WeaklyCookingAPI.Dtos.Ingredients;

namespace WeaklyCookingAPI.Dtos.Instructions
{
    public class InstructionDto
    {
        public int InstructionId { get; set; }
        public string InstructionName { get; set; } = string.Empty;
        public int StepNumber { get; set; }
      //  public List<IngredientDto> Ingredients { get; set; }
    }
}

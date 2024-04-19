namespace WeaklyCookingAPI.Models
{
    public class Instruction
    {
        public int InstructionId { get; set; }
        public string InstructionName { get; set; } = string.Empty;
        public int StepNumber { get; set; }
        public Recipe? Recipe { get; set; }
    }
}

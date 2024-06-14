namespace WeaklyCookingAPI.Dtos.Instructions
{
    public class UpdateInstructionRequestDto
    {
        public int InstructionId { get; set; }
        public string InstructionName { get; set; } = string.Empty;
        public int StepNumber { get; set; }
    }
}

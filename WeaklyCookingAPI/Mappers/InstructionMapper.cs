using WeaklyCookingAPI.Dtos.Instructions;
using WeaklyCookingAPI.Dtos.Recipe;
using WeaklyCookingAPI.Models;

namespace WeaklyCookingAPI.Mappers
{
    public static class InstructionMapper
    {
        public static InstructionDto ToInstructionDto(
            this Instruction instructionModel)
        {
            return new InstructionDto
            {
                InstructionId = instructionModel.InstructionId,
                InstructionName = instructionModel.InstructionName,
                StepNumber = instructionModel.StepNumber,
            };
        }
    }
}

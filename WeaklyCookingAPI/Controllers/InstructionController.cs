using Microsoft.AspNetCore.Mvc;
using WeaklyCookingAPI.Data;
using WeaklyCookingAPI.Interfaces;
using WeaklyCookingAPI.Mappers;

namespace WeaklyCookingAPI.Controllers
{
    [Route("WeaklyCooking/Instruction")]
    [ApiController]
    public class InstructionController : ControllerBase
    {
        private readonly IInstructionRepository _instructionRepo;

        public InstructionController(IInstructionRepository instructionRepo)
        {
            _instructionRepo = instructionRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var instructions = await _instructionRepo.GetAllAsync();
            var instructionDto = instructions.Select(s => s.ToInstructionDto());
            return Ok(instructionDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var instruction = await _instructionRepo.GetByIdAsync(id);
            if(instruction == null)
            {
                return NotFound();
            }
            return Ok(instruction.ToInstructionDto());
        }

    }
}

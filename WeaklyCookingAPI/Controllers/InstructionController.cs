using Microsoft.AspNetCore.Mvc;
using WeaklyCookingAPI.Data;
using WeaklyCookingAPI.Mappers;

namespace WeaklyCookingAPI.Controllers
{
    [Route("WeaklyCooking/Instruction")]
    [ApiController]
    public class InstructionController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public InstructionController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var instructions = _context.Instructions.ToList()
                .Select(i=>i.ToInstructionDto());

            return Ok(instructions);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id) 
        {
            var instruction = _context.Instructions.Find(id);
            if(instruction == null)
            {
                return NotFound();
            }
            return Ok(instruction.ToInstructionDto());
        }

    }
}

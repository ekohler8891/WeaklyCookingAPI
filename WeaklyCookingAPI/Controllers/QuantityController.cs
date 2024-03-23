using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WeaklyCookingAPI.Data;

namespace WeaklyCookingAPI.Controllers
{
    [Route("WeaklyCooking/Quantity")]
    [ApiController]
    public class QuantityController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public QuantityController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll() 
        {
            var quantities = _context.Quantities.ToList();

            return Ok(quantities);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id) 
        {
            var quantity = _context.Quantities.Find(id);
            if (quantity == null)
            {
                return NotFound();
            }
            return Ok(quantity);
        }
    }
}

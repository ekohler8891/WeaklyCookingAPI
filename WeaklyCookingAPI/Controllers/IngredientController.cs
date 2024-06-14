using Microsoft.AspNetCore.Mvc;
using WeaklyCookingAPI.Data;
using WeaklyCookingAPI.Interfaces;
using WeaklyCookingAPI.Mappers;

namespace WeaklyCookingAPI.Controllers
{
    [Route("WeaklyCooking/Ingredient")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientRepository _ingredientRepo;
        public IngredientController(IIngredientRepository ingrentRepo)
        {
            _ingredientRepo = ingrentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var ingredients = await _ingredientRepo.GetAllAsync();
            var ingredientDto = ingredients.Select(i => i.ToIngredientDto());
            return Ok(ingredientDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute]int id) 
        {
            var ingredient = await _ingredientRepo.GetByIdAsync(id);
            if(ingredient == null)
            {
                return NotFound();
            }
            return Ok(ingredient.ToIngredientDto());
        }
    }
}

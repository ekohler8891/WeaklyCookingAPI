using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeaklyCookingAPI.Data;
using WeaklyCookingAPI.Dtos.Recipe;
using WeaklyCookingAPI.Interfaces;
using WeaklyCookingAPI.Mappers;
using WeaklyCookingAPI.Models;

namespace WeaklyCookingAPI.Controllers
{
    [Route("WeaklyCooking/recipe")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IRecipeRepository _recipeRepo;
        public RecipeController(ApplicationDBContext contex, IRecipeRepository recipeRepo)
        {
            _recipeRepo = recipeRepo;
            _context = contex;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var recipes = await _recipeRepo.GetAllAsync();
                
            var recipeDTO = recipes.Select(r=>r.ToRecipeDto());

            return Ok(recipeDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var recipe = await _recipeRepo.GetByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe.ToRecipeDto());
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRecipeRequestDto recipeDto)
        {
            var recipeModel = recipeDto.ToRecipeFromCreateDTO();
            await _recipeRepo.CreateAsync(recipeModel);
            return CreatedAtAction(nameof(GetById), new {id = recipeModel.Id},
                recipeModel.ToRecipeDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRecipeRequestDto updateDto)
        {
            var recipeModel = await _recipeRepo.UpdateAsync(id, updateDto);

            if(recipeModel == null)
            {
                return NotFound();
            }

            return Ok(recipeModel.ToRecipeDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            var recipeModel = await _recipeRepo.DeleteAsync(id);
          
            if (recipeModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

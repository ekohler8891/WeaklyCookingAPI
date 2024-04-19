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
            var recipe = await _context.Recipe.FindAsync(id);
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
            await _context.Recipe.AddAsync(recipeModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = recipeModel.Id},
                recipeModel.ToRecipeDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRecipeRequestDto updateDto)
        {
            var recipeModel = await _context.Recipe.FirstOrDefaultAsync(x=>x.Id == id);

            if(recipeModel == null)
            {
                return NotFound();
            }

            recipeModel.Name = updateDto.Name; 
            recipeModel.Notes = updateDto.Notes;
            recipeModel.CookTime = updateDto.CookTime;
            recipeModel.PrepTime = updateDto.PrepTime;
            recipeModel.Servings = updateDto.Servings;
            recipeModel.TotalCalories = updateDto.TotalCalories;
            recipeModel.Group = updateDto.Group;

            await _context.SaveChangesAsync();

            return Ok(recipeModel.ToRecipeDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            var recipeModel = await _context.Recipe.FirstOrDefaultAsync(x => x.Id == id);
          
            if (recipeModel == null)
            {
                return NotFound();
            }

            //To make sure that all ingredients are also removed.
            var ingredientModel = await _context.Ingredients.ToListAsync();
          
            if (ingredientModel != null)
            {
                foreach (var ingredient in ingredientModel)
                {
                    _context.Ingredients.Remove(ingredient);
                }
            }

            //To make sure that all instructions are also removed.
            var instructionModel = await _context.Instructions.ToListAsync();
            
            if (instructionModel != null)
            {
                foreach (var instruction in instructionModel)
                {
                    _context.Instructions.Remove(instruction);
                }
            }

            //To make sure that all quantity are also removed.
            var quantityModel = await _context.Quantities.ToListAsync();

            if (quantityModel != null)
            {
                foreach (var quantity in quantityModel)
                {
                    _context.Quantities.Remove(quantity);
                }
            }

            _context.Recipe.Remove(recipeModel);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

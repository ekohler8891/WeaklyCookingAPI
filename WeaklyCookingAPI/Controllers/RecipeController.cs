using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeaklyCookingAPI.Data;
using WeaklyCookingAPI.Dtos.Recipe;
using WeaklyCookingAPI.Mappers;
using WeaklyCookingAPI.Models;

namespace WeaklyCookingAPI.Controllers
{
    [Route("WeaklyCooking/recipe")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public RecipeController(ApplicationDBContext contex)
        {
            _context = contex;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var recipes = _context.Recipe.ToList()
                .Select(r=>r.ToRecipeDto());

            return Ok(recipes);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var recipe = _context.Recipe.Find(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe.ToRecipeDto());
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateRecipeRequestDto recipeDto)
        {
            var recipeModel = recipeDto.ToRecipeFromCreateDTO();
            _context.Recipe.Add(recipeModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = recipeModel.Id},
                recipeModel.ToRecipeDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateRecipeRequestDto updateDto)
        {
            var recipeModel = _context.Recipe.FirstOrDefault(x=>x.Id == id);

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

            _context.SaveChanges();

            return Ok(recipeModel.ToRecipeDto());
        }

    }
}

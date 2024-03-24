using Microsoft.AspNetCore.Mvc;
using WeaklyCookingAPI.Data;
using WeaklyCookingAPI.Dtos.Recipe;
using WeaklyCookingAPI.Mappers;

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
    }
}

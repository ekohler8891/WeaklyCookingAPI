﻿using Microsoft.AspNetCore.Mvc;
using WeaklyCookingAPI.Data;

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
            var recipes = _context.Recipe.ToList();

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
            return Ok(recipe);
        }

    }
}

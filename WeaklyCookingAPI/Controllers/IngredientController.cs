﻿using Microsoft.AspNetCore.Mvc;
using WeaklyCookingAPI.Data;
using WeaklyCookingAPI.Mappers;

namespace WeaklyCookingAPI.Controllers
{
    [Route("WeaklyCooking/Ingredient")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public IngredientController(ApplicationDBContext contex)
        {
            _context = contex;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var ingredient = _context.Ingredients.ToList()
                .Select(i=>i.ToIngredientDto());
            return Ok(ingredient);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id) 
        {
            var ingredient = _context.Ingredients.Find(id);
            if(ingredient == null)
            {
                return NotFound();
            }
            return Ok(ingredient.ToIngredientDto());
        }
    }
}

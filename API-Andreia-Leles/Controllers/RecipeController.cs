using API_Andreia_Leles.Entities;
using API_Andreia_Leles.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API_Andreia_Leles.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private IRecipeService recipeService;
        public RecipeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        [HttpGet("getRecipes")]
        public IActionResult GetRecipes()
        {

            List<Recipe> recipes = recipeService.GetAll();

            if (recipes != null)
            {
                return Ok(recipes);
            }

            return NotFound();
        }

        [HttpPost("insertRecipe")]
        public IActionResult InsertRecipe(Recipe recipe)
        {
            bool result = false;

            if (recipe != null)
            {
                result = recipeService.Insert(recipe);
            }

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
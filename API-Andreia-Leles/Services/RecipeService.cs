using API_Andreia_Leles.Entities;
using API_Andreia_Leles.Repository.Interfaces;
using API_Andreia_Leles.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;

namespace API_Andreia_Leles.Services
{
    public class RecipeService : IRecipeService
    {
        private IRecipeRepository repository;

        public RecipeService(IRecipeRepository repository)
        {
            this.repository = repository;
        }

        public bool Insert(Recipe recipe)
        {
            if (recipe != null)
            {
                return repository.Insert(recipe);
            }

            return false;
        }

        public List<Recipe> GetAll()
        {
            List<Recipe> auxList = null;
            DataTable dt = repository.GetAll();

            if (dt != null)
            {
                auxList = repository.ConvertDataTableIntoList(dt);
            }

            return auxList;
        }
    }
}
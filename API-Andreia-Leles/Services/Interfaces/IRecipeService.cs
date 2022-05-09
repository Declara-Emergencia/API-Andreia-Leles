using API_Andreia_Leles.Entities;
using System.Collections.Generic;

namespace API_Andreia_Leles.Services.Interfaces
{
    public interface IRecipeService
    {
        List<Recipe> GetAll();
        bool Insert(Recipe recipe);
    }
}
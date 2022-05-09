using API_Andreia_Leles.Entities;
using System.Collections.Generic;
using System.Data;

namespace API_Andreia_Leles.Repository.Interfaces
{
    public interface IRecipeRepository
    {
        List<Recipe> ConvertDataTableIntoList(DataTable dt);
        DataTable GetAll();
        bool Insert(Recipe recipe);
    }
}
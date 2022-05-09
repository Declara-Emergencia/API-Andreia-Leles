using API_Andreia_Leles.Entities;
using API_Andreia_Leles.Repository;
using API_Andreia_Leles.Repository.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace API_Tests
{
    public class RecipeRepositoryTests
    {

        [Fact]
        public void GetAll_CheckNumberOfColumns()
        {
            int columnsNumber = 2;
            RecipeRepository recipeRepository = new();
            var aux = recipeRepository.GetAll();

            Assert.Equal(aux.Columns.Count, columnsNumber);
        }
    }
}

using System;
using Xunit;
using Moq;
using API_Andreia_Leles.Services.Interfaces;
using API_Andreia_Leles.Repository.Interfaces;
using API_Andreia_Leles.Entities;
using System.Collections.Generic;
using API_Andreia_Leles.Controllers;
using Microsoft.AspNetCore.Mvc;
using API_Andreia_Leles.Services;
using API_Andreia_Leles.Repository;

namespace API_Tests
{
    public class ControllerTests
    {
        [Fact]
        public void GetAll_GetsAllDataFromDb_AssertTrue()
        {
            //Arrange
            Recipe recipe = new()
            {
                RecipeName = "Bolo"
            };

            List<Recipe> auxList = new();
            auxList.Add(recipe);

            Mock<IRecipeService> mock = new();
            mock.Setup(x => x.GetAll()).Returns(auxList);

            //Act
            ObjectResult actualResult;
            OkObjectResult okObjectResult = new(auxList);
            ObjectResult expectedResult = okObjectResult;
            RecipeController recipeController = new(mock.Object);

            actualResult = recipeController.GetRecipes() as ObjectResult;

            //Assert
            Assert.Equal(expectedResult.StatusCode, actualResult.StatusCode);
        }
    }
}

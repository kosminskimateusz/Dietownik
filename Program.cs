using System;
using System.Collections.Generic;
using System.Linq;

namespace Dietownik
{
    class Program
    {
        static void Main(string[] args)
        {
            // ProductManager productManager = new ProductManager();
            // productManager.Start();

            // var products = productManager.SortProductsByKcal();
            // productManager.PrintProductList(products);
            
            // System.Console.WriteLine('\n');
            
            // products = productManager.AllProducts();
            // productManager.PrintProductList(products);

            RecipeManager recipeManager = new RecipeManager();
            recipeManager.Start();
            List<Recipe> recipes = new List<Recipe>();
            // recipes = recipeManager.PrintAndReturnListOfRecipes();
            // Console.WriteLine(recipes.Count);
            // foreach (var recipe in recipes)
            // {
            //     Console.WriteLine($"Nazwa dania: {recipe.Name}");
            //     Console.WriteLine($"Lista składników:");
            //     foreach (var ingredient in recipe.Ingredients)
            //     {
            //         Console.WriteLine($"{ingredient.Name}:\t{ingredient.Weight}g");
            //     }
            // }

        }
    }
}

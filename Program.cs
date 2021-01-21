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
            // productManager.PrintProductList(productManager.AllProducts());

            // RecipeManager recipeManager = new RecipeManager();
            // recipeManager.Start();
            // recipeManager.PrintAndReturnListOfRecipes("Low");
            // recipeManager.PrintAndReturnListOfRecipes("Medium");
            // recipeManager.PrintAndReturnListOfRecipes("High");
            // recipeManager.PrintAndReturnListOfRecipes("All");
            // var products = productManager.SortProductsByKcal();
            // productManager.PrintProductList(products);

            Menu menu = new Menu();
            menu.Start();
        }
    }
}

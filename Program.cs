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
            RecipeManager recipeManager1 = new RecipeManager(); 
            // var products = productManager.SortProductsByKcal();
            // productManager.PrintProductList(products);
            
            // System.Console.WriteLine('\n');
            
            // products = productManager.AllProducts();
            // productManager.PrintProductList(products);

            RecipeManager recipeManager = new RecipeManager();
            recipeManager.Start();
        }
    }
}

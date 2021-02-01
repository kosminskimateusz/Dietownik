using System;

namespace Dietownik
{
    class MainMenu : Menu
    {
        public MainMenu()
        {
            Options = new string[]
            {
                "Show List Recipes",            // 1
                "Search recipes by name",       // 2
                "Show List Products",           // 3
                "Show Product",                 // 4
                "Add Recipe",                   // 5
                "Add Product",                  // 6

                "Exit",
            };
        }

        protected override void ChooseOptions(ref int option)
        {
            bool success = Int32.TryParse(Console.ReadLine(), out option);
            if (success)
            {
                RecipeManager recipeManager = new RecipeManager();
                ProductManager productManager = new ProductManager();

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Choose Low Caloryfic, Medium Caloryfic, High Caloryfic or All Recipes (Low/Medium/High/All):");
                        string kindOfRecipe = Console.ReadLine();
                        recipeManager.PrintAndReturnListOfRecipes(kindOfRecipe);
                        break;
                    case 2:
                        Console.WriteLine("Search in name:");
                        string phrase = Console.ReadLine();
                        recipeManager.Search(phrase);
                        break;
                    case 3:
                        productManager.PrintProductList(productManager.AllProducts());
                        break;
                    case 4:

                        break;
                    case 5:
                        recipeManager.AddRecipe();
                        break;
                    case 6:
                        productManager.AddProduct();
                        break;
                    case 0:
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
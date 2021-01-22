using System;

namespace Dietownik
{
    class Menu
    {
        private string[] Options = new string[]
        {
            "Show List Recipes",
            "Search recipes by name",
            "Show List Products",
            "Show Product",
            "Add Recipes",
            "Add Product",

            "Exit",
        };
        public void Start()
        {
            int option = 0;
            do
            {
                PrintOptions();
                ChooseOptions(ref option);
                // Console.Clear();
            } while (option != 0);
        }
        private void PrintOptions()
        {
            int nr = 1;
            Console.WriteLine("Choose option:\n");
            foreach (var option in Options)
            {
                if (nr == Options.Length)
                {
                    nr = 0;
                    Console.WriteLine($"\n{nr}. {option}");
                }
                else
                {
                    Console.WriteLine($"{nr}. {option}");
                }
                nr++;
            }

        }
        private void ChooseOptions(ref int option)
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
                        Console.WriteLine("Search name:");
                        string name = Console.ReadLine();
                        recipeManager.ShowRecipeDetails();
                        break;
                    case 3:
                        productManager.PrintProductList(productManager.AllProducts());
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
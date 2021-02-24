using System;

namespace Dietownik
{
    class RecipesMenu : Menu
    {
        public RecipesMenu()
        {
            Options = new string[]
            {
                "Add Product",

                "Exit",
            };
        }

        protected override void ChooseOptions(ref int option)
        {
            bool success = Int32.TryParse(Console.ReadLine(), out option);
            if (success)
            {
                RecipesOrganizer recipesOrganizer = new RecipesOrganizer();
                ProductsOrganizer productsOrganizer = new ProductsOrganizer();

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Choose Low Caloryfic, Medium Caloryfic, High Caloryfic or All Recipes (Low/Medium/High/All):");
                        string kindOfRecipe = Console.ReadLine();
                        recipesOrganizer.PrintAndReturnListOfRecipes(kindOfRecipe);
                        break;
                    case 2:
                        Console.WriteLine("Search in name:");
                        string phrase = Console.ReadLine();
                        recipesOrganizer.Search(phrase);
                        break;
                    case 3:
                        productsOrganizer.Print();
                        break;
                    case 5:
                        recipesOrganizer.AddRecipe();
                        break;
                    case 6:
                        productsOrganizer.Add();
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
using System;
using System.Data;

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
                "Show Recipe",                  // 5
                "Add Recipe",                   // 6
                "Add Product",                  // 7

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
                Printer printer = new Printer();
                RecipeCounter recipeCounter = new RecipeCounter();

                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Choose Low Caloryfic, Medium Caloryfic, High Caloryfic or All Recipes (Low/Medium/High/All):");
                        string kindOfRecipe = Console.ReadLine();
                        recipesOrganizer.PrintAndReturnListOfRecipes(kindOfRecipe);
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Search in name:");
                        string phrase = Console.ReadLine();
                        recipesOrganizer.Search(phrase);
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        printer.Print(productsOrganizer.GetAll());
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();

                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine($"Insert recipe name: ");
                        string userInputRecipeName = Console.ReadLine();
                        Console.WriteLine($"Insert prefer kcal of complete dish: ");
                        decimal userInputKcal = Decimal.Parse(Console.ReadLine());

                        Recipe recipe = recipesOrganizer.Choose(userInputRecipeName);
                        printer.Print(recipe);
                        Recipe newRecipe = recipeCounter.Count(recipe, userInputKcal);
                        printer.Print(newRecipe);
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();
                        recipesOrganizer.AddRecipe();
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.Clear();
                        productsOrganizer.Add();
                        Console.ReadKey();
                        break;
                    case 0:
                        Console.WriteLine("Are you sure? (y/n)");
                        string userInput = Console.ReadLine();
                        if (userInput != "y" && userInput != "Y")
                            Start();
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
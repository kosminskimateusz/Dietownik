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
                        printer.Print(productsOrganizer.GetAll());
                        break;
                    case 4:

                        break;
                    case 5:
                        Console.WriteLine($"Insert recipe name: ");
                        string userInputRecipeName = Console.ReadLine();
                        Console.WriteLine($"Insert prefer kcal of complete dish: ");
                        decimal userInputKcal = Decimal.Parse(Console.ReadLine());

                        Recipe recipe = recipesOrganizer.Choose(userInputRecipeName);
                        printer.Print(recipe);
                        recipe = recipeCounter.Count(recipe, userInputKcal);
                        printer.Print(recipe);
                        break;
                    case 6:
                        recipesOrganizer.AddRecipe();
                        break;
                    case 7:
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dietownik
{
    class RecipesOrganizer
    {
        private const string FolderStd = "./Recipes/";
        private const string Extention = ".json";
        private string Folder { get; set; }
        private Recipe NewRecipe { get; set; }
        private List<Recipe> AllRecipesList { get; set; }
        private List<Ingredient> NewIngredients { get; set; }

        public RecipesOrganizer()
        {
            AllRecipesList = new List<Recipe>();
        }

        public void AddRecipe()
        {
            string recipeName = "";

            Console.WriteLine("Insert name of recipe:\t");
            recipeName = Console.ReadLine();

            AddIngredients(recipeName);
            NewRecipe = new Recipe(recipeName, NewIngredients);
            AddRecipeToDataBase();
        }
        public List<Recipe> Search(string phrase)
        {
            List<Recipe> allRecipes = GetListFromDataBase("All");
            List<Recipe> foundRecipes = allRecipes.Where(recipe => recipe.Name.ToLower().Contains(phrase.ToLower())).ToList();

            Print(foundRecipes);

            if (foundRecipes.Count == 0)
            {
                Console.WriteLine($"There's no recipe contains search phrase: {phrase}\n");
                return null;
            }
            return foundRecipes;
        }

        public Recipe Choose(string phrase)
        {
            List<Recipe> allRecipes = GetListFromDataBase("All");
            List<Recipe> foundRecipes = allRecipes.Where(recipe => recipe.Name.ToLower() == phrase.ToLower()).ToList();

            // Print(AllRecipesList);

            if (foundRecipes.Count == 0)
            {
                Console.WriteLine($"There's no recipe contains search phrase: {phrase}\n");
                return null;
            }
            return foundRecipes[0];
        }

        private void Print(List<Recipe> foundRecipes)
        {
            Printer printer = new Printer();
            printer.Print(foundRecipes);
        }

        private void AddIngredients(string recipeName)
        {
            bool end = false;
            List<Product> products = new List<Product>();
            NewIngredients = new List<Ingredient>();

            do
            {
                products = PrintAndReturnListOfProducts(products);
                PrintListOfAddedIngredients();
                AddIngredient(recipeName, products, ref end);
            } while (end == false);
        }

        private List<Product> PrintAndReturnListOfProducts(List<Product> products)
        {
            ProductsOrganizer productsOrganizer = new ProductsOrganizer();
            Console.WriteLine("List of all products:\n");
            products = productsOrganizer.GetAll();
            productsOrganizer.Print();
            Console.WriteLine('\n');
            return products;
        }

        private void PrintListOfAddedIngredients()
        {
            Console.WriteLine("Added ingredients: ");
            foreach (var newIngredient in NewIngredients)
            {
                Console.WriteLine($"{newIngredient.Name}\t{newIngredient.Weight} g");
            }
            Console.WriteLine('\n');
        }

        private void AddIngredient(string recipeName, List<Product> products, ref bool end)
        {
            Console.WriteLine($"Add ingredient to {recipeName}");
            Console.WriteLine("Type name of new ingredient or press enter to apply ingredients: ");

            string ingredientName = Console.ReadLine();

            if (ingredientName == "")
            {
                end = true;
            }
            else
            {
                bool productExist = false;
                foreach (var product in products)
                {
                    if (product.Name == ingredientName)
                    {
                        productExist = true;
                        bool ingredientExist = false;
                        foreach (var ingredient in NewIngredients)
                        {
                            if (ingredient.Name == product.Name)
                            {
                                ingredientExist = true;
                            }
                        }
                        if (!ingredientExist)
                        {
                            Console.WriteLine("Insert weigth of ingredient: ");
                            decimal newIngredientWeigth = decimal.Parse(Console.ReadLine());
                            Ingredient newIngredient = new Ingredient(product.Name, product.KcalPerHundredGrams, newIngredientWeigth);
                            NewIngredients.Add(newIngredient);
                        }
                        else
                        {
                            Console.WriteLine("This ingredient already is on the list");
                        }
                    }
                }
                if (end == false && productExist == false)
                {
                    Console.WriteLine("Produkt o podanej nazwie nie istnieje. Dodaj go w menu głównym.");
                }
            }
        }

        private void AddRecipeToDataBase()
        {
            bool fileAdded = false;
            // Create productName.json file, Add all informations (Name, Kcal, Fat etc...) in json format. 
            do
            {
                JsonManager json = new JsonManager();
                json.SaveObject(NewRecipe, GeneratePath(NewRecipe.Name));
                if (json.SaveSucced())
                {
                    fileAdded = true;
                    AllRecipesList.Add(NewRecipe);
                }
                else
                {
                    Console.WriteLine("Try again.");
                    NewRecipe.Name = Console.ReadLine();
                }
            } while (fileAdded == false);
        }

        private string GeneratePath(string fileName)
        {
            return GetFolderByKcal() + fileName + Extention;
        }

        private void ResetFolderPath()
        {
            this.Folder = FolderStd;
        }

        private string GetFolderByKcal()
        {
            if (NewRecipe.KcalPerHundredGrams < 80)
                return (FolderStd + "LowCaloryfic/");
            else if (NewRecipe.KcalPerHundredGrams >= 120)
                return (FolderStd + "HighCaloryfic/");
            else
                return (FolderStd + "MediumCaloryfic/");
        }

        public List<Recipe> PrintAndReturnListOfRecipes(string kindOfRecipe)
        {
            AllRecipesList = GetListFromDataBase(kindOfRecipe);
            Print(AllRecipesList);
            if (AllRecipesList.Count == 0)
            {
                Console.WriteLine("List of Recipes is empty. Add some Recipe.\n");
            }
            return AllRecipesList;
        }

        private List<Recipe> GetListFromDataBase(string kindOfRecipe)
        {
            AllRecipesList.Clear();

            if (kindOfRecipe == "All")
            {
                Folder = FolderStd + "LowCaloryfic/";
                GetDataFromFolder(Folder);
                Folder = FolderStd + "MediumCaloryfic/";
                GetDataFromFolder(Folder);
                Folder = FolderStd + "HighCaloryfic/";
                GetDataFromFolder(Folder);
            }
            else if (kindOfRecipe == "Low" || kindOfRecipe == "Medium" || kindOfRecipe == "High")
            {
                GetDataFromFolder(ChooseFolderByKind(kindOfRecipe));
            }
            else
            {
                Console.WriteLine($"Invalid input.");
            }
            Folder = FolderStd;
            return AllRecipesList.OrderBy(recipe => recipe.Name).ToList();
        }

        private string ChooseFolderByKind(string kindOfRecipe)
        {
            if (kindOfRecipe == "Low" || kindOfRecipe == "low")
                return FolderStd + "LowCaloryfic/";
            else if (kindOfRecipe == "Medium" || kindOfRecipe == "medium")
                return FolderStd + "MediumCaloryfic/";
            else if (kindOfRecipe == "High" || kindOfRecipe == "high")
                return FolderStd + "HighCaloryfic/";
            else
                return FolderStd;
        }

        private void GetDataFromFolder(string folder)
        {
            Folder = folder;
            JsonManager json = new JsonManager();
            foreach (string file in Directory.GetFiles(Folder, "*.json"))
            {
                Recipe recipeX = (Recipe)json.LoadObject(file);
                if (recipeX != null)
                {
                    AllRecipesList.Add(recipeX);
                }
            }
        }
    }
}
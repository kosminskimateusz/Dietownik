using System;
using System.Collections.Generic;
using System.IO;

namespace Dietownik
{
    class RecipeManager
    {
        private const string FolderStd = "./Recipes/";
        private string Folder { get; set; }
        private const string Extention = ".json";
        private string NewRecipeName { get; set; }
        private Recipe NewRecipe { get; set; }
        private List<Recipe> AllRecipesList { get; set; }
        private List<Ingredient> NewIngredients { get; set; }
        public RecipeManager()
        {
            AllRecipesList = new List<Recipe>();
        }
        public void Start()     // Working good
        {


            AddRecipe();

            // AddRecipe(recipeName, kcal);
            // AddRecipeToDataBase();
        }


        private void AddRecipe()
        {
            string recipeName = "";

            Console.WriteLine("Podaj nazwę produktu:\t");
            recipeName = Console.ReadLine();

            AddIngredients(recipeName);
            NewRecipe = new Recipe(recipeName, NewIngredients);
            AddRecipeToDataBase();
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
            ProductManager productManager = new ProductManager();
            Console.WriteLine("List of all products:\n");
            products = productManager.AllProducts();
            productManager.PrintProductList(products);
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
                            Ingredient newIngredient = new Ingredient(product.Name, product.Kcal, newIngredientWeigth);
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
            string path;
            string fileName = NewRecipe.Name;
            ChooseFolderByKcal();
            path = Folder + fileName + Extention;
            // Create productName.json file, Add all informations (Name, Kcal, Fat etc...) in json format. 
            if (!File.Exists(path))
            {
                JsonManager json = new JsonManager();
                json.SaveObject(NewRecipe, path);
                Console.WriteLine("Dodano nowy przepis do bazy danych.\n");
                Console.WriteLine($"Nazwa: {NewRecipe.Name}");

                using (StreamReader sr = new StreamReader(path))
                {
                    var recipeX = json.LoadObject(path);
                }

                AllRecipesList.Add(NewRecipe);
            }
            else
            {
                Console.WriteLine("Przepis o podanej nazwie juz istnieje.");
            }
            Folder = FolderStd;
        }
        private void ChooseFolderByKcal()
        {
            if (NewRecipe.Kcal < 80)
            {
                Folder = FolderStd + "LowCaloryfic/";
            }
            else if (NewRecipe.Kcal >= 80 && NewRecipe.Kcal < 120)
            {
                Folder = FolderStd + "MediumCaloryfic/";
            }
            else if (NewRecipe.Kcal >= 120)
            {
                Folder = FolderStd + "HighCaloryfic/";
            }
        }
        public List<Recipe> PrintAndReturnListOfRecipes(string kindOfRecipe)
        {
            GetListFromDataBase(kindOfRecipe);
            foreach (var recipe in AllRecipesList)
            {
                Console.WriteLine($"Przepis na:\n\t{recipe.Name}");
                Console.WriteLine($"Lista składników:");
                foreach (var ingredient in recipe.Ingredients)
                {
                    int tab = 0;
                    if (ingredient.Name.Length < 9)
                    {
                        tab = 4;
                    }
                    if ((ingredient.Name.Length >= 9) && (ingredient.Name.Length < 15))
                    {
                        tab = 3;
                    }
                    if ((ingredient.Name.Length >= 15) && (ingredient.Name.Length < 25))
                    {
                        tab = 2;
                    }
                    if ((ingredient.Name.Length >= 25) && (ingredient.Name.Length < 34))
                    {
                        tab = 1;
                    }

                    Console.Write($"\t{ingredient.Name}");
                    for (int i = 0; i < tab; i++)
                    {
                        Console.Write("\t");
                    }
                    Console.WriteLine($"{ingredient.Weight}");
                }
                Console.WriteLine('\n');
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
            else
            {
                ChooseFolderByKind(kindOfRecipe);
                GetDataFromFolder(Folder);
            }
            Folder = FolderStd;
            return AllRecipesList;
        }
        private void ChooseFolderByKind(string kindOfRecipe)
        {
            if (kindOfRecipe == "Low")
            {
                Folder = FolderStd + "LowCaloryfic/";
            }
            else if (kindOfRecipe == "Medium")
            {
                Folder = FolderStd + "MediumCaloryfic/";
            }
            else if (kindOfRecipe == "High")
            {
                Folder = FolderStd + "HighCaloryfic/";
            }
        }
        private void GetDataFromFolder (string folder)
        {
            Folder = folder;
            foreach (string file in Directory.GetFiles(Folder, "*.json"))
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        JsonManager json = new JsonManager();
                        Recipe recipeX = (Recipe)json.LoadObject(file);
                        if (recipeX != null)
                        {
                            AllRecipesList.Add(recipeX);
                        }
                    }
                }
        }
    }
}
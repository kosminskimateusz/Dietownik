using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dietownik
{
    class RecipeManager
    {
        private string Folder = "./Recipes/";
        private string Extention = ".json";
        private string NewRecipeName { get; set; }
        private Recipe NewRecipe { get; set; }
        private List<Recipe> AllRecipesList { get; set; }
        private List<Ingredient> NewIngredients { get; set; }
        public void Start()     // Working good
        {


            AddRecipe();

            // AddRecipe(recipeName, kcal);
            // AddRecipeToDataBase();
        }


        private void AddRecipe()
        {
            string recipeName = "";

            Console.WriteLine("Type name of recipe:\t");
            recipeName = Console.ReadLine();

            AddIngredients(recipeName);
            NewRecipe = new Recipe(recipeName, NewIngredients);
            AddRecipeToDataBase(NewRecipe);
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
        private void AddRecipeToDataBase(Recipe recipe)
        {
            string path;
            string fileName = recipe.Name;
            path = Folder + fileName + Extention;
            // Create productName.json file, Add all informations (Name, Kcal, Fat etc...) in json format. 
            if (!File.Exists(path))
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };
                byte[] jsonUtf8Bytes;
                jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(recipe, options);
                File.WriteAllBytes(path, jsonUtf8Bytes);
                Console.WriteLine("Dodano nowy przepis do bazy danych.");
                Console.WriteLine($"Nazwa: {recipe.Name}");
                List<Ingredient> skladniki = new List<Ingredient>();
            }
            else
            {
                Console.WriteLine("Przepis o podanej nazwie juz istnieje.");
            }
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
        private List<Product> PrintAndReturnListOfProducts(List<Product> products)
        {
            ProductManager productManager = new ProductManager();
            Console.WriteLine("List of all products:\n");
            products = productManager.AllProducts();
            productManager.PrintProductList(products);
            Console.WriteLine('\n');
            return products;
        }
    }
}
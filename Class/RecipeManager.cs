using System;
using System.Collections.Generic;

namespace Dietownik
{
    class RecipeManager
    {
        private string Folder = "./Recipes/";
        private string Extention = ".json";
        private Recipe NewRecipe { get; set; }
        private List<Recipe> AllRecipesList { get; set; }
        private List<Ingredient> NewIngredients { get; set; }
        public void Start()     // Working good
        {
            string recipeName = "";

            Console.WriteLine("Type name of recipe:\t");
            // recipeName = Console.ReadLine();
            // kcal = Int32.Parse(Console.ReadLine());
            recipeName = "Makaron z twarogiem i cebulą";

            AddIngredients(recipeName);

            // AddRecipe(recipeName, kcal);
            // AddRecipeToDataBase();
        }
        public void AddRecipe(string name, List<Ingredient> ingredients)
        {
            Recipe newRecipe = new Recipe(name, ingredients);
            this.NewRecipe = newRecipe;
            // Dodaj produkt do folderu Products/ nazwa pliku  jak nazwaProduktu.json
        }

        private void AddIngredients(string recipeName)
        {
            bool end = false;
            ProductManager productManager = new ProductManager();
            List<Product> products = new List<Product>();
            NewIngredients = new List<Ingredient>();
            do
            {
                Console.WriteLine("List of all products:");
                products = productManager.AllProducts();
                productManager.PrintProductList(products);
                Console.WriteLine();
                Console.WriteLine("Added ingredients: ");
                foreach (var newIngredient in NewIngredients)
                {
                    Console.WriteLine($"{newIngredient.Name}\t{newIngredient.Weight} g");
                }
                Console.WriteLine();
                Console.WriteLine($"Add ingredients to {recipeName}");
                Console.WriteLine("Type name of new ingredient: ");
                string newIngredientName = Console.ReadLine();
                // string newIngredientName = "Marchewka";
                if (newIngredientName == "")
                {
                    end = true;
                }
                else
                {
                    bool productExist = false;
                    foreach (var product in products)
                    {
                        if (product.Name == newIngredientName)
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
            } while (end == false);

            NewRecipe = new Recipe(recipeName, NewIngredients);
        }
    }
}
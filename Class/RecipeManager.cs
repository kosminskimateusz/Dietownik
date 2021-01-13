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
            decimal kcal;
            Console.WriteLine("Type name of recipe:\t");
            // recipeName = Console.ReadLine();
            // kcal = Int32.Parse(Console.ReadLine());
            recipeName = "Makaron z twarogiem i cebulą";

            AddIngredients();

            // AddRecipe(recipeName, kcal);
            // AddRecipeToDataBase();
        }
        public void AddRecipe(string name, List<Ingredient> ingredients)
        {
            Recipe newRecipe = new Recipe(name, ingredients);
            this.NewRecipe = newRecipe;
            // Dodaj produkt do folderu Products/ nazwa pliku  jak nazwaProduktu.json
        }

        private void AddIngredients()
        {
            bool end = false;
            ProductManager productManager = new ProductManager();
            List<Product> products = new List<Product>();
            NewIngredients = new List<Ingredient>();
            do
            {
                products = productManager.AllProducts();
                productManager.PrintProductList(products);
                Console.WriteLine("Type name of new ingredient: ");
                string newIngredientName = Console.ReadLine();
                // string newIngredientName = "Marchewka";
                if (newIngredientName == "")
                {
                    end = true;
                }
                else
                {
                    Console.WriteLine("Insert weigth of ingredient: ");
                    decimal newIngredientWeigth = decimal.Parse(Console.ReadLine());
                    // decimal newIngredientWeigth = 130;

                    foreach (var product in products)
                    {
                        if (product.Name == newIngredientName)
                        {
                            Ingredient newIngredient = new Ingredient(product.Name, product.Kcal, newIngredientWeigth);
                            NewIngredients.Add(newIngredient);
                        }
                    }
                }
            } while (end == false);
        }
    }
}
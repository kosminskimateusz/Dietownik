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
        public void Start()     // Working good
        {
            string recipeName = "";
            decimal kcal;
            Console.WriteLine("Type name of recipe:\t");
            // recipeName = Console.ReadLine();
            // kcal = Int32.Parse(Console.ReadLine());
            recipeName = "Makaron z twarogiem i cebulą";
            kcal = 18;


            AddRecipe(recipeName, kcal);
            AddRecipeToDataBase();
        }
        public void AddRecipe(string name, List<Ingredient> ingredients)
        {
            // Dodaj produkt do folderu Products/ nazwa pliku  jak nazwaProduktu.json
        }
    }
}
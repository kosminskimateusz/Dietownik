using System;
using System.Collections.Generic;

namespace Dietownik
{
    class Printer
    {

        public void Print(List<Product> products)
        {
            foreach (var product in products)
            {
                Print(product);
            }
        }

        public void Print(Product product)
        {
            string tab = "---- ";
            Console.Write($"Name: {product.Name}\t");

            for (var i = 0; i <= product.Name.Length / 5; i++)
            {
                Console.Write($"\t");
            }
            Console.Write(tab);
            Console.WriteLine($"Kcal: {product.Kcal}");
        }
        public void Print(List<Recipe> recipes)
        {
            foreach (var recipe in recipes)
            {
                Print(recipe);
            }
        }

        public void Print(Recipe recipe)
        {
            Console.WriteLine($"Przepis na:\n\t{recipe.Name}");
            Console.WriteLine($"Lista składników:");
            foreach (var ingredient in recipe.Ingredients)
            {
                Print(ingredient);
            }
            Console.WriteLine($"Suma kalorii/100g: {recipe.Kcal} kcal.");
            Console.WriteLine($"Waga całkowita: {recipe.Weight} g.");
            Console.WriteLine($"Kcal całkowite: {recipe.FullKcal} kcal.");
            Console.WriteLine('\n');
        }

        public void Print(Ingredient ingredient)
        {
            Console.Write($"\t{ingredient.Name}");
            for (var i = 5; i >= ingredient.Name.Length / 3; i--)
            {
                Console.Write($"\t");
            }
            Console.WriteLine($"{ingredient.Weight} g");
        }

    }
}
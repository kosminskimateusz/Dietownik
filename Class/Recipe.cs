using System;
using System.Collections.Generic;

namespace Dietownik
{
    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public decimal Kcal { get; set; }
        private decimal Weight { get; set; }
        public Recipe(string recipeName, List<Ingredient> ingredients)
        {
            this.Name = recipeName;
            this.Ingredients = new List<Ingredient>();
            this.Ingredients = ingredients;
            foreach (var ingredient in ingredients)
            {
                this.Kcal += ingredient.Weight * ingredient.Kcal;
                this.Weight += ingredient.Weight;
            }
            this.Kcal /= Weight;
            this.Kcal = Math.Round(this.Kcal, 2);
        }
        public List<Ingredient> GetListIngredients()
        {
            return Ingredients;
        }
    }
}
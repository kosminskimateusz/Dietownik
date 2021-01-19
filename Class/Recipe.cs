using System.Collections.Generic;

namespace Dietownik
{
    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public Recipe(string recipeName, List<Ingredient> ingredients)
        {
            this.Name = recipeName;
            this.Ingredients = new List<Ingredient>();
            this.Ingredients = ingredients;
        }
        public List<Ingredient> GetListIngredients()
        {
            return Ingredients;
        }
    }
}
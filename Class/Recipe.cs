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

        public void AddIngredient(Product product, decimal weigth)
        {
            Ingredient newIngredient = new Ingredient(product.Name, product.Kcal, weigth);
            Ingredients.Add(newIngredient);
        }
    }
}
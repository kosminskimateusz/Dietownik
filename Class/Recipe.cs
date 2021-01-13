using System.Collections.Generic;

namespace Dietownik
{
    class Recipe
    {
        public string Name { get; set; }
        List<Ingredient> Ingredients = new List<Ingredient>();
        public List<Ingredient> GetListIngredients()
        {
            return Ingredients;
        }

        public void AddIngredient(Product product, decimal weigth)
        {
            Ingredient newIngredient = new Ingredient(product.Name,product.Kcal, weigth);
            Ingredients.Add(newIngredient);
        }
    }
}
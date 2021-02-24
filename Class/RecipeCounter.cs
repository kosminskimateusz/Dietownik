using System;
using System.Collections.Generic;

namespace Dietownik
{
    class RecipeCounter
    {
        private decimal _kcalFactor { get; set; }
        private List<Ingredient> CountedIngredients { get; set; }

        public RecipeCounter()
        {
            CountedIngredients = new List<Ingredient>();
        }
        // !!!
        // POPRAWIĆ LICZENIE SKŁADNIKÓW
        // !!!
        public Recipe Count(Recipe recipe, decimal kcal)
        {
            this._kcalFactor = kcal / recipe.FullKcal;

            return new Recipe(recipe, _kcalFactor);
            // Recipe originRecipe = new Recipe(recipe);
            // foreach (var ingredient in recipe.Ingredients)
            // {
            //     ingredient.Kcal = Math.Round(CountValue(ingredient.Kcal), 2);
            //     ingredient.Fat = Math.Round(CountValue(ingredient.Fat), 2);
            //     ingredient.Carbs = Math.Round(CountValue(ingredient.Carbs), 2);
            //     ingredient.Protein = Math.Round(CountValue(ingredient.Protein), 2);
            //     ingredient.Fiber = Math.Round(CountValue(ingredient.Fiber), 2);
            //     ingredient.Salt = Math.Round(CountValue(ingredient.Salt), 2);
            //     ingredient.Weight = Math.Round(CountValue(ingredient.Weight), 2);
            //     CountedIngredients.Add(new Ingredient(ingredient.Name, ingredient.Kcal, ingredient.Fat, ingredient.Carbs,
            //     ingredient.Protein, ingredient.Fiber, ingredient.Salt, ingredient.Weight));
            // }
            // Recipe newRecipe = new Recipe(recipe.Name, CountedIngredients);
            // newRecipe.Kcal = originRecipe.Kcal;
            // return newRecipe;
        }

        private decimal CountValue(decimal value)
        {
            return (value * _kcalFactor);
        }
    }
}
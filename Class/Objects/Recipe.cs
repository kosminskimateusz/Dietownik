using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dietownik
{
    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public decimal Kcal { get; set; }
        public decimal Fat { get; set; }
        public decimal Carbs { get; set; }
        public decimal Protein { get; set; }
        public decimal Fiber { get; set; }
        public decimal Salt { get; set; }
        public decimal Weight { get; set; }
        public decimal FullKcal { get; set; }

        public Recipe(Recipe recipe)
        {
            this.Name = recipe.Name;
            this.Ingredients = recipe.Ingredients;
            this.Kcal = recipe.Kcal;
            this.Fat = recipe.Fat;
            this.Carbs = recipe.Carbs;
            this.Protein = recipe.Protein;
            this.Fiber = recipe.Fiber;
            this.Salt = recipe.Salt;
            this.Weight = recipe.Weight;
            this.FullKcal = recipe.Kcal * recipe.Weight / 100;
        }

        public Recipe(Recipe recipe, decimal kcalFactor)
        {
            this.Name = recipe.Name;
            this.Ingredients = recipe.Ingredients;
            this.Kcal = recipe.Kcal;
            this.Fat = recipe.Fat * kcalFactor;
            this.Carbs = recipe.Carbs * kcalFactor;
            this.Protein = recipe.Protein * kcalFactor;
            this.Fiber = recipe.Fiber * kcalFactor;
            this.Salt = recipe.Salt * kcalFactor;
            this.Weight = recipe.Weight * kcalFactor;
            this.FullKcal = recipe.Kcal * recipe.Weight / 100;
        }

        [JsonConstructor]
        public Recipe(string recipeName, List<Ingredient> ingredients)
        {
            this.Name = recipeName;
            this.Ingredients = new List<Ingredient>(ingredients);
            for (var ingredient = 0; ingredient < this.Ingredients.Count; ingredient++)
            {
                this.Kcal += (Ingredients[ingredient].Kcal*Ingredients[ingredient].Weight/100);
                this.Weight += Ingredients[ingredient].Weight;
                this.FullKcal = Kcal * Weight / 100;
            }
            this.Kcal = Math.Round(this.Kcal, 2);
            this.Fat = Math.Round(this.Fat, 2);
            this.Carbs = Math.Round(this.Carbs, 2);
            this.Protein = Math.Round(this.Protein, 2);
            this.Fiber = Math.Round(this.Fiber, 2);
            this.Salt = Math.Round(this.Salt, 2);
            this.Weight = Math.Round(this.Weight, 2);
        }

        private decimal GetNutriCount(decimal value, decimal weight)
        {
            return ((value / 100) * weight);
        }
        public List<Ingredient> GetListIngredients()
        {
            return Ingredients;
        }
    }
}
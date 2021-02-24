using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dietownik
{
    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public decimal KcalPerHundredGrams { get; set; }
        public decimal FatPerHundredGrams { get; set; }
        public decimal CarbsPerHundredGrams { get; set; }
        public decimal ProteinPerHundredGrams { get; set; }
        public decimal FiberPerHundredGrams { get; set; }
        public decimal SaltPerHundredGrams { get; set; }
        public decimal Weight { get; set; }
        public decimal FullKcal { get; set; }
        public decimal FullFat { get; set; }
        public decimal FullCarbs { get; set; }
        public decimal FullProtein { get; set; }
        public decimal FullFiber { get; set; }
        public decimal FullSalt { get; set; }

        public Recipe(Recipe recipe)
        {
            this.Name = recipe.Name;
            this.Ingredients = recipe.Ingredients;
            this.KcalPerHundredGrams = recipe.KcalPerHundredGrams;
            this.FatPerHundredGrams = recipe.FatPerHundredGrams;
            this.CarbsPerHundredGrams = recipe.CarbsPerHundredGrams;
            this.ProteinPerHundredGrams = recipe.ProteinPerHundredGrams;
            this.FiberPerHundredGrams = recipe.FiberPerHundredGrams;
            this.SaltPerHundredGrams = recipe.SaltPerHundredGrams;
            this.Weight = recipe.Weight;

            CountFullProps();
        }

        public Recipe(Recipe countRecipe, decimal kcalFactor)
        {
            this.Name = countRecipe.Name;
            this.Ingredients = countRecipe.Ingredients;
            this.KcalPerHundredGrams = countRecipe.KcalPerHundredGrams;
            this.FatPerHundredGrams = countRecipe.FatPerHundredGrams;
            this.CarbsPerHundredGrams = countRecipe.CarbsPerHundredGrams;
            this.ProteinPerHundredGrams = countRecipe.ProteinPerHundredGrams;
            this.FiberPerHundredGrams = countRecipe.FiberPerHundredGrams;
            this.SaltPerHundredGrams = countRecipe.SaltPerHundredGrams;
            // this.Weight = countRecipe.Weight * kcalFactor;
            // Console.WriteLine(KcalPerHundredGrams);
            // Console.WriteLine(kcalFactor);
            // Console.WriteLine(Weight);

            foreach (var ingredient in this.Ingredients)
            {
                ingredient.Weight *= kcalFactor;
                ingredient.Weight = Math.Round(ingredient.Weight);
                this.Weight += ingredient.Weight;
                // Console.WriteLine(ingredient.Weight);
                // Console.WriteLine(this.Weight);
            }

            CountFullProps();
            RoundAllProps();
        }

        private void CountFullProps()
        {
            this.FullKcal = this.KcalPerHundredGrams * this.Weight / 100;
            this.FullFat = this.KcalPerHundredGrams * this.Weight / 100;
            this.FullCarbs = this.KcalPerHundredGrams * this.Weight / 100;
            this.FullProtein = this.KcalPerHundredGrams * this.Weight / 100;
            this.FullFiber = this.KcalPerHundredGrams * this.Weight / 100;
            this.FullSalt = this.KcalPerHundredGrams * this.Weight / 100;
        }

        private void RoundAllProps()
        {
            KcalPerHundredGrams = Math.Round(KcalPerHundredGrams, 2);
            FatPerHundredGrams = Math.Round(FatPerHundredGrams, 2);
            CarbsPerHundredGrams = Math.Round(CarbsPerHundredGrams, 2);
            ProteinPerHundredGrams = Math.Round(ProteinPerHundredGrams, 2);
            FiberPerHundredGrams = Math.Round(FiberPerHundredGrams, 2);
            SaltPerHundredGrams = Math.Round(SaltPerHundredGrams, 2);
            Weight = Math.Round(Weight, 2);
            FullKcal = Math.Round(FullKcal, 2);
            FullFat = Math.Round(FullFat, 2);
            FullCarbs = Math.Round(FullCarbs, 2);
            FullProtein = Math.Round(FullProtein, 2);
            FullFiber = Math.Round(FullFiber, 2);
            FullSalt = Math.Round(FullSalt, 2);
        }


        [JsonConstructor]
        public Recipe(string recipeName, List<Ingredient> ingredients)
        {
            this.Name = recipeName;
            this.Ingredients = new List<Ingredient>(ingredients);
            for (var ingredient = 0; ingredient < this.Ingredients.Count; ingredient++)
            {
                this.KcalPerHundredGrams += (Ingredients[ingredient].KcalPerHundredGrams * Ingredients[ingredient].Weight / 100);
                this.FatPerHundredGrams += (Ingredients[ingredient].FatPerHundredGrams * Ingredients[ingredient].Weight / 100);
                this.CarbsPerHundredGrams += (Ingredients[ingredient].CarbsPerHundredGrams * Ingredients[ingredient].Weight / 100);
                this.ProteinPerHundredGrams += (Ingredients[ingredient].ProteinsPerHundredGrams * Ingredients[ingredient].Weight / 100);
                this.FiberPerHundredGrams += (Ingredients[ingredient].FiberPerHundredGrams * Ingredients[ingredient].Weight / 100);
                this.SaltPerHundredGrams += (Ingredients[ingredient].SaltPerHundredGrams * Ingredients[ingredient].Weight / 100);
                this.Weight += Ingredients[ingredient].Weight;
            }
            this.KcalPerHundredGrams = Math.Round((this.KcalPerHundredGrams / this.Weight * 100), 2);
            this.FullKcal = KcalPerHundredGrams * Weight / 100;
            this.FatPerHundredGrams = Math.Round(this.FatPerHundredGrams, 2);
            this.CarbsPerHundredGrams = Math.Round(this.CarbsPerHundredGrams, 2);
            this.ProteinPerHundredGrams = Math.Round(this.ProteinPerHundredGrams, 2);
            this.FiberPerHundredGrams = Math.Round(this.FiberPerHundredGrams, 2);
            this.SaltPerHundredGrams = Math.Round(this.SaltPerHundredGrams, 2);
            this.Weight = Math.Round(this.Weight, 2);
        }

        public List<Ingredient> GetListIngredients()
        {

            return Ingredients;
        }
    }
}
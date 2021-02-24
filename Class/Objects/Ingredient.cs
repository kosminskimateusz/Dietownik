using System;
using Newtonsoft.Json;

namespace Dietownik
{
    class Ingredient : Product
    {
        public decimal Weight { get; set; }

        public Ingredient(string name, decimal kcal, decimal weight) :
            base(name, kcal)
        {
            this.Weight = weight;
        }

        public Ingredient(string name, decimal kcal, decimal fat, decimal carbs, decimal protein, decimal weight) :
            base(name, kcal, fat, carbs, protein)
        {
            this.Weight = weight;
        }

        public Ingredient(string name, decimal kcal, decimal fat, decimal carbs, decimal protein, decimal fibre, decimal weight) :
            base(name, kcal, fat, carbs, protein, fibre)
        {
            this.Weight = weight;
        }

        [JsonConstructor]
        public Ingredient(string name, decimal kcal, decimal fat, decimal carbs, decimal protein, decimal fibre, decimal salt, decimal weight) :
                  base(name, kcal, fat, carbs, protein, fibre, salt)
        {
            this.Weight = weight;
        }
    }
}
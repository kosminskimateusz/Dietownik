

namespace Dietownik
{
    class RecipeCounter
    {
        private decimal KcalFactor { get; set; }

        public RecipeCounter()
        {

        }
        public void Count(Recipe recipe, decimal kcal)
        {
            this.KcalFactor = kcal / recipe.Kcal;
        }
    }
}
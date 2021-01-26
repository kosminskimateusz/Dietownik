namespace Dietownik
{
    class Ingredient : Product
    {
        public decimal Weight { get; protected set; }

        public Ingredient(string name, decimal kcal, decimal weight) : base(name, kcal)
        {
            this.Weight = weight;
        }
    }
}
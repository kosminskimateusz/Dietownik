namespace Dietownik
{
    class Ingredient : Product
    {
        public decimal Weight { get; set; }

        public Ingredient(string name, decimal weight) : base(name)
        {
            this.Weight = weight;
        }
    }
}
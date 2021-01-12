namespace Dietownik
{
    class Ingredient : Product
    {
        public double Weight { get; set; }

        public Ingredient(string name, double weight) : base(name)
        {
            this.Weight = weight;
        }
    }
}
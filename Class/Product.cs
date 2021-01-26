namespace Dietownik
{
    class Product
    {
        public string Name { get; protected set; }
        public decimal Kcal { get; protected set; }
        public Product(string name, decimal kcal)
        {
            this.Name = name;
            this.Kcal = kcal;
        }
    }
}

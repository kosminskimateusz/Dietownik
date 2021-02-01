namespace Dietownik
{
    class Product
    {
        public string Name { get; set; }
        public decimal Kcal { get; set; }
        
        public Product(string name, decimal kcal)
        {
            this.Name = name;
            this.Kcal = kcal;
        }
    }
}

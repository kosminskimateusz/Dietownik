using Newtonsoft.Json;

namespace Dietownik
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal KcalPerHundredGrams { get; set; }
        public decimal FatPerHundredGrams { get; set; }
        public decimal CarbsPerHundredGrams { get; set; }
        public decimal ProteinPerHundredGrams { get; set; }
        public decimal FiberPerHundredGrams { get; set; }
        public decimal SaltPerHundredGrams { get; set; }

        public Product(string name, decimal kcal)
        {
            this.Name = name;
            this.KcalPerHundredGrams = kcal;
            this.FatPerHundredGrams = 0;
            this.CarbsPerHundredGrams = 0;
            this.ProteinPerHundredGrams = 0;
            this.FiberPerHundredGrams = 0;
            this.SaltPerHundredGrams = 0;
        }

        public Product(string name, decimal kcal, decimal fat, decimal carbs, decimal protein)
        {
            this.Name = name;
            this.KcalPerHundredGrams = kcal;
            this.FatPerHundredGrams = fat;
            this.CarbsPerHundredGrams = carbs;
            this.ProteinPerHundredGrams = protein;
            this.FiberPerHundredGrams = 0;
            this.SaltPerHundredGrams = 0;
        }

        public Product(string name, decimal kcal, decimal fat, decimal carbs, decimal protein, decimal fibre)
        {
            this.Name = name;
            this.KcalPerHundredGrams = kcal;
            this.FatPerHundredGrams = fat;
            this.CarbsPerHundredGrams = carbs;
            this.ProteinPerHundredGrams = protein;
            this.FiberPerHundredGrams = fibre;
            this.SaltPerHundredGrams = 0;
        }

        [JsonConstructor]
        public Product(string name, decimal kcal, decimal fat, decimal carbs, decimal protein, decimal fibre, decimal salt)
        {
            this.Name = name;
            this.KcalPerHundredGrams = kcal;
            this.FatPerHundredGrams = fat;
            this.CarbsPerHundredGrams = carbs;
            this.ProteinPerHundredGrams = protein;
            this.FiberPerHundredGrams = fibre;
            this.SaltPerHundredGrams = salt;
        }
    }
}

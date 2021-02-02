using Newtonsoft.Json;

namespace Dietownik
{
    class Product
    {
        public string Name { get; set; }
        public decimal Kcal { get; set; }
        public decimal Fat { get; set; }
        public decimal Carbs { get; set; }
        public decimal Protein { get; set; }
        public decimal Fiber { get; set; }
        public decimal Salt { get; set; }

        public Product(string name, decimal kcal)
        {
            this.Name = name;
            this.Kcal = kcal;
            this.Fat = 0;
            this.Carbs = 0;
            this.Protein = 0;
            this.Fiber = 0;
            this.Salt = 0;
        }

        public Product(string name, decimal kcal, decimal fat, decimal carbs, decimal protein)
        {
            this.Name = name;
            this.Kcal = kcal;
            this.Fat = fat;
            this.Carbs = carbs;
            this.Protein = protein;
            this.Fiber = 0;
            this.Salt = 0;
        }

        public Product(string name, decimal kcal, decimal fat, decimal carbs, decimal protein, decimal fibre)
        {
            this.Name = name;
            this.Kcal = kcal;
            this.Fat = fat;
            this.Carbs = carbs;
            this.Protein = protein;
            this.Fiber = fibre;
            this.Salt = 0;
        }

        [JsonConstructor]
        public Product(string name, decimal kcal, decimal fat, decimal carbs, decimal protein, decimal fibre, decimal salt)
        {
            this.Name = name;
            this.Kcal = kcal;
            this.Fat = fat;
            this.Carbs = carbs;
            this.Protein = protein;
            this.Fiber = fibre;
            this.Salt = salt;
        }
    }
}

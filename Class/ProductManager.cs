using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;


namespace Dietownik
{
    class ProductManager
    {
        private string Folder = "./Products/";
        private string Extention = ".json";
        private Product NewProduct { get; set; }
        private List<Product> AllProductsList { get; set; }
        public ProductManager()
        {
            AllProductsList = new List<Product>();
        }
        public void Start()     // Working good
        {
            // Pętla ze switchem:
            // Opcja 1 Dodaj nowy produkt do bazy danych
            AddProductToDataBase();
            // Opcja 2 Edytuj produkt w bazie danych
            // Usuń produkt z bazy danych
        }
        private void AddProductToDataBase()     // Working good
        {
            bool fileAdded = false;
            string productName = "";
            string path = "";
            decimal kcal;

            do
            {
                Console.WriteLine("Type name of product:\t");
                productName = Console.ReadLine();
                string fileName = productName;


                fileName = productName;
                path = Folder + fileName + Extention;
                // Create productName.json file, Add all informations (Name, Kcal, Fat etc...) in json format. 
                if (!File.Exists(path))
                {
                    Console.WriteLine("Type kcal in 100g: ");
                    kcal = Decimal.Parse(Console.ReadLine());
                    AddProduct(productName, kcal);

                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true,
                    };
                    byte[] jsonUtf8Bytes;
                    jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(NewProduct, options);
                    File.WriteAllBytes(path, jsonUtf8Bytes);
                    Console.WriteLine("Dodano nowy produkt do bazy danych.");
                    fileAdded = true;
                }
                else
                {
                    Console.WriteLine("Produkt o podanej nazwie juz istnieje.");
                }
            } while (fileAdded == false);
        }
        private void AddProduct(string name, decimal kcal)  // Working good
        {
            NewProduct = new Product(name, kcal);
        }

        public List<Product> AllProducts()  // Working good
        {
            AllProductsList.Clear();
            // var json = File.ReadAllText(Folder + "*.json");
            // var productX = JsonSerializer.Deserialize<Product>(json);
            foreach (string file in Directory.GetFiles(Folder, "*.json"))
            {

                // Product product;
                using (StreamReader sr = new StreamReader(file))
                {
                    var jsonBytes = File.ReadAllBytes(file);
                    var personX = JsonSerializer.Deserialize<Product>(jsonBytes);
                    
                    if (personX != null)
                    {
                        AllProductsList.Add(personX);
                    }
                }
            }
            return AllProductsList;
        }

        public List<Product> SortProductsByKcal()     //Working good
        {
            return AllProducts().OrderBy(product => product.Kcal).ToList();
        }

        public void PrintProductList(List<Product> products)
        {
            var productName = products.Select(product => product.Name).ToList();
            var productKcal = products.Select(product => product.Kcal).ToList();

            for (int i = 0; i < products.Count; i++)
            {
                Console.Write($"Name: {productName[i]}\t");
                string tab = "---- ";

                if (productName[i].Length <= 10)
                {
                    Console.Write($"\t\t{tab}");
                }
                else if ((productName[i].Length > 10) && (productName[i].Length <= 20))
                {
                    Console.Write($"\t{tab}");
                }
                if (productName[i].Length > 20)
                {
                    Console.Write(tab);
                }
                Console.WriteLine($"Kcal: {productKcal[i]}");
            }
        }
        // Dorobić metody: Edytuj produkt, Usuń produkt.
    }
}
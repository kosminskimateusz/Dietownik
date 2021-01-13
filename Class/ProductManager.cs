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
            string productName = "";
            decimal kcal;
            Console.WriteLine("Type name of product:\t");
            // name = Console.ReadLine();
            // kcal = Int32.Parse(Console.ReadLine());
            productName = "Marchewka";
            kcal = 18;

            AddProduct(productName, kcal);
            AddProductToDataBase();
        }
        private void AddProduct(string name, decimal kcal)  // Working good
        {
            // Create product object
            NewProduct = new Product(name, kcal);
            // Call method product.AddProductToDataBase(product);
        }
        private void AddProductToDataBase()     // Working good
        {
            bool fileAdded = false;
            string fileName = "";
            string path = "";
            // string jsonString;

            do
            {
                fileName = NewProduct.Name;
                path = Folder + fileName + Extention;
                // Create productName.json file, Add all informations (Name, Kcal, Fat etc...) in json format. 
                if (!File.Exists(path))
                {
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true,
                    };
                    byte[] jsonUtf8Bytes;
                    jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(NewProduct, options);
                    // jsonString = JsonSerializer.Serialize(NewProduct);
                    File.WriteAllBytes(path, jsonUtf8Bytes);
                    // File.WriteAllText(path, jsonString);
                    Console.WriteLine("Dodano nowy produkt do bazy danych.");
                    fileAdded = true;
                }
                else
                {
                    Console.WriteLine("Produkt o podanej nazwie juz istnieje.");
                    Console.WriteLine("Podaj inna nazwe");
                    NewProduct.Name = Console.ReadLine();
                    NewProduct.Kcal = Int32.Parse(Console.ReadLine());
                }
            } while (fileAdded == false);
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
                Console.Write($"Name: {productName[i]}\t\t");
                if (productName[i].Length <= 10)
                {
                    Console.Write("\t");
                }
                Console.WriteLine($"Kcal: {productKcal[i]}");
            }
        }
        // Dorobić metody: Edytuj produkt, Usuń produkt.
    }
}
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;


namespace Dietownik
{
    class ProductManager
    {
        private string Folder = "./Products/";
        private string Extention = ".json";
        Product NewProduct { get; set; }
        List<Product> AllProductsList = new List<Product>();
        public void Start()
        {
            string name = "";
            Console.WriteLine("Type name of product:\t");
            // name = Console.ReadLine();
            name = "Marchewka";
            AddProduct(name);
            AddProductToDataBase();
        }
        private void AddProduct(string name)
        {
            // Create product object
            NewProduct = new Product(name);
            // Call method product.AddProductToDataBase(product);
        }
        private void AddProductToDataBase()
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
                }
            } while (fileAdded == false);
        }

        public List<Product> AllProducts()
        {
            // var json = File.ReadAllText(Folder + "*.json");
            // var productX = JsonSerializer.Deserialize<Product>(json);
            foreach (string file in Directory.GetFiles(Folder, "*.json"))
            {

                // Product product;
                using (StreamReader sr = new StreamReader(file))
                {
                    var jsonBytes = File.ReadAllBytes(file);
                    var personX = JsonSerializer.Deserialize<Product>(jsonBytes);
                    System.Console.WriteLine(personX.Name);
                    if (personX != null)
                    {
                        AllProductsList.Add(personX);
                    }
                }
            }
            return AllProductsList;
        }
    }
}
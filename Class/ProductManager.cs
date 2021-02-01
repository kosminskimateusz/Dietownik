using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace Dietownik
{
    class ProductManager
    {
        private const string Folder = "./Products/";
        private const string Extention = ".json";
        private Product NewProduct { get; set; }
        private List<Product> AllProductsList { get; set; }
        public ProductManager()
        {
            AllProductsList = new List<Product>();
        }

        public void AddProduct()
        {
            bool fileAdded = false;
            decimal kcal;

            do
            {
                Console.WriteLine("Type name of product:\t");
                string productName = Console.ReadLine();

                string fileName = productName;
                string path = Folder + fileName + Extention;
                // Create productName.json file, Add all informations (Name, Kcal, Fat etc...) in json format. 

                Console.WriteLine("Type kcal in 100g: ");
                kcal = Decimal.Parse(Console.ReadLine());
                NewProduct = new Product(productName, kcal);
                JsonManager json = new JsonManager();
                json.SaveObject(NewProduct, path);
                if (json.SaveSucced())
                {
                    fileAdded = true;
                    // 
                }
                else
                {
                    Console.WriteLine("Try again.");
                }
            } while (fileAdded == false);
        }
        public List<Product> AllProducts()  // Working good
        {
            AllProductsList.Clear();
            JsonManager json = new JsonManager();

            foreach (string file in Directory.GetFiles(Folder, "*.json"))
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    Product product = (Product)json.LoadObject(file);

                    if (product != null)
                    {
                        AllProductsList.Add(product);
                    }
                }
            }
            return AllProductsList;
        }

        public List<Product> SortProducts(string typeSort)     //Working good
        {
            if (typeSort == "Name")
                return AllProducts().OrderBy(product => product.Name).ToList();
            else if (typeSort == "Kcal")
                return AllProducts().OrderBy(product => product.Kcal).ToList();
            else
                return AllProducts().OrderBy(product => product.Name).ToList();
        }

        public void PrintProductList(List<Product> products)
        {
            string tab = "---- ";
            if (products.Count == 0)
            {
                Console.WriteLine("List of products is empty. Add products in menu.");
            }
            foreach (var product in products)
            {
                Console.Write($"Name: {product.Name}\t");

                for (var i = 0; i <= product.Name.Length / 5; i++)
                {
                    Console.Write($"\t");
                }
                Console.Write(tab);
                Console.WriteLine($"Kcal: {product.Kcal}");
            }
        }
        // Dorobić metody: Edytuj produkt, Usuń produkt.
    }
}
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
            string productName = "";
            string path = "";
            decimal kcal;
            JsonManager json = new JsonManager();

            do
            {
                Console.WriteLine("Type name of product:\t");
                productName = Console.ReadLine();

                string fileName = productName;
                path = Folder + fileName + Extention;
                // Create productName.json file, Add all informations (Name, Kcal, Fat etc...) in json format. 

                Console.WriteLine("Type kcal in 100g: ");
                kcal = Decimal.Parse(Console.ReadLine());
                NewProduct = new Product(productName, kcal);
                json.SaveObject(NewProduct, path);
                Console.WriteLine("Dodano nowy produkt do bazy danych.");
                fileAdded = true;
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
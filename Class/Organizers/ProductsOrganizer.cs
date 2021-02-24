using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace Dietownik
{
    class ProductsOrganizer
    {
        private const string Folder = "./Products/";
        private const string Extention = ".json";
        private Product NewProduct { get; set; }
        private List<Product> All { get; set; }

        public ProductsOrganizer()
        {
            this.All = new List<Product>();
        }

        public void Add()
        {
            bool fileAdded = false;

            do
            {
                Console.WriteLine("Type name of product:\t");
                string productName = Console.ReadLine();

                string path = GetPath(productName);
                // Create productName.json file, Add all informations (Name, Kcal, Fat etc...) in json format. 

                Console.WriteLine("Type kcal in 100g: ");
                decimal kcal = Decimal.Parse(Console.ReadLine());
                NewProduct = new Product(productName, kcal);
                JsonManager json = new JsonManager();
                json.SaveObject(NewProduct, path);
                if (json.SaveSucced())
                {
                    fileAdded = true;
                }
                else
                {
                    Console.WriteLine("Try again.");
                }
            } while (fileAdded == false);
        }

        private string GetPath(string fileName)
        {
            return Folder + fileName + Extention;
        }

        public List<Product> GetAll()  // Working good
        {
            All.Clear();
            JsonManager json = new JsonManager();

            foreach (string file in Directory.GetFiles(Folder, "*" + Extention))
            {
                Product product = (Product)json.LoadObject(file);

                if (product != null)
                {
                    All.Add(product);
                }
            }
            return All;
        }

        public List<Product> SortBy(string typeSort)     //Working good
        {
            if (typeSort == "Name")
                return GetAll().OrderBy(product => product.Name).ToList();
            else if (typeSort == "Kcal")
                return GetAll().OrderBy(product => product.KcalPerHundredGrams).ToList();
            else
                return GetAll().OrderBy(product => product.Name).ToList();
        }

        public void Print()
        {
            this.All = GetAll();
            if (All.Count == 0)
                Console.WriteLine("List of products is empty. Add products in menu.");
            Printer printer = new Printer();
            printer.Print(All);
        }
        // Dorobić metody: Edytuj produkt, Usuń produkt.
    }
}
using System;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace Dietownik
{
    class JsonManager
    {
        private string Path { get; set; }
        public JsonManager()
        {
            CheckDirecotrys();
        }
        private void CheckDirecotrys()
        {
            string folderPath = "";
            bool productsExists = false;
            bool recipesExists = false;

            if (Directory.Exists("./Products/"))
            {
                productsExists = true;
            }
            else if ((Directory.Exists("./Recipes/") && Directory.Exists("./Recipes/*Caloryfic/")))
            {
                recipesExists = true;
            }

            if (productsExists == false)
            {
                folderPath = "./Products";
                Directory.CreateDirectory(folderPath);
            }
            if (recipesExists == false)
            {
                folderPath = "./Recipes";
                Directory.CreateDirectory(folderPath);
                folderPath = "./Recipes/HighCaloryfic";
                Directory.CreateDirectory(folderPath);
                folderPath = "./Recipes/LowCaloryfic";
                Directory.CreateDirectory(folderPath);
                folderPath = "./Recipes/MediumCaloryfic";
                Directory.CreateDirectory(folderPath);
            }
        }
        public void SaveObject(object dataObject, string path)
        {
            this.Path = path;
            // Console.WriteLine(dataObject.GetType());
            string jsonString;
            jsonString = JsonConvert.SerializeObject(dataObject, Formatting.Indented);

            if (!File.Exists(path))
            {
                CheckDirecotrys();

                File.WriteAllText(Path, jsonString);
                // Console.WriteLine("Zapisano bajty");
            }
            else
            {
                if (dataObject.GetType().ToString().Contains("Product"))
                {
                    Console.WriteLine("Produkt istnieje. Czy nadpisać produkt? (y/n)");
                }
                if (dataObject.GetType().ToString().Contains("Recipe"))
                {
                    Console.WriteLine("Przepis istnieje. Czy nadpisać przepis? (y/n)");
                }
                string overFileString = Console.ReadLine();
                if (overFileString == "y" || overFileString == "Y")
                {
                    File.WriteAllText(path, jsonString);
                    // Console.WriteLine("Nadpisano");
                }
                else if (overFileString == "n" || overFileString == "N")
                {
                    Console.WriteLine("Nie nadpisano.");
                }
            }
        }
        public object LoadObject(string path)
        {
            CheckDirecotrys();
            var jsonString = File.ReadAllText(path);
            object dataObject = null;
            if (path.Contains("Recipes"))
            {
                dataObject = JsonConvert.DeserializeObject<Recipe>(jsonString);
            }
            if (path.Contains("Products"))
            {
                dataObject = JsonConvert.DeserializeObject<Product>(jsonString);
            }
            return dataObject;
        }
    }
}
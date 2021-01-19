using System;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace Dietownik
{
    class JsonManager
    {
        public void SaveObject(object dataObject, string path)
        {
            Console.WriteLine(dataObject.GetType());
            string jsonString;
            jsonString = JsonConvert.SerializeObject(dataObject, Formatting.Indented);

            if (!File.Exists(path))
            {
                File.WriteAllText(path, jsonString);
                // Console.WriteLine("Zapisano bajty");
            }
            else
            {
                if (dataObject.GetType().ToString() == "Product")
                {
                    Console.WriteLine("Produkt istnieje. Czy nadpisać produkt? (y/n)");
                }
                if (dataObject.GetType().ToString() == "Recipe")
                {
                    Console.WriteLine("Przepis istnieje. Czy nadpisać przepis? (y/n)");
                }
                string overFileString = Console.ReadLine();
                if (overFileString == "y" || overFileString == "Y")
                {
                    File.WriteAllText(path, jsonString);
                    Console.WriteLine("Nadpisano");
                }
                else if (overFileString == "n" || overFileString == "N")
                {
                    Console.WriteLine("Nie nadpisano.");
                }
            }
        }
        public object LoadObject(string path)
        {
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
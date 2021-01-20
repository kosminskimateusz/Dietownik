using System;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace Dietownik
{
    class JsonManager
    {
        private string Path { get; set; }
        public void SaveObject(object dataObject, string path)
        {
            this.Path = path;
            Console.WriteLine(dataObject.GetType());
            string jsonString;
            jsonString = JsonConvert.SerializeObject(dataObject, Formatting.Indented);

            if (!File.Exists(path))
            {
                bool exists = false;
                string[] pathSplitted = path.Split('/');
                foreach (var line in pathSplitted)
                {
                    if (Directory.Exists("./Products/"))
                    {
                        exists = true;
                    }
                    else if ((Directory.Exists("./Recipes/") && Directory.Exists("./Recipes/Caloryfic/")))
                    {
                        exists = true;
                    }

                }
                if (exists == false)
                {
                    string folderPath = "";
                    folderPath += ".";
                    for (int i = 0; i < (pathSplitted.Length - 1); i++)
                    {
                        folderPath += "/";
                        folderPath += pathSplitted[i];
                    }
                    Directory.CreateDirectory(folderPath);
                }
                File.WriteAllText(Path, jsonString);
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
using System;
using Newtonsoft.Json;
using System.IO;

namespace Dietownik
{
    class JsonManager
    {
        public void SaveToJson(object dataObject, string path)
        {
            // var options = new JsonSerializerOptions
            // {
            //     WriteIndented = true,
            //     IncludeFields = true,
            // };

            string jsonString;
            jsonString = JsonConvert.SerializeObject(dataObject, Formatting.Indented);

            if (!File.Exists(path))
            {
                File.WriteAllText(path, jsonString);
                Console.WriteLine("Zapisano bajty");
            }
            else
            {
                File.WriteAllText(path, jsonString);
                Console.WriteLine("Nadpisano bajty");
            }
        }

        public Product LoadProductFromJson(string path)
        {
            var jsonString = File.ReadAllText(path);
            var dataObject = JsonConvert.DeserializeObject<Product>(jsonString);
            return dataObject;
        }
        public Recipe LoadRecipeFromJson(string path)
        {
            var jsonString = File.ReadAllText(path);
            var dataObject = JsonConvert.DeserializeObject<Recipe>(jsonString);
            return dataObject;
        }
    }
}
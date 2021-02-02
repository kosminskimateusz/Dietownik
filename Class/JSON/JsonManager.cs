using System;
using System.Text;
using Newtonsoft.Json;
using System.IO;


namespace Dietownik
{
    class JsonManager
    {
        private object DataObject { get; set; }
        private String[] _paths = {
                "./Products",
                "./Recipes",
                "./Recipes/HighCaloryfic",
                "./Recipes/LowCaloryfic",
                "./Recipes/MediumCaloryfic"
            };
        private bool _saved = false;

        public JsonManager()
        {
            CreateNonexistentDirectories();
        }

        public void SaveObject(object dataObject, string path)
        {
            this.DataObject = dataObject;
            // Console.WriteLine(dataObject.GetType());
            string jsonString = JsonConvert.SerializeObject(DataObject, Formatting.Indented);

            if (!File.Exists(path))
            {
                CreateNonexistentDirectories();
                File.WriteAllText(path, jsonString);
                Console.WriteLine($"{dataObject.GetType().ToString().Split(".")[1]}\tadded.\n");
                _saved = true;
            }
            else
            {
                AskToOverride();
                if (ConfirmFromUser())
                {
                    File.WriteAllText(path, jsonString);
                    Console.WriteLine($"{dataObject.GetType().ToString().Split(".")[1]}\toverrided.\n");
                    _saved = true;
                }
                else
                {
                    // Console.WriteLine("Nie nadpisano.");
                    _saved = false;
                }
            }
            DataObject = null;
        }

        public bool SaveSucced()
        {
            return _saved;
        }

        public object LoadObject(string path)
        {
            DataObject = null;
            CreateNonexistentDirectories();
            if (path.Contains("Recipes"))
            {
                DataObject = JsonConvert.DeserializeObject<Recipe>(File.ReadAllText(path));
            }
            if (path.Contains("Products"))
            {
                DataObject = JsonConvert.DeserializeObject<Product>(File.ReadAllText(path));
            }
            return DataObject;
        }

        private void CreateNonexistentDirectories()
        {
            foreach (var path in _paths)
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
        }

        private void AskToOverride()
        {
            string typeString = DataObject.GetType().ToString().Split(".")[1];
            Console.WriteLine($"{typeString} exist. Override {typeString.ToLower()}? (y/n)?");
        }

        private bool ConfirmFromUser()
        {
            bool confirm = false, correctInput;
            do
            {
                string userInput = Console.ReadLine();
                if (userInput == "y" || userInput == "Y")
                {
                    confirm = true;
                    correctInput = true;
                }
                else if (userInput == "n" || userInput == "N")
                {
                    confirm = false;
                    correctInput = true;
                }
                else
                {
                    correctInput = false;
                    Console.WriteLine("Wrong input. Try again. (y/n)");
                }
            } while (!correctInput);

            return confirm;
        }

    }
}
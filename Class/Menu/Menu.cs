using System;

namespace Dietownik
{
    abstract class Menu
    {
        protected string[] Options { get; set; }

        public void Start()
        {
            int option = 0;
            do
            {
                Console.Clear();
                PrintOptions();
                ChooseOptions(ref option);
            } while (option != 0);
        }

        private void PrintOptions()
        {
            int optionNumber = 1;
            int exitNumber = Options.Length;
            Console.WriteLine("Choose option:\n");
            foreach (var option in Options)
            {
                if (optionNumber != exitNumber)
                {
                    Console.WriteLine($"{optionNumber}. {option}");
                }
                else
                {
                    optionNumber = 0;
                    Console.WriteLine($"\n{optionNumber}. {option}");
                }
                optionNumber++;
            }

        }

        protected abstract void ChooseOptions(ref int option);
    }
}
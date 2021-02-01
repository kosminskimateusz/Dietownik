using System;
using System.Collections.Generic;
using System.Linq;

namespace Dietownik
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new MainMenu();
            menu.Start();
            // menu = new RecipesMenu();
            // menu.Start();
        }
    }
}

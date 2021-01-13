using System;
using System.Linq;
using System.Collections.Generic;

namespace Dietownik
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager();
            // productManager.Start();
            var products = productManager.SortProductsByKcal();
            productManager.PrintProductList(products);
            System.Console.WriteLine('\n');
            products = productManager.AllProducts();
            productManager.PrintProductList(products);
        }
    }
}

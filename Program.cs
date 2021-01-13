using System;
using System.Linq;

namespace Dietownik
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager();
            productManager.Start();
            var listProducts = productManager.AllProducts();

            // var products = listProducts.Select(product => product.Name).ToList();
            // var products = listProducts.Where(product => product != null).Select(product => product).ToList();

            // foreach (var product in products)
            // {
            //     System.Console.WriteLine(product.Name);
            // }
        }
    }
}

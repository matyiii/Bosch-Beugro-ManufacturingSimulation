using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            DbHelper dbHelper = new DbHelper();
            dbHelper.GetProducts();
            IEnumerable<Products> productsList = dbHelper.GetRandomProducts(10);
            foreach (Products product in productsList)
                Console.WriteLine(product.Id);
            Console.ReadLine();
        }
    }
}

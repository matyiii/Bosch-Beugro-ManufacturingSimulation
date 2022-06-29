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
            DbHelper dbHelper = new DbHelper();
            dbHelper.GetProducts();
            IEnumerable<Products> productsList = dbHelper.GetRandomProducts(10);
            List<Production> productionsList = new List<Production>();
            foreach (Products product in productsList)
            {
                productionsList.Add(new Production(product.Id, product.Id));
            }
            foreach (Production production in productionsList)
            {
                Console.WriteLine($"Pcb id:{production.Id}," +
                    $"\nquantity: {production.Quantity}," +
                    $"\nstartDate:{production.StartDate:yyyy-mm-dd hh:mm}," +
                    $"\nendDate:{production.EndDate:yyyy-mm-dd hh:mm}\n");
            }
            Console.ReadLine();
        }
    }
}

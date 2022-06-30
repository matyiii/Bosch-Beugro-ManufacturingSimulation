using System;
using System.Collections.Generic;
using System.IO;
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
                Console.WriteLine($"Pcb id: {production.Id}," +
                    $"\nquantity: {production.Quantity}," +
                    $"\nstartDate: {production.StartDate}," +
                    $"\nendDate: {production.EndDate}\n");
            }
            using(TextWriter tw = new StreamWriter("puffer.txt"))
            {
                tw.WriteLine("(pcb_id|quantity|startDate|endDate)");
                foreach (Production production in productionsList)
                {
                    tw.WriteLine(production.ToString());
                }
            }
            Puffer puffer = new Puffer();
            puffer.ReadFromPuffer();
            puffer.UploadToProductionTable();
            Console.ReadLine();
        }
    }
}

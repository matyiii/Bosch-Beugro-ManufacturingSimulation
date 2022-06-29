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
            Console.ReadLine();
        }
    }
}

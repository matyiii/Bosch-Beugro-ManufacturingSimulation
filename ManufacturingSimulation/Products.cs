using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingSimulation
{
    internal class Products
    {
        public int Id { get; set; }
        public string Pcb { get; set; }

        public Products(int id, string pcb)
        {
            Id = id;
            Pcb = pcb;
        }
    }
}

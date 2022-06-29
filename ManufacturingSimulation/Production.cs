using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingSimulation
{
    internal class Production
    {
        public int Id { get; set; }
        public int PcbId { get; set; }

        public string Quantity { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Production(int id, int pcbId, string quantity, DateTime startDate, DateTime endDate)
        {
            Id = id;
            PcbId = pcbId;
            Quantity = quantity;
            StartDate = startDate;
            EndDate = endDate;  
        }
    }
}

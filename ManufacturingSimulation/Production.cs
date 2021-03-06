using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingSimulation
{
    internal class Production
    {
        static readonly Random random = new Random();
        public int Id { get; set; }
        public int PcbId { get; set; }

        private string quantity;
        public string Quantity {
            get
            { 
                return quantity;
            }
            private set
            {
                quantity = random.Next(1, 1001).ToString();
            }
        }

        private DateTime startDate;

        public DateTime StartDate {
            get
            {
                return startDate;
            }
            private set
            {
                DateTime time1= DateTime.Now;
                DateTime time2 = time1.Subtract(new TimeSpan(0, random.Next(10, 21), 0));
                startDate = time2;
            }
            
        }

        private DateTime endDate;

        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            private set
            {
                value = DateTime.Now.Add(new TimeSpan(0, -random.Next(1, 16), 0));
                while (startDate>value)
                    value = DateTime.Now.Add(new TimeSpan(0, -random.Next(1, 16), 0));
                endDate = value;
            }
                
        }

        public Production(int id, int pcbId)
        {
            Id = id;
            PcbId = pcbId;
            Quantity = quantity;
            StartDate = startDate;
            EndDate = endDate;  
        }

        public override string ToString()
        {
            return string.Format($"{Id}|{quantity}|{startDate:yyyy-mm-dd hh:mm}|{endDate:yyyy-mm-dd hh:mm}");
        }
    }
}

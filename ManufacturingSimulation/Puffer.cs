using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingSimulation
{
    internal class Puffer
    {
        public void ReadFromPuffer()
        {
            StreamReader file = new StreamReader("puffer.txt");
            List<Production> productionList = new List<Production>();
            int lineCounter = 0;
            int lineToDelete = 4;
            file.ReadLine();
            while (!file.EndOfStream)
            {
                try
                {
                    lineCounter++;
                    if (lineCounter == lineToDelete)
                        continue;
                    string[] data = file.ReadLine().Split('|');
                    Production production = new Production(int.Parse(data[0]), int.Parse(data[0]));
                    productionList.Add(production);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            file.Close();
            if(productionList.Any(x=>x.PcbId == 4))
            {
                productionList.RemoveAll(x => x.PcbId == 4);
                Console.WriteLine($"Pcb_Id:4 was found, and deleted.");
            }
        }
    }
}

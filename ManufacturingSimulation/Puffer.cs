using MySql.Data.MySqlClient;
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
        List<Production> productionList = new List<Production>();
        public void ReadFromPuffer()
        {
            StreamReader file = new StreamReader("puffer.txt");
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

        public void UploadToProductionTable()
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=cs_beugro;Uid=root;Pwd=;"))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                foreach (Production production in productionList)
                {
                    command.CommandText = $"INSERT INTO production (pcb_id,quantity,startDate,endDate) VALUES ({production.PcbId},{production.Quantity},'{production.StartDate}','{production.EndDate}')";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

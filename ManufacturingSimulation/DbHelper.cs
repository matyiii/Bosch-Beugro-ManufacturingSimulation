using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingSimulation
{
    internal class DbHelper
    {
        public void GetProducts()
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=cs_beugro;Uid=root;Pwd=;"))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT id,pcb FROM products";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        Console.WriteLine($"{reader.GetInt32(0)} | {reader.GetString(1)}");
                }
            }
        }
    }
}

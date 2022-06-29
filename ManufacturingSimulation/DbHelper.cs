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
        private List<Products> productsList = new List<Products>();
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
                    {
                        //Console.WriteLine($"{reader.GetInt32(0)} | {reader.GetString(1)}");
                        productsList.Add(new Products(reader.GetInt32(0), reader.GetString(1)));
                    }
                }
            }
        }

        public IEnumerable<Products> GetRandomProducts(int amount)
        {
            if (amount > productsList.Count)
                throw new Exception("Amount cannot be more than items in the table");
            Random rnd = new Random();
            List<Products> randomProducts = productsList.
                OrderBy(x => rnd.Next(0,productsList.Count)).
                Take(amount).
                ToList();
            return randomProducts;
        }
    }
}

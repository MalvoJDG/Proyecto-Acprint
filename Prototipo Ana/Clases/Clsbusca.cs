using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Parcial2v2
{
    internal class Clsbusca
    {
        public class cnn
        {
            public static string connectionString = $"Server=bpidrba1peeyn1ijd9pi-mysql.services.clever-cloud.com; Port=3306; Database=bpidrba1peeyn1ijd9pi; User ID=ugm9bv3keiasro4g; Password=k4ElAAuFR49DikfeZUiq; SslMode=Preferred;";
        }


        public class Item
        {
            public string Name { get; set; }
            public int Value { get; set; }

            public Item(string _name, int _value)
            {
                Name = _name;
                Value = _value;
            }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}

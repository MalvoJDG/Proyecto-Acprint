using MySql.Data.MySqlClient;
using System.Data;

namespace Prototipo_Ana
{
    public class cnn
    {
        // Reemplaza los valores con la información de tu base de datos en la nube
        private static string server = "bpidrba1peeyn1ijd9pi-mysql.services.clever-cloud.com";
        private static string database = "bpidrba1peeyn1ijd9pi";
        private static string userID = "ugm9bv3keiasro4g";
        private static string password = "k4ElAAuFR49DikfeZUiq";
        private static string connectionString = $"Server={server};Database={database};Uid={userID};Pwd={password};";

        public static MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(connectionString);
        }
        public static MySqlCommand CrearComando(string consulta, MySqlConnection conexion)
        {
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            return comando;
        }
    }
}

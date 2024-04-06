using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Prototipo_Ana
{
     class Modelo
    {
        public int Registro(Usuarios usuario)
        {
            MySqlConnection cnx = cnn.ObtenerConexion();
            cnx.Open();

            string query = "Insert into Usuarios(Nombre, Usuario, Contraseña, Tipo_Usuario)" +
                            "values(@Nombre, @Usuario, @Contraseña, @Tipo_Usuario)";

            MySqlCommand miquery = new MySqlCommand(query, cnx);

            miquery.Parameters.AddWithValue("@Nombre", usuario.Nombre1);
            miquery.Parameters.AddWithValue("@Usuario", usuario.Usuario1);
            miquery.Parameters.AddWithValue("@Contraseña", usuario.Contraseña1);
            miquery.Parameters.AddWithValue("@Tipo_Usuario", usuario.Tipo_Usuario1);

            int rows = miquery.ExecuteNonQuery();

            return rows;

        }

        public bool existeUsuario(string usuario)
        {

            MySqlDataReader reader;
            MySqlConnection cnx = cnn.ObtenerConexion();
            cnx.Open();

            string query = "select id from Usuarios where Usuario like @Usuario";

            MySqlCommand miquery = new MySqlCommand(query, cnx);

            miquery.Parameters.AddWithValue("@Usuario", usuario);

            reader = miquery.ExecuteReader();

            if (reader.HasRows)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public Usuarios PorUsuario(string usuario)
        {

            MySqlDataReader reader;
            MySqlConnection cnx = cnn.ObtenerConexion();
            cnx.Open();

            string query = "select id, Contraseña, Nombre, Tipo_Usuario from Usuarios where Usuario like @Usuario";

            MySqlCommand miquery = new MySqlCommand(query, cnx);

            miquery.Parameters.AddWithValue("@Usuario", usuario);

            reader = miquery.ExecuteReader();

            Usuarios usr = null;

            while (reader.Read())
            {
                usr = new Usuarios();
                usr.Id = int.Parse(reader["id"].ToString());
                usr.Contraseña1 = reader["Contraseña"].ToString();
                usr.Nombre1 = reader["Nombre"].ToString();
                usr.Tipo_Usuario1 = int.Parse(reader["Tipo_Usuario"].ToString());
            }

            return usr;
        }

    }
}

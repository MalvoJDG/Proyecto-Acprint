using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Prototipo_Ana.Forms;

namespace Prototipo_Ana
{
     class Controlador
    {
        public string ctrRegistro(Usuarios usuario)
        {
            Modelo modelo = new Modelo();
            string respuesta = "";

            if(string.IsNullOrEmpty(usuario.Nombre1) || string.IsNullOrEmpty(usuario.Usuario1) ||
                string.IsNullOrEmpty(usuario.Contraseña1) || string.IsNullOrEmpty(usuario.ConPaswword1)
                || usuario.Tipo_Usuario1 < 0)
            {
                respuesta = "Debe completar todos los campos";
            }

            else
            {
                if (usuario.Contraseña1 == usuario.ConPaswword1)
                {
                    if (modelo.existeUsuario(usuario.Usuario1))
                    {
                        respuesta = "Este usuario ya existe";
                    }
                    else
                    {
                        usuario.Contraseña1 = generarSha1(usuario.Contraseña1);
                        UsuariosR frm = new UsuariosR();

                        usuario.Tipo_Usuario1 = usuario.Tipo_Usuario1;
                        modelo.Registro(usuario);
                    }
                }
                else
                {
                    respuesta = "Las contraseñas no coinciden";
                }
            }

            return respuesta;
        }

        public string ctrLogin(string usuario, string contraseña)
        {
            Modelo modelo = new Modelo();
            string respuesta = "";
            Usuarios datosusuario = null;

            if(string.IsNullOrEmpty (usuario) || string.IsNullOrEmpty(contraseña))
            {
                respuesta = "Debe completar todos los campos";            
            }
            else
            {
                datosusuario = modelo.PorUsuario(usuario);

                if(datosusuario == null)
                {
                    respuesta = "Este usuario no existe";
                }
                else
                {
                    if(datosusuario.Contraseña1 != generarSha1(contraseña))
                    {
                        respuesta = "El usuario y/o contraseña no coinciden";
                    }
                    else
                    {
                        Session.id = datosusuario.Id;
                        Session.Nombre = datosusuario.Nombre1;
                        Session.Usuario = datosusuario.Usuario1;
                        Session.Tipo_usuario = datosusuario.Tipo_Usuario1;
                    }
                }             
            }
            return respuesta;
        }

        public string generarSha1(string cadena)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] data = Encoding.UTF8.GetBytes(cadena);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();

            result = sha.ComputeHash(data);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));

            }
            return sb.ToString();

        }
    }
}

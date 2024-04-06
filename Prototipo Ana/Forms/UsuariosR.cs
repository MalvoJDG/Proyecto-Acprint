using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototipo_Ana.Forms
{
    public partial class UsuariosR : Form
    {
        public UsuariosR()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            usuario.Nombre1 = txtNombre.Text;
            usuario.Usuario1 = txtUsuario.Text;
            usuario.Contraseña1 = txtContraseña.Text;
            usuario.ConPaswword1 = txtCcontraseña.Text;
            if(cbmTipo.Text == "General")
            {
                usuario.Tipo_Usuario1 = 2;
            }
            else if(cbmTipo.Text == "Admin")
            {
                usuario.Tipo_Usuario1 = 1;
            }
            try
            {


                Controlador control = new Controlador();
                string respuesta = control.ctrRegistro(usuario);

                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Usuario Registrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ha ocurrido un error:{ex}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

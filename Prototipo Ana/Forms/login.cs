using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.IO.Compression;

namespace Prototipo_Ana.Forms
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            txtUsuario.Text = "Usuario";
            txtPassword.Text = "Contraseña";

            WebClient webClient = new WebClient();

            // Obtener la información de la última versión desde GitHub Releases
            string latestVersionUrl = "https://api.github.com/repos/tu_usuario/tu_repositorio/releases/latest";
            string latestVersion = webClient.DownloadString(latestVersionUrl);

            if (!latestVersion.Contains("2.0.2"))
            {
                if (MessageBox.Show("¡Nueva actualización disponible! Debe actualizar para poder acceder al programa", "Actualización", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        WebClient client = new WebClient();
                        string downloadUrl = "https://github.com/tu_usuario/tu_repositorio/releases/latest/download/CodenexSetup.zip";
                        string zipPath = @".\CodenexSetup.zip";
                        client.DownloadFile(downloadUrl, zipPath);

                        string extractPath = @".\";
                        ZipFile.ExtractToDirectory(zipPath, extractPath);

                        // Ejecutar el instalador
                        Process.Start(Path.Combine(extractPath, "CodenexSetup.msi"));

                        // Cerrar la aplicación actual
                        Application.Exit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void txtUsuario_MouseEnter(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
            }
        }

        private void txtUsuario_MouseLeave(object sender, EventArgs e)
        {
             if (txtUsuario.Text == string.Empty || txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "Usuario";
            }
        }

        private void txtPassword_MouseLeave(object sender, EventArgs e)
        {
            if (txtPassword.Text == string.Empty || txtPassword.Text == "Contraseña")
            {
                txtPassword.isPassword = false;
                txtPassword.Text = "Contraseña";
               
            }
        }

        private void txtPassword_MouseEnter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Contraseña")
            {
                txtPassword.Text = "";
                txtPassword.isPassword = true;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Contraseña")
            {
                txtPassword.Text = "";
                txtPassword.isPassword = true;
            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnincio.PerformClick();
            }
        }

        private void btnincio_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;

            try
            {
                Controlador ctrl = new Controlador();
                string respuesta = ctrl.ctrLogin(usuario, password);

                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta,"aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    
                }
                else
                {
                    
                    Form1 frm = new Form1();
                    frm.Visible = true;

                    frm.FormClosed += (s, args) => this.Close();
                    this.Hide();

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ha ocurrido un error{ex}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

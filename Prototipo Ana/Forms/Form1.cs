using Prototipo_Ana.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototipo_Ana
{
    public partial class Form1 : Form
    {
        int Tipo_Usuario;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            abrirformhija(new Inicio());
            btnDashboard.Size = new Size(230, 39);
            btnCliente.Size = new Size(230, 39);
            btnVentas.Size = new Size(230, 39);
            btnNCF.Size = new Size(230, 39);
            btnFacturas.Size = new Size(230, 39);
            btnMateriales.Size = new Size(230, 39);
            btnUsuario.Size = new Size(230, 39);
            //Cosas del usuario
            USUARIONAME.Text = Session.Nombre;
            Tipo_Usuario = Session.Tipo_usuario;

            if(Tipo_Usuario == 1)
            {
                btnUsuario.Visible = true;
            }
            else
            {
                btnUsuario.Visible = false;
            }
        }

        public void abrirformhija(object formhija)
        {
            if(this.bunifuPanel4.Controls.Count > 0)
            
                this.bunifuPanel4.Controls.RemoveAt(0);
                Form fh = formhija as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.bunifuPanel4.Controls.Add(fh);
                this.bunifuPanel4.Tag = fh;

                fh.Show();
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            abrirformhija(new Inicio());
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            abrirformhija(new Inicio());
        }

        private void btnCliente_Click_1(object sender, EventArgs e)
        {
            abrirformhija(new Clientes());
        }

        private void btnVentas_Click_1(object sender, EventArgs e)
        {
            abrirformhija(new Ventas());
        }

        private void btnNCF_Click(object sender, EventArgs e)
        {
            abrirformhija(new Fiscal());
        }

        private void btnMateriales_Click_1(object sender, EventArgs e)
        {
            abrirformhija(new Productos());
        }

        private void btnFacturas_Click_1(object sender, EventArgs e)
        {
            abrirformhija(new Facturas());
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            abrirformhija(new UsuariosR());
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

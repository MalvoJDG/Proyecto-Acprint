using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using Dashboard;
using MySql.Data;

using MySql.Data.MySqlClient;
using Prototipo_Ana;


namespace Prototipo_Ana.Forms
{
    public partial class Inicio : Form
    {
        private Dashboard.Dashboard dashboard;
        public Inicio()
        {
            InitializeComponent();
            dashboard = new Dashboard.Dashboard();
            StartDate.Value = DateTime.Today.AddDays(-7);
            EndDate.Value = DateTime.Now;

            
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var refreshData = dashboard.LoadTime(StartDate.Value, EndDate.Value);

            if (refreshData)
            {   

                lblFacturas.Text = dashboard.Facturas.ToString();
                lblTotalIngreso.Text = "$" + dashboard.IngresosTotales.ToString("N2");
                lblTotalNeto.Text = "$" + dashboard.IngresoActual.ToString("N2");

                lblClientes.Text = dashboard.NumClientes.ToString();
                lblMaterial.Text = dashboard.NumMateriales.ToString();
                lblFacturaPendiente.Text = dashboard.Facturas_Pagar.ToString();
                lblDeber.Text = "$" + dashboard.Deber.ToString("N2");

                // Limpiar las series existentes en el gráfico


                // Agregar una nueva serie al gráfico

                // Configurar la serie del gráfico
                chartIngresos.DataSource = dashboard.IngresosList;
                chartIngresos.Series[0].XValueMember = "Fecha";
                chartIngresos.Series[0].YValueMembers = "Total";
                chartIngresos.DataBind();
            }
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            StartDate.Value = DateTime.Today;
            EndDate.Value = DateTime.Now;
            LoadData();
            Customoff();
        }

        private void Customoff()
        {
            StartDate.Visible = false;
            EndDate.Visible = false;
            bunifuSeparator1.Visible = false;
            btnOk.Visible = false;
        }

        private void btn7days_Click(object sender, EventArgs e)
        {
            StartDate.Value = DateTime.Today.AddDays(-7);
            EndDate.Value = DateTime.Now;
            LoadData();
            Customoff();
        }

        private void btn30day_Click(object sender, EventArgs e)
        {
            StartDate.Value = DateTime.Today.AddDays(-30);
            EndDate.Value = DateTime.Now;
            LoadData();
            Customoff();
        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            StartDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            EndDate.Value = DateTime.Now;
            LoadData();
            Customoff();
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            StartDate.Visible = true;
            EndDate.Visible = true;
            btnOk.Visible = true;
            bunifuSeparator1.Visible = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}

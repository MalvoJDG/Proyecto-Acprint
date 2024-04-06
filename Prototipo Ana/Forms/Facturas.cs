using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using MySql.Data.MySqlClient;

namespace Prototipo_Ana.Forms
{
    public partial class Facturas : Form
    {
        public Facturas()
        {
            InitializeComponent();
        }
        private void Facturas_Load(object sender, EventArgs e)
        {
            btnborrar.Visible = false;
            btnConfirmar.Enabled = false;
            btnborrar.Size = new Size(115, 25);
            btnConfirmar.Size = new Size(155, 27);
            CargarHFactura();
            // Establecer color RGB para el encabezado
            Color colorEncabezado = Color.FromArgb(236, 236, 236);
            Color colorLetra = Color.FromArgb(29, 32, 51);
            Color colorSelect = Color.FromArgb(236, 236, 236);
            dtaFactura.ColumnHeadersDefaultCellStyle.BackColor = colorEncabezado;
            dtaFactura.ColumnHeadersDefaultCellStyle.ForeColor = colorLetra;
            dtaFactura.ColumnHeadersDefaultCellStyle.SelectionBackColor = colorSelect;
        }


        private void CargarHFactura()
        {
            // Crear una conexión a la base de datos
            using (MySqlConnection conexion = cnn.ObtenerConexion())
            {
                try
                {
                    // Abrir la conexión
                    conexion.Open();

                    // Consulta SQL para obtener los datos de clientes
                    string consulta = "SELECT * FROM HFacturas;";

                    // Crear un adaptador de datos
                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion))
                    {
                        // Crear un DataSet para almacenar los datos
                        DataSet dataSet = new DataSet();

                        // Llenar el DataSet con los datos de la consulta
                        adaptador.Fill(dataSet, "HFacturas");

                        // Establecer el origen de datos del DataGridView
                        dtaFactura.DataSource = dataSet.Tables["HFacturas"];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos de Facturas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            if (txtFiltro.Text != "")
            {
                dtaFactura.CurrentCell = null;
                foreach (DataGridViewRow row in dtaFactura.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        row.Visible = false;
                    }
                }

                foreach (DataGridViewRow row in dtaFactura.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value != null && cell.Value.ToString().ToUpper().IndexOf(txtFiltro.Text.ToUpper()) >= 0)
                            {
                                row.Visible = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void CargarFacturas()
        {
            try
            {
                using (MySqlConnection conexion = cnn.ObtenerConexion())
                {
                    // Consulta SQL para obtener todos los campos de la tabla Facturas
                    string consulta = "SELECT Facturas.Factura, Facturas.Nombre_Cliente as Nombre, " +
                                      "Facturas.Fecha_Emision as Fecha, Facturas.Detalle, Facturas.Material, " +
                                      "Facturas.Cantidad, Facturas.Monto_Linea as Total_ln, Facturas.ITBIS_Linea, " +
                                      "Facturas.Total as Total " +
                                      "FROM Facturas " +
                                      "INNER JOIN HFacturas ON Facturas.Factura = HFacturas.Factura " +
                                      "WHERE Facturas.Factura = @A0";

                    // Crear un adaptador de datos y un DataSet
                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion))
                    {
                        adaptador.SelectCommand.Parameters.AddWithValue("@A0", dtaFactura.CurrentRow.Cells[0].Value.ToString());

                        DataSet dataSet = new DataSet();
                        // Llenar el DataSet con los datos de la consulta
                        adaptador.Fill(dataSet, "HFacturas");

                        // Establecer el origen de datos del DataGridView
                        dtaFactura.DataSource = dataSet.Tables["HFacturas"];

                        btnborrar.Visible = true;

                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error durante la carga de datos de Facturas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error general: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Actualizar()
        {

            try
            {
                MySqlConnection cnx = cnn.ObtenerConexion();
                cnx.Open();

                string query = "UPDATE HFacturas " +
                               "SET Estado_Pago = @A1 " +
                               "WHERE Factura = @A0";

                MySqlCommand miQuery = new MySqlCommand(query, cnx);

                miQuery.Parameters.AddWithValue("@A1", cbmEstado.Text);
                miQuery.Parameters.AddWithValue("@A0", dtaFactura.CurrentRow.Cells[0].Value.ToString());

                int rows = miQuery.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Estado Actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarHFactura();
                }
                else
                {
                    MessageBox.Show("No se realizaron cambios en la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error al intentar cambiar Estado: {ex.Message}", "Error de conversión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    }

        private void cbmEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Actualizar();
            cbmEstado.SelectedIndex = -1;
            btnConfirmar.Enabled = false;
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            
        }

        private void dtaFactura_DoubleClick_1(object sender, EventArgs e)
        {
            CargarFacturas();
        }

        private void txtFiltro_TextChanged_1(object sender, EventArgs e)
        {
            if (txtFiltro.Text != "")
            {
                dtaFactura.CurrentCell = null;
                foreach (DataGridViewRow row in dtaFactura.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        bool rowVisible = false;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value != null && cell.Value.ToString().ToUpper().IndexOf(txtFiltro.Text.ToUpper()) >= 0)
                            {
                                rowVisible = true;
                                break;
                            }
                        }
                        row.Visible = rowVisible;
                    }
                }
            }
            else
            {
                CargarHFactura();
            }
        }
        private void bunifuVScrollBar2_Scroll(object sender, BunifuVScrollBar.ScrollEventArgs e)
        {
            // Obtiene el número total de filas en el DataGridView
            int totalRows = dtaFactura.Rows.Count + 1 ;

            // Obtiene el número de filas visibles en el DataGridView
            int visibleRows = dtaFactura.DisplayedRowCount(true);

            // Calcula el valor máximo del scrollbar para reflejar el número total de filas
            bunifuVScrollBar2.Maximum = totalRows - visibleRows + 1;

            // Calcula la posición de desplazamiento actual del scrollbar
            int currentScroll = e.Value;

            // Calcula el porcentaje de desplazamiento actual
            double scrollPercentage = (double)currentScroll / bunifuVScrollBar2.Maximum;

            // Calcula la fila correspondiente al porcentaje de desplazamiento actual
            int firstVisibleRow = (int)Math.Floor((totalRows - visibleRows) * scrollPercentage);

            // Establece la primera fila visible en el DataGridView
            dtaFactura.FirstDisplayedScrollingRowIndex = firstVisibleRow;
        }



        private void cbmEstado_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            btnConfirmar.Enabled = true;
        }

        private void btnborrar_Click_1(object sender, EventArgs e)
        {
            CargarHFactura();
            btnborrar.Visible = false;
        }

        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            Actualizar();
            cbmEstado.SelectedIndex = -1;
            btnConfirmar.Enabled = false;
        }
    }
}

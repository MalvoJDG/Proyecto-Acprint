using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Prototipo_Ana.Forms
{
    public partial class Fiscal : Form
    {
        Boolean existe;
        public Fiscal()
        {
            InitializeComponent();

        }

        private void Fiscal_Load(object sender, EventArgs e)
        {   
            // Cargar datagrid
            CargarDatosFiscal();
            // Establecer color RGB para el encabezado
            Color colorEncabezado = Color.FromArgb(236, 236, 236);
            Color colorLetra = Color.FromArgb(29, 32, 51);
            Color colorSelect = Color.FromArgb(236, 236, 236);
            dtaFiscal.ColumnHeadersDefaultCellStyle.BackColor = colorEncabezado;
            dtaFiscal.ColumnHeadersDefaultCellStyle.ForeColor = colorLetra;
            dtaFiscal.ColumnHeadersDefaultCellStyle.SelectionBackColor = colorSelect;
            // Quitar boton
            btnborrar.Visible = false;
            // Ajustar tamaño de botones
            btnborrar.Visible = false;
            btnlimpiar.Size = new Size(120, 24);
            btnborrar.Size = new Size(120, 24);
            btnEditar.Size = new Size(120, 24);
            btnGuardarClienteR.Size = new Size(135, 35);
        }

        private void Guardar()
        {
            // Obtener los números de crédito fiscal ingresados por el usuario
            string[] numerosCreditoFiscal = txtNumerosCreditoFiscal.Text.Split(new char[] { '\n', ',' }, StringSplitOptions.RemoveEmptyEntries);

            // Guardar los números de crédito fiscal en la base de datos
            GuardarCreditoFiscal(numerosCreditoFiscal);

            // Limpiar el cuadro de texto después de guardar los números
            txtNumerosCreditoFiscal.Clear();

            MessageBox.Show("Números de crédito fiscal guardados exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void btnGuardarClienteR_Click(object sender, EventArgs e)
        {
            if (existe == false)
            {
                Guardar();
            }
            else
            {
                Editar();
                existe = false;
            }
        }
        
        private void GuardarCreditoFiscal(string[] numerosCreditoFiscal)
        {
            try
            {
                using (MySqlConnection cnx = cnn.ObtenerConexion())
                {
                    cnx.Open();

                    string query = "INSERT INTO CreditoFiscal (Codigo) VALUES (@Codigo)";

                    foreach (string numero in numerosCreditoFiscal)
                    {
                        using (MySqlCommand miquery = new MySqlCommand(query, cnx))
                        {
                            miquery.Parameters.AddWithValue("@Codigo", numero.Trim());

                            miquery.ExecuteNonQuery();


                           
                        }
                    }
                    CargarDatosFiscal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar guardar números de crédito fiscal: {ex.Message}", "Error de conversión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosFiscal()
        {
            // Crear una conexión a la base de datos
            using (MySqlConnection cnx = cnn.ObtenerConexion())
            {
                try
                {
                    // Abrir la conexión
                    cnx.Open();


                    // Crear un adaptador de datos
                    using (MySqlCommand comand = new MySqlCommand("CargarCreditoFiscal", cnx))
                    {
                        comand.CommandType = CommandType.StoredProcedure;


                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comand))
                        {
                            // Crear un DataSet para almacenar los datos
                            DataSet dataSet = new DataSet();

                            // Llenar el DataSet con los datos del procedimiento almacenado
                            adaptador.Fill(dataSet, "CreditoFiscal");

                            // Establecer el origen de datos del DataGridView
                            dtaFiscal.DataSource = dataSet.Tables["CreditoFiscal"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos de Credito Fiscal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarEdicion()
        {
            existe = true;
            txtNumerosCreditoFiscal.Text = dtaFiscal.CurrentRow.Cells[1].Value.ToString();
            lblId.Text = dtaFiscal.CurrentRow.Cells[0].Value.ToString();

            btnborrar.Visible = true;
        }

        private void Limpiar()
        {
            txtNumerosCreditoFiscal.Clear();
            existe = false;
        }

        private void Borrar()
        {
            try
            {
                MySqlConnection cnx = cnn.ObtenerConexion();
                cnx.Open();

                string query = "DELETE FROM CreditoFiscal " +
                                 "WHERE Id = @A0;";

                MySqlCommand miquery = new MySqlCommand(query, cnx);

                miquery.Parameters.AddWithValue("@A0", lblId.Text);

                int rowsAffected = miquery.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show($"Numero Fiscal elminiado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cnx.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al Eliminar el Numero Fiscal: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CargarDatosFiscal();
        }

        private void Editar()
        {
            try
            {
                MySqlConnection cnx = cnn.ObtenerConexion();
                cnx.Open();

                string query = "UPDATE CreditoFiscal " +
                               "SET Codigo = @A1 " +
                               "WHERE Id = @A0";


                MySqlCommand miQuery = new MySqlCommand(query, cnx);

                miQuery.Parameters.AddWithValue("@A0", lblId.Text);
                miQuery.Parameters.AddWithValue("@A1", txtNumerosCreditoFiscal.Text);

                int rowsAffected = miQuery.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show($"Cliente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se realizaron cambios en la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                cnx.Close();
                CargarDatosFiscal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el Cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            if (existe == false)
            {
                Guardar();
            }
            else
            {
                Editar();
                existe = false;
            }
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            CargarEdicion();
            btnborrar.Visible = true;
        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            Borrar();
            Limpiar();
            btnborrar.Visible = false;
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text != "")
            {
                dtaFiscal.CurrentCell = null;
                foreach (DataGridViewRow row in dtaFiscal.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        row.Visible = false;
                    }
                }

                foreach (DataGridViewRow row in dtaFiscal.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value != null && cell.Value.ToString().ToUpper().IndexOf(bunifuTextBox1.Text.ToUpper()) >= 0)
                            {
                                row.Visible = true;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                CargarDatosFiscal();
            }
        }

        private void bunifuVScrollBar2_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            // Obtiene el número total de filas en el DataGridView
            int totalRows = dtaFiscal.Rows.Count + 1;

            // Obtiene el número de filas visibles en el DataGridView
            int visibleRows = dtaFiscal.DisplayedRowCount(true);

            // Calcula el valor máximo del scrollbar para reflejar el número total de filas
            bunifuVScrollBar2.Maximum = totalRows - visibleRows + 1;

            // Calcula la posición de desplazamiento actual del scrollbar
            int currentScroll = e.Value;

            // Calcula el porcentaje de desplazamiento actual
            double scrollPercentage = (double)currentScroll / bunifuVScrollBar2.Maximum;

            // Calcula la fila correspondiente al porcentaje de desplazamiento actual
            int firstVisibleRow = (int)Math.Floor((totalRows - visibleRows) * scrollPercentage);

            // Establece la primera fila visible en el DataGridView
            dtaFiscal.FirstDisplayedScrollingRowIndex = firstVisibleRow;
        }
    }
}
    

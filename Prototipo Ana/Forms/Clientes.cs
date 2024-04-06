using Bunifu.UI.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Prototipo_Ana.Forms
{
    public partial class Clientes : Form
    {
        Boolean existe;
        public Clientes()
        {
            InitializeComponent();

        }
        private void Clientes_Load(object sender, EventArgs e)
        {
            // Cargar datagrid
            CargarDatosClientes();
            existe = false;
            // Ajustar tamaño de botones
            btnborrar.Visible = false;
            btnlimpiar.Size = new Size(110, 27);
            btnborrar.Size = new Size(110, 27);
            btnEditar.Size = new Size(110, 27);
            btnGuardarClienteR.Size = new Size(177, 38);
            // Establecer color RGB para el encabezado
            Color colorEncabezado = Color.FromArgb(236, 236, 236);
            Color colorLetra = Color.FromArgb(29, 32, 51);
            Color colorSelect = Color.FromArgb(236, 236, 236);
            dtaClientes.ColumnHeadersDefaultCellStyle.BackColor = colorEncabezado;
            dtaClientes.ColumnHeadersDefaultCellStyle.ForeColor = colorLetra;
            dtaClientes.ColumnHeadersDefaultCellStyle.SelectionBackColor = colorSelect;

        }

        private void GuardarCliente()
        {
            try
            {
                MySqlConnection cnx = cnn.ObtenerConexion();
                cnx.Open();

                string query = "INSERT INTO Cliente (Nombre, IdGrupo, Correo, Telefono, RNC) VALUES (@A1, @A2, @A3, @A4, @A5)";

                int grupo;

                if (cbmCliente_GrupoR.Text == "Grupo 1")
                {
                    grupo = 1;
                }
                else if (cbmCliente_GrupoR.Text == "Grupo 2")
                {
                    grupo = 2;
                }
                else if (cbmCliente_GrupoR.Text == "Grupo 3")
                {
                    grupo = 3;
                }
                else
                {
                    grupo = 4;
                }

                MySqlCommand miQuery = new MySqlCommand(query, cnx);

                miQuery.Parameters.AddWithValue("@A1", txtCliente_NombreR.Text);
                miQuery.Parameters.AddWithValue("@A2", grupo);
                miQuery.Parameters.AddWithValue("@A3", txtCliente_CorreoR.Text);
                miQuery.Parameters.AddWithValue("@A4", txtTelefono.Text);
                miQuery.Parameters.AddWithValue("@A5", txtRnc.Text);

                int rowsAffected = miQuery.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cliente insertado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se realizaron cambios en la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                cnx.Close();
                CargarDatosClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void CargarDatosClientes()
        {
            // Crear una conexión a la base de datos
            using (MySqlConnection cnx = cnn.ObtenerConexion())
            {
                try
                {
                    // Abrir la conexión
                    cnx.Open();


                    // Crear un adaptador de datos
                    using (MySqlCommand comand = new MySqlCommand("TRAERCLIENTES", cnx))
                    {
                        comand.CommandType = CommandType.StoredProcedure;


                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comand))
                        {
                            // Crear un DataSet para almacenar los datos
                            DataSet dataSet = new DataSet();

                            // Llenar el DataSet con los datos del procedimiento almacenado
                            adaptador.Fill(dataSet, "clientes");

                            // Establecer el origen de datos del DataGridView
                            dtaClientes.DataSource = dataSet.Tables["clientes"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos de clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarEdicion()
        {
            existe = true;
            lblId.Text = dtaClientes.CurrentRow.Cells[0].Value.ToString();
            txtCliente_NombreR.Text = dtaClientes.CurrentRow.Cells[1].Value.ToString();
            cbmCliente_GrupoR.Text = dtaClientes.CurrentRow.Cells[2].Value.ToString();




            if (cbmCliente_GrupoR.Text == "1")
            {
                cbmCliente_GrupoR.Text = "Grupo 1";
            }
            else if (cbmCliente_GrupoR.Text == "2")
            {
                cbmCliente_GrupoR.Text = "Grupo 2";
            }
            else if (cbmCliente_GrupoR.Text == "3")
            {
                cbmCliente_GrupoR.Text = "Grupo 3";
            }

            else
            {
                cbmCliente_GrupoR.Text = "Grupo 4";
            }
            txtCliente_CorreoR.Text = dtaClientes.CurrentRow.Cells[3].Value.ToString();
            txtTelefono.Text = dtaClientes.CurrentRow.Cells[4].Value.ToString();
            txtRnc.Text = dtaClientes.CurrentRow.Cells[5].Value.ToString();

        }

        private void Editar()
        {
            try
            {
                MySqlConnection cnx = cnn.ObtenerConexion();
                cnx.Open();

                string query = "UPDATE Cliente " +
                               "SET Nombre = @A1, " +
                               "    IdGrupo = @A2, " +
                               "    Correo = @A3, " +
                               "    Telefono = @A4, " +
                               "    RNC = @A5 " +
                               "WHERE Id = @A0";

                int grupo;

                if (cbmCliente_GrupoR.Text == "Grupo 1")
                {
                    grupo = 1;
                }
                else if (cbmCliente_GrupoR.Text == "Grupo 2")
                {
                    grupo = 2;
                }
                else if (cbmCliente_GrupoR.Text == "Grupo 3")
                {
                    grupo = 3;
                }
                else
                {
                    grupo = 4;
                }

                MySqlCommand miQuery = new MySqlCommand(query, cnx);

                miQuery.Parameters.AddWithValue("@A0", lblId.Text);
                miQuery.Parameters.AddWithValue("@A1", txtCliente_NombreR.Text);
                miQuery.Parameters.AddWithValue("@A2", grupo);
                miQuery.Parameters.AddWithValue("@A3", txtCliente_CorreoR.Text);
                miQuery.Parameters.AddWithValue("@A4", txtTelefono.Text);
                miQuery.Parameters.AddWithValue("@A5", txtRnc.Text);

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
                CargarDatosClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el Cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiar()
        {
            txtCliente_CorreoR.Clear();
            txtCliente_NombreR.Clear();
            txtTelefono.Clear();
            txtRnc.Clear();
            cbmCliente_GrupoR.SelectedIndex = -1;
            lblId.Text = "";
            existe = false;
        }

        private void BorrarCliente()
        {
            try
            {
                MySqlConnection cnx = cnn.ObtenerConexion();
                cnx.Open();

                string query = "DELETE FROM Cliente " +
                                 "WHERE Id = @A0;";

                MySqlCommand miquery = new MySqlCommand(query, cnx);

                miquery.Parameters.AddWithValue("@A0", lblId.Text);

                int rowsAffected = miquery.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show($"Cliente elminiado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cnx.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al Eliminar el Cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CargarDatosClientes();
        }


        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

            txtCliente_NombreR.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtCliente_NombreR.Text);
            txtCliente_NombreR.SelectionStart = txtCliente_NombreR.Text.Length;
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            if (existe == false)
            {
                GuardarCliente();
            }
            else
            {
                Editar();
                existe = false;
            }
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            limpiar();
            btnborrar.Visible = false;
        }

        private void bunifuTextBox1_TextChanged_1(object sender, EventArgs e)
        {

            if (txtFiltro.Text != "")
            {
                dtaClientes.CurrentCell = null;
                foreach (DataGridViewRow row in dtaClientes.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        row.Visible = false;
                    }
                }

                foreach (DataGridViewRow row in dtaClientes.Rows)
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
            else
            {
                CargarDatosClientes();
            }
        }

        private void bunifuButton21_Click_1(object sender, EventArgs e)
        {
            CargarEdicion();
            btnborrar.Visible = true;
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                BorrarCliente();
                limpiar();
                btnborrar.Visible = false;
            }
        }

        private void bunifuVScrollBar2_Scroll(object sender, BunifuVScrollBar.ScrollEventArgs e)
        {
            // Obtiene el número total de filas en el DataGridView
            int totalRows = dtaClientes.Rows.Count + 1;

            // Obtiene el número de filas visibles en el DataGridView
            int visibleRows = dtaClientes.DisplayedRowCount(true);

            // Calcula el valor máximo del scrollbar para reflejar el número total de filas
            bunifuVScrollBar2.Maximum = totalRows - visibleRows + 1;

            // Calcula la posición de desplazamiento actual del scrollbar
            int currentScroll = e.Value;

            // Calcula el porcentaje de desplazamiento actual
            double scrollPercentage = (double)currentScroll / bunifuVScrollBar2.Maximum;

            // Calcula la fila correspondiente al porcentaje de desplazamiento actual
            int firstVisibleRow = (int)Math.Floor((totalRows - visibleRows) * scrollPercentage);

            // Establece la primera fila visible en el DataGridView
            dtaClientes.FirstDisplayedScrollingRowIndex = firstVisibleRow;

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {

            // Verifica si el texto ingresado es un número de teléfono válido
            if (System.Text.RegularExpressions.Regex.IsMatch(txtTelefono.Text, @"^\d{3}[-]\d{3}[-]\d{4}$"))
            {
                // El número de teléfono ya está en el formato correcto, no se hace nada
            }
            else
            {
                // Elimina todos los caracteres que no sean números
                string formattedPhoneNumber = System.Text.RegularExpressions.Regex.Replace(txtTelefono.Text, @"[^\d]", "");

                // Verifica si la longitud de la cadena es mayor a 0
                if (formattedPhoneNumber.Length > 0)
                {
                    // Formatea el número de teléfono con guiones o diagonales
                    formattedPhoneNumber = formattedPhoneNumber.Substring(0, Math.Min(formattedPhoneNumber.Length, 10)); // Limita a 10 caracteres (###-###-####)
                    formattedPhoneNumber = $"{formattedPhoneNumber.Substring(0, 3)}-{formattedPhoneNumber.Substring(3, Math.Min(3, formattedPhoneNumber.Length - 3))}-{formattedPhoneNumber.Substring(6, Math.Min(4, formattedPhoneNumber.Length - 6))}";
                }

                // Establece el texto formateado en el TextBox
                txtTelefono.Text = formattedPhoneNumber;
            }

            // Coloca el cursor al final del texto
            txtTelefono.SelectionStart = txtTelefono.Text.Length;
        }
    }
}





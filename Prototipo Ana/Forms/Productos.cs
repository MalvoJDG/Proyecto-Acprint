using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Utilities.Collections;

namespace Prototipo_Ana.Forms
{
    public partial class Productos : Form
    {
        Boolean existe;
        public Productos()
        {
            InitializeComponent();
            existe = false;
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            CargarProductos();
            // Ajustar tamaño de botones
            btnborrar.Visible = false;
            btnlimpiar.Size = new Size(108, 24);
            btnborrar.Size = new Size(108, 24);
            btnEditar.Size = new Size(108, 24);
            btnGuardarClienteR.Size = new Size(158, 27);
            button1.Size = new Size(208, 23);
            // Establecer color RGB para el encabezado
            Color colorEncabezado = Color.FromArgb(236, 236, 236);
            Color colorLetra = Color.FromArgb(29, 32, 51);
            Color colorSelect = Color.FromArgb(236, 236, 236);
            dtaProductos.ColumnHeadersDefaultCellStyle.BackColor = colorEncabezado;
            dtaProductos.ColumnHeadersDefaultCellStyle.ForeColor = colorLetra;
            dtaProductos.ColumnHeadersDefaultCellStyle.SelectionBackColor = colorSelect;
        }
        private void CargarProductos()
        {
            // Crear una conexión a la base de datos
            using (MySqlConnection cnx = cnn.ObtenerConexion())
            {
                try
                {
                    // Abrir la conexión
                    cnx.Open();

                    // Consulta SQL para obtener los datos de clientes


                    // Crear un adaptador de datos
                    using (MySqlCommand comand = new MySqlCommand("ObtenerPrecios", cnx))
                    {
                        comand.CommandType = CommandType.StoredProcedure;


                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comand))
                        {

                            // Crear un DataSet para almacenar los datos
                            DataSet dataSet = new DataSet();

                            // Llenar el DataSet con los datos de la consulta
                            adaptador.Fill(dataSet, "Material");

                            // Establecer el origen de datos del DataGridView
                            dtaProductos.DataSource = dataSet.Tables["Material"];

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos del Material: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

   

        public void EditarMaterial_Precio()
        {
            if (existe == true)
            {
                try
                {
                    MySqlConnection cnx = cnn.ObtenerConexion();
                    cnx.Open();

                    string query = @"
                    UPDATE Material
                    SET Nombre = @A0
                    WHERE Id = @A4;

                    UPDATE Precios
                    SET Precio = @A3,
                        IdGrupo = @A2
                    WHERE Id = @A4;";


                    int grupo;

                    if (cbmPrecio_GrupoR.Text == "Grupo 1")
                    {
                        grupo = 1;
                    }
                    else if (cbmPrecio_GrupoR.Text == "Grupo 2")
                    {
                        grupo = 2;
                    }
                    else if (cbmPrecio_GrupoR.Text == "Grupo 3")
                    {
                        grupo = 3;
                    }
                    else
                    {
                        grupo = 4;
                    }

                    MySqlCommand miQuery = new MySqlCommand(query, cnx);

                    miQuery.Parameters.AddWithValue("@A0", txtNombreMaterial.Text);
                    miQuery.Parameters.AddWithValue("@A2", grupo);
                    miQuery.Parameters.AddWithValue("@A3", txtPrecio.Text);
                    miQuery.Parameters.AddWithValue("@A4", lblId.Text);

                    int rowsAffected = miQuery.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se realizaron cambios en la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    cnx.Close();
                    CargarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el Producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void CargarEdicion()
        {
            existe = true;

            lblId.Text = dtaProductos.CurrentRow.Cells[0].Value.ToString();
            txtNombreMaterial.Text = dtaProductos.CurrentRow.Cells[1].Value.ToString();
            txtPrecio.Text = dtaProductos.CurrentRow.Cells[2].Value.ToString();
            cbmPrecio_GrupoR.Text = dtaProductos.CurrentRow.Cells[3].Value.ToString();

            if (cbmPrecio_GrupoR.Text == "1")
            {
                cbmPrecio_GrupoR.Text = "Grupo 1";
            }
            else if (cbmPrecio_GrupoR.Text == "2")
            {
                cbmPrecio_GrupoR.Text = "Grupo 2";
            }
            else if (cbmPrecio_GrupoR.Text == "3")
            {
                cbmPrecio_GrupoR.Text = "Grupo 3";
            }

            else
            {
                cbmPrecio_GrupoR.Text = "Grupo 4";
            }

            mostrar();
            button1.Visible = false;

        }

        private void cbmPrecio_GrupoR_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void GuardarFUll()
        {
        
            using (MySqlConnection cnx = cnn.ObtenerConexion())
            {
                cnx.Open();

                try
                {

                    //Buscar id del material
                    MySqlCommand cmdid = new MySqlCommand("SELECT Id FROM Material WHERE Nombre = @A0", cnx);
                    cmdid.Parameters.AddWithValue("@A0", txtNombreMaterial.Text);
                    int idMaterial = Convert.ToInt32(cmdid.ExecuteScalar());

                    //Insertar precio
                    MySqlCommand cmdPrecio = new MySqlCommand("INSERT INTO Precios(IdMat, Precio, IdGrupo)" +
                        " VALUES(@A0, @A1, @A2)",
                        cnx);
                    cmdPrecio.Parameters.AddWithValue("@A0", idMaterial);
                    cmdPrecio.Parameters.AddWithValue("@A1", txtPrecio.Text);

                    if (cbmPrecio_GrupoR.Text == "Grupo 1")
                    {
                        cbmPrecio_GrupoR.Text = "1";
                    }
                    else if (cbmPrecio_GrupoR.Text == "Grupo 2")
                    {
                        cbmPrecio_GrupoR.Text = "2";
                    }
                    else if (cbmPrecio_GrupoR.Text == "Grupo 3")
                    {
                        cbmPrecio_GrupoR.Text = "3";
                    }

                    else
                    {
                        cbmPrecio_GrupoR.Text = "4";
                    }

                    cmdPrecio.Parameters.AddWithValue("@A2", cbmPrecio_GrupoR.Text);

                    int rowi = cmdid.ExecuteNonQuery();
                    int rowp = cmdPrecio.ExecuteNonQuery();

                    if (rowp > 0)
                    {
                        MessageBox.Show($"Precio Guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarProductos();
                    }
                    else
                    {
                        MessageBox.Show("No se realizaron cambios en la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                catch(Exception ex)
                {
                  MessageBox.Show($"El Precio no se ha podido guardar:{ex}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
                }
                
                
            }
        }
        
        public void GuardarMaterial()
        {
            try
            {
                using (MySqlConnection cnx = cnn.ObtenerConexion())
                {
                    cnx.Open();
                    //Guardar el material
                    MySqlCommand cmdMat = new MySqlCommand("INSERT INTO Material(Nombre) VALUES(@A0)", cnx);
                    cmdMat.Parameters.AddWithValue("@A0", txtNombreMaterial.Text);

                    int row = cmdMat.ExecuteNonQuery();

                    if (row > 0)
                    {
                        MessageBox.Show($"Material Guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mostrar();
                    }
                    else
                    {
                        MessageBox.Show("No se realizaron cambios en la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"El material no se ha podido guardar:{ex}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void mostrar()
        {
            label2.Visible = true;
            label3.Visible = true;
            label6.Visible = true;
            txtPrecio.Visible = true;
            cbmPrecio_GrupoR.Visible = true;
            btnGuardarClienteR.Visible = true;
        }

        private void limpiar()
        {
            txtNombreMaterial.Clear();
            txtPrecio.Clear();
            lblId.Text = "";
            cbmPrecio_GrupoR.Text = "";
            btnborrar.Visible = false;
            button1.Visible = true;

            label2.Visible = false;
            label3.Visible = false;
            label6.Visible = false;
            txtPrecio.Visible = false;
            cbmPrecio_GrupoR.Visible = false;
            btnGuardarClienteR.Visible = false;

            existe = false;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GuardarMaterial();
        }

        private void txtFiltro_TextChanged_1(object sender, EventArgs e)
        {

            if (txtFiltro.Text != "")
            {
                dtaProductos.CurrentCell = null;
                foreach (DataGridViewRow row in dtaProductos.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        row.Visible = false;
                    }
                }

                foreach (DataGridViewRow row in dtaProductos.Rows)
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
                CargarProductos();
            }
        }

        private void btnGuardarClienteR_Click(object sender, EventArgs e)
        {
            
            if (existe == false)
            {
                GuardarFUll();
            }
            else
            {
                EditarMaterial_Precio();
                existe = false;
            }
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            CargarEdicion();
            btnborrar.Visible = true;
        }
        
        private void borrar()
        {
            if (existe == true)
            {
                try
                {
                    MySqlConnection cnx = cnn.ObtenerConexion();
                    cnx.Open();

                    string query = @"
                    Delete From Material
                    where Nombre = @Nombre;

                    Delete From Precios
                    WHERE Id = @Id;";

                    MySqlCommand miQuery = new MySqlCommand(query, cnx);

                    miQuery.Parameters.AddWithValue("@Nombre", txtNombreMaterial.Text);
                    miQuery.Parameters.AddWithValue("@Id", lblId.Text);


                    int rowsAffected = miQuery.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Producto Eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se realizaron cambios en la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    cnx.Close();
                    CargarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al Eliminar el Producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bunifuVScrollBar2_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            // Obtiene el número total de filas en el DataGridView
            int totalRows = dtaProductos.Rows.Count + 1;

            // Obtiene el número de filas visibles en el DataGridView
            int visibleRows = dtaProductos.DisplayedRowCount(true);

            // Calcula el valor máximo del scrollbar para reflejar el número total de filas
            bunifuVScrollBar2.Maximum = totalRows - visibleRows + 1;

            // Calcula la posición de desplazamiento actual del scrollbar
            int currentScroll = e.Value;

            // Calcula el porcentaje de desplazamiento actual
            double scrollPercentage = (double)currentScroll / bunifuVScrollBar2.Maximum;

            // Calcula la fila correspondiente al porcentaje de desplazamiento actual
            int firstVisibleRow = (int)Math.Floor((totalRows - visibleRows) * scrollPercentage);

            // Establece la primera fila visible en el DataGridView
            dtaProductos.FirstDisplayedScrollingRowIndex = firstVisibleRow;
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            borrar();
            btnborrar.Visible = false;
            limpiar();
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}

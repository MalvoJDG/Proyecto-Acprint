using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.ServiceModel.Configuration;
using System.Windows.Forms;

namespace Prototipo_Ana.Forms
{
    public partial class Ventas : Form
    {
        int numeroFactura = 0;
        Boolean existe;
        public Ventas()
        {
            InitializeComponent();

            rellenarcbm();
            CreditoFiscal();
            cbmMaterial.Text = "";
            cbmNCF.Text = "No";
            lblNCF.Visible = false;
            cbmImpuesto.Text = "Si";
            cbmPago.Text = "Pagada";
            //Establecer timer para que la hora avance
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
            //Nuevo numero de factura
            int longitudMinima = 5;
            numeroFactura = ObtenerProximoNumeroFactura();
            string FacAstr = numeroFactura.ToString();
            lblFac.Text = "F" + FacAstr.PadLeft(longitudMinima, '0').ToString();
            //Establecer tamaño de los botones
            btnBuscarCliente.Size = new Size(105, 22);
            btnIns.Size = new Size(105, 22);
        }

        // **************************** FUNCIONES DE BOTONES **************************************************************************


        private void btnImprimir_Click(object sender, EventArgs e)
        {
            imprimir();
        }
       
        private void btnguardar_Click(object sender, EventArgs e)
        {
            DetalleFactura();
        }

        private void btnLimpiarD_Click(object sender, EventArgs e)
        {
            limpiarDetalle();
        }

        private void btnLimpiarT_Click(object sender, EventArgs e)
        {
            limpiarTodo();
        }

        // ************************************ FUNCIONES CORTAS DE BOTON ************************************************************************


        private void InsertarLinea()
        {
            int xRows = dtaVentas.Rows.Add(); // Añade una nueva fila y obtiene el índice de la fila agregada

            dtaVentas.Rows[xRows].Cells[0].Value = txtServicio.Text;
            dtaVentas.Rows[xRows].Cells[1].Value = cbmMaterial.Text;
            dtaVentas.Rows[xRows].Cells[2].Value = txtCantidad.Text;
            dtaVentas.Rows[xRows].Cells[3].Value = lblitbis.Text;
            dtaVentas.Rows[xRows].Cells[4].Value = lblTotalln.Text;
        }

        // ***************************************** FUNCIONES LARGUISIMA *****************************************************************************

        private void BuscarCliente(string NombreCliente)
        {
            existe = false;
            using (MySqlConnection cnx = cnn.ObtenerConexion())
            {
                try
                {
                    cnx.Open();

                    string query = "SELECT Cliente.Nombre as Nombre, Cliente.IdGrupo, Cliente.Id as Id, Grupo.Nombre AS NombreGrupo " +
                        "FROM Cliente " +
                        "INNER JOIN Grupo ON Cliente.IdGrupo = Grupo.Id " +
                        "WHERE Cliente.Nombre like CONCAT(@NombreCliente, '%')";


                    MySqlCommand cmd = new MySqlCommand(query, cnx);
                    cmd.Parameters.AddWithValue("@NombreCliente", NombreCliente.ToLower().Trim());

                    MySqlDataReader rsd = cmd.ExecuteReader();

                    if (rsd.Read())
                    {
                        existe = true;
                        lblId.Text = Convert.ToString(rsd["Id"]);
                        lblGrupo.Text = Convert.ToString(rsd["NombreGrupo"]);
                        txtNombre.Text = Convert.ToString(rsd["Nombre"]);
                    }
                }
                catch (Exception ex)
                {
                    // Muestra un mensaje de error con los detalles de la excepción.
                    MessageBox.Show($"Error en la operación de búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cnx.State == ConnectionState.Open)
                    {
                        cnx.Close();
                    }
                }
            }
        }


        private void ObtenerPrecioMaterial(string nombreMaterial, string nombreGrupo)
        {
            try
            {
                using (MySqlConnection cnx = cnn.ObtenerConexion())
                {
                    cnx.Open();

                    // Obtener el Id del grupo del cliente actual por su nombre
                    int idGrupo = ObtenerIdGrupoPorNombre(nombreGrupo);

                    string query = "SELECT Precios.Precio " +
                                   "FROM Precios " +
                                   "INNER JOIN Material ON Precios.IdMat = Material.Id " +
                                   "WHERE Material.Nombre = @NombreMaterial " +
                                   "AND Precios.IdGrupo = @IdGrupo";

                    using (MySqlCommand cmd = new MySqlCommand(query, cnx))
                    {
                        cmd.Parameters.AddWithValue("@NombreMaterial", nombreMaterial);
                        cmd.Parameters.AddWithValue("@IdGrupo", idGrupo);

                        object resultado = cmd.ExecuteScalar();

                        if (resultado != null)
                        {
                            decimal precio = Convert.ToDecimal(resultado);
                            lblPrecio.Text = $"{precio}";
                        }
                        else
                        {
                            lblPrecio.Text = "No Existe";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el precio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para obtener el Id del grupo por su nombre
        private int ObtenerIdGrupoPorNombre(string nombreGrupo)
        {
            using (MySqlConnection cnx = cnn.ObtenerConexion())
            {
                cnx.Open();

                string query = "SELECT Id FROM Grupo WHERE Nombre = @NombreGrupo";

                using (MySqlCommand cmd = new MySqlCommand(query, cnx))
                {
                    cmd.Parameters.AddWithValue("@NombreGrupo", nombreGrupo);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {
                        return Convert.ToInt32(resultado);
                    }
                    else
                    {
                        throw new Exception("Grupo no encontrado");
                    }
                }
            }
        }


        private void CalculoTotal()
        {
            try
            {
                // Asegurarse de que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(txtAncho.Text) || string.IsNullOrWhiteSpace(txtLargo.Text) || string.IsNullOrWhiteSpace(lblPrecio.Text))
                {
                    MessageBox.Show("Ingrese valores numéricos válidos para Ancho, Largo y Precio", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Continuar con el cálculo
                if (double.TryParse(txtAncho.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double ancho) &&
                    double.TryParse(txtLargo.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double largo) &&
                    double.TryParse(lblPrecio.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double precioMat) &&
                    double.TryParse(txtCantidad.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double cantidad))
                {
                    // Verificar si precioMat es un número válido
                    if (!double.IsNaN(precioMat) && !double.IsInfinity(precioMat))
                    {
                        double total = (ancho * largo) / 144 * precioMat * cantidad;
                        lblTotalln.Text = total.ToString("N2", CultureInfo.InvariantCulture);

                        if (cbmImpuesto.Text == "Si")
                        {
                            double impuesto = total * 0.18;
                            lblitbis.Text = impuesto.ToString("N2", CultureInfo.InvariantCulture);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El precio del material no es un número válido", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese valores numéricos válidos para Ancho, Largo y Precio", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en el cálculo del total: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Hfactura()
        {
            try
            {

                string query = "INSERT INTO HFacturas(" +
                                     " Factura, " +
                                     " Fecha_Emision, " +
                                     " subTotal, " +
                                     " ITBIS, " +
                                     " Total, " +
                                     " Credito_Fiscal, " +
                                     " Estado_Pago) " +
                                     "VALUES(@H0, @H1, @H2, @H3, @H4, @H5, @H6)";

                MySqlConnection cnx = cnn.ObtenerConexion();
                cnx.Open();

                MySqlCommand miQuery = new MySqlCommand(query, cnx);


                miQuery.Parameters.AddWithValue("@H0", "F" + numeroFactura.ToString().PadLeft(5, '0'));
                miQuery.Parameters.AddWithValue("@H1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                miQuery.Parameters.AddWithValue("@H2", float.Parse(lblSubTotal.Text));
                miQuery.Parameters.AddWithValue("@H3", float.Parse(lblImpuesto.Text));
                miQuery.Parameters.AddWithValue("@H4", float.Parse(lblTotal.Text));

                if (cbmNCF.Text == "No")
                {
                    miQuery.Parameters.AddWithValue("@H5", null);
                }
                else if (cbmNCF.Text == "Si")
                {

                    miQuery.Parameters.AddWithValue("@H5", lblNCF.Text);

                }

                miQuery.Parameters.AddWithValue("@H6", cbmPago.Text);

                miQuery.ExecuteNonQuery();


                cnx.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar guardar la Hfactura: {ex.Message}", "Error de conversión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void TotalTot()
        {
            double xTotal = 0;
            double xSubtotal = 0;
            double xImpuesto = 0;


            lblTotal.Text = "";
            lblSubTotal.Text = "";
            lblImpuesto.Text = "";

            foreach (DataGridViewRow row in dtaVentas.Rows)
            {
                if (row != null && row.Cells[4] != null && row.Cells[4].Value != null)
                {
                    // Añade un bloque try-catch para capturar la excepción específica
                    try
                    {
                        if (double.TryParse(Convert.ToString(row.Cells[4].Value), NumberStyles.Any, CultureInfo.InvariantCulture, out double total))
                        {


                            if (cbmImpuesto.Text == "Si")
                            {
                                xImpuesto += total * 0.18;
                            }

                            xSubtotal += total;
                            xTotal = xSubtotal + xImpuesto;


                        }
                        else
                        {
                            MessageBox.Show($"Error al convertir el valor '{row.Cells[4].Value}' de la celda a número.", "Error de conversión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;  // Salir del método si la conversión falla
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al convertir el valor de la celda a número: {ex.Message}", "Error de conversión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;  // Salir del método en caso de excepción
                    }
                }
            }

            lblTotal.Text = xTotal.ToString("N2", CultureInfo.InvariantCulture);
            lblSubTotal.Text = xSubtotal.ToString("N2", CultureInfo.InvariantCulture);
            lblImpuesto.Text = xImpuesto.ToString("N2", CultureInfo.InvariantCulture);

        }


        private void limpiarDetalle()
        {
            cbmMaterial.SelectedIndex = -1;
            txtServicio.Clear();
            lblPrecio.Text = "";
            txtAncho.Clear();
            lblTotalln.Text = "";
            txtLargo.Clear();
            txtCantidad.Clear();
        }
        private void limpiarTodo()
        {
            cbmMaterial.SelectedIndex = -1;
            txtServicio.Clear();
            lblPrecio.Text = "";
            txtAncho.Clear();
            lblTotalln.Text = "";
            txtLargo.Clear();
            txtNombre.Clear();
            lblGrupo.Text = "";
            dtaVentas.Rows.Clear();
            lblTotal.Text = "";
            txtCantidad.Clear();
            lblSubTotal.Text = "";
            lblImpuesto.Text = "";
            cbmImpuesto.Text = "Si";
        }



        private void DetalleFactura()
        {
            try
            {
                string query = "INSERT INTO Facturas(" +
                               " Factura, " +
                               " Nombre_Cliente, " +
                               " Fecha_Emision, " +
                               " Detalle, " +
                               " Material, " +
                               " Cantidad, " +
                               " Monto_Linea, " +
                               " ITBIS_Linea, " +
                               " subTotal, " +
                               " ITBIS, " +
                               " Total) " +
                               "VALUES(@A0, @A1, @A2, @A3, @A4, @A5, @A6, @A7, @A8, @A9, @A10)";

                using (MySqlConnection cnx = cnn.ObtenerConexion())
                {
                    cnx.Open();

                    int rows = 0;

                    foreach (DataGridViewRow Row in dtaVentas.Rows)
                    {
                        string Detalle = Row.Cells[0].Value.ToString();
                        double Cantidad = Convert.ToDouble(Row.Cells[2].Value.ToString());
                        double Impuesto = Convert.ToDouble(Row.Cells[3].Value.ToString());
                        double Precio = Convert.ToDouble(Row.Cells[4].Value.ToString());

                        MySqlCommand miQuery = new MySqlCommand(query, cnx);

                        miQuery.Parameters.AddWithValue("@A0", "F" + numeroFactura.ToString().PadLeft(5, '0'));
                        miQuery.Parameters.AddWithValue("@A1", txtNombre.Text);
                        miQuery.Parameters.AddWithValue("@A2", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        miQuery.Parameters.AddWithValue("@A3", Detalle); // Aquí cambiamos txtServicio.Text por Detalle
                        miQuery.Parameters.AddWithValue("@A4", Row.Cells[1].Value.ToString());
                        miQuery.Parameters.AddWithValue("@A5", Cantidad);
                        miQuery.Parameters.AddWithValue("@A6", Precio);
                        miQuery.Parameters.AddWithValue("@A7", Impuesto);
                        miQuery.Parameters.AddWithValue("@A8", float.Parse(lblSubTotal.Text));
                        miQuery.Parameters.AddWithValue("@A9", float.Parse(lblImpuesto.Text));
                        miQuery.Parameters.AddWithValue("@A10", float.Parse(lblTotal.Text));

                        rows += miQuery.ExecuteNonQuery();
                    }

                    if (rows > 0)
                    {
                        MessageBox.Show("Factura Guardada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Hfactura();
                        this.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("No se realizaron cambios en la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar guardar la factura: {ex.Message}", "Error de conversión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private int ObtenerProximoNumeroFactura()
        {
            MySqlConnection cnx = cnn.ObtenerConexion();
            cnx.Open();
            // Obtener el último número de factura
            string query = "SELECT COALESCE(MAX(CAST(SUBSTRING(Factura, 2) AS UNSIGNED)), 0) FROM Facturas";
            using (MySqlCommand cmd = new MySqlCommand(query, cnx))
            {
                object result = cmd.ExecuteScalar();
                int ultimoNumeroFactura = (result != DBNull.Value) ? Convert.ToInt32(result) : 0;

                // Incrementar el número de factura
                return ultimoNumeroFactura + 1;
            }
        }

        private void imprimir()
        {
            SaveFileDialog save = new SaveFileDialog();
            if (swtipe.Checked == true)
            {
                save.FileName = lblFac.Text + ".pdf";
            }
            else
            {
                save.FileName = ".pdf";
            }
            save.DefaultExt = "pdf";
            save.Filter = "Archivos PDF (*.pdf)|*.pdf";

            string plantilla_html = Properties.Resources.plantilla.ToString();

            plantilla_html = plantilla_html.Replace("@Cliente", txtNombre.Text);
            plantilla_html = plantilla_html.Replace("@Rnc", lblId.Text);
            plantilla_html = plantilla_html.Replace("@Fecha", DateTime.Now.ToString("dd/MM/yyyy"));
            plantilla_html = plantilla_html.Replace("@SubTotal", "$" + lblSubTotal.Text);
            plantilla_html = plantilla_html.Replace("@Impuestos", "$" + lblImpuesto.Text);
            plantilla_html = plantilla_html.Replace("@Total", "$" + lblTotal.Text);

            if (swtipe.Checked == true)
            {


                if (cbmNCF.Text == "Si")
                {
                    plantilla_html = plantilla_html.Replace("@CONT", lblNCF.Text);
                    plantilla_html = plantilla_html.Replace("@Factura", "FACTURA VALIDA PARA CREDITO FISCAL");
                    plantilla_html = plantilla_html.Replace("@NumFac", "F" + numeroFactura.ToString().PadLeft(5, '0'));
                }
                else
                {
                    plantilla_html = plantilla_html.Replace("NCF:", "");
                    plantilla_html = plantilla_html.Replace("@CONT", "");
                    plantilla_html = plantilla_html.Replace("@Factura", "FACTURA");
                    plantilla_html = plantilla_html.Replace("@NumFac", "F" + numeroFactura.ToString().PadLeft(5, '0'));
                }

                if (cbmPago.Text == "Pagada")
                {
                    plantilla_html = plantilla_html.Replace("@Estado", "De contado");
                }

                else
                {
                    plantilla_html = plantilla_html.Replace("@Estado", "Credito");
                }
            }

            else
            {
                plantilla_html = plantilla_html.Replace("@Factura", "COTIZACION");
                plantilla_html = plantilla_html.Replace("NCF:", "");
                plantilla_html = plantilla_html.Replace("@CONT", "");
                plantilla_html = plantilla_html.Replace("Nro:", " ");
                plantilla_html = plantilla_html.Replace("@NumFac", " ");
                plantilla_html = plantilla_html.Replace("@Estado", "");
                plantilla_html = plantilla_html.Replace("Condicion de pago:", "");
            }

          



            string filas = string.Empty;

            foreach (DataGridViewRow Row in dtaVentas.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + Row.Cells["Servicio"].Value.ToString() + "</td>";
                filas += "<td align='right'>" + "$" + lblPrecio.Text.ToString() + "</td>";
                filas += "<td align='center'>" + Row.Cells["Cantidad"].Value.ToString() + "</td>";
                if(cbmImpuesto.Text == "Si")
                {
                    filas += "<td align='right'>" + "$" + Row.Cells["ITBIS"].Value.ToString() + "</td>";
                }
                else
                {
                    filas += "<td align='right'>" +  Row.Cells["ITBIS"].Value.ToString() + "</td>";
                }
                filas += "<td align='right'>" + "$" + Row.Cells["TotalPorLinea"].Value.ToString() + "</td>";
                filas += "</tr>";
            }

            plantilla_html = plantilla_html.Replace("@Lista", filas);


            if (save.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(save.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                    writer.PageEvent = new Footer();

                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));

                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.ac_print_2_estelar, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(90, 70);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;
                    img.SetAbsolutePosition(pdfDoc.LeftMargin + 5, pdfDoc.Top - 60);
                    pdfDoc.Add(img);



                    using (StringReader str = new StringReader(plantilla_html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, str);
                    }

                    pdfDoc.Close();
                    stream.Close();
                }
            }
        }
        public class Footer : PdfPageEventHelper
        {
            public override void OnEndPage(PdfWriter writer, Document document)
            {
                // Crear el contenido del footer
                PdfPTable footer = new PdfPTable(1);
                footer.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                footer.DefaultCell.Border = 0;
                footer.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                footer.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;


                // Crear el texto del footer con formato
                Phrase phrase = new Phrase();


                phrase.Add(new Chunk("Si usted tiene alguna pregunta sobre esta Orden, por favor, póngase en contacto con nosotros. ", FontFactory.GetFont(FontFactory.HELVETICA, 10))); // Otra línea de texto sin negritas
                phrase.Add(Chunk.NEWLINE);
                phrase.Add(new Chunk("                            ANA KARINA CUICA, Tel. 829-696-3299/Email: acprint.rd@gmail.com\r\n ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9)));  // Texto en negritas

                // Añadir el texto al footer
                PdfPCell cell = new PdfPCell();
                cell.Border = 0;
                cell.PaddingTop = -13f; // Ajustar el espaciado superior del texto si es necesario
                cell.HorizontalAlignment = Element.ALIGN_CENTER; // Alinear el texto en el centro
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;



                // Añadir el texto al footer
                cell.AddElement(phrase);
                footer.AddCell(cell);

                // Posicionar el footer en la parte inferior de la página
                // Calcular la posición horizontal para el footer
                float xPosition = document.LeftMargin + 75; // Ajustar el valor según sea necesario

                // Posicionar el footer en la parte inferior de la página, más a la izquierda
                footer.WriteSelectedRows(0, -1, xPosition, document.BottomMargin, writer.DirectContent);

            }
        }

        public void rellenarcbm()
        {
            // Desactiva el control de eventos SelectedIndexChanged para evitar errores
            cbmMaterial.SelectedIndexChanged -= cbmMaterial_SelectedIndexChanged;

            try
            {
                using (MySqlConnection cnx = cnn.ObtenerConexion())
                {
                    using (MySqlCommand comand = new MySqlCommand("NOMBREMATERIAL", cnx))
                    {
                        comand.CommandType = CommandType.StoredProcedure;

                        // Crear un adaptador de datos para obtener los resultados del procedimiento almacenado
                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comand))
                        {
                            DataTable data = new DataTable();

                            // Llenar la tabla de datos con los resultados del procedimiento almacenado
                            adaptador.Fill(data);

                            // Asignar los datos al ComboBox
                            cbmMaterial.DataSource = data;
                            cbmMaterial.DisplayMember = "Nombre";

                            // Después de asignar los datos, establecer el índice seleccionado en -1 para dejar el ComboBox vacío
                            cbmMaterial.SelectedIndex = -1;
                        }
                    }
                }
            }
            finally
            {
                // Reactiva el control de eventos SelectedIndexChanged
                cbmMaterial.SelectedIndexChanged += cbmMaterial_SelectedIndexChanged;
            }
        }

        private void CreditoFiscal()
        {

            MySqlConnection cnx = cnn.ObtenerConexion();
            cnx.Open();

            using (MySqlCommand miquery = new MySqlCommand("SecuenciaFiscal", cnx))
            {
                miquery.CommandType = CommandType.StoredProcedure;

                MySqlDataReader rsd = miquery.ExecuteReader();

                if (rsd.Read())
                {
                    lblNCF.Text = Convert.ToString(rsd["Codigo"]);
                }

            }

        }

        private void cbmNCF_SelectedIndexChanged(object sender, EventArgs e)
        {
            OcultarNCF();
        }

        private void OcultarNCF()
        {
            if (cbmNCF.SelectedIndex == 0)
            {
                lblNCF.Visible = false;
            }
            else
            {
                lblNCF.Visible = true;
            }
        }

        private void cbmNCF_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            OcultarNCF();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtNombre.Text.Trim() != string.Empty)
                {
                    cbmMaterial.Focus();
                }
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {   
            if(txtNombre.Text != string.Empty)
            {
                BuscarCliente(txtNombre.Text);
            }      
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarCliente(txtNombre.Text);
        }

        private void lblGrupo_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbmMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreMaterial = cbmMaterial.Text; // Asegúrate de obtener el nombre del TextBox o de donde lo obtienes
            string nombreGrupo = lblGrupo.Text; // Asegúrate de obtener el nombre del TextBox o de donde lo obtienes
            ObtenerPrecioMaterial(nombreMaterial, nombreGrupo);

            txtServicio.Focus();
        }

        private void txtServicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtServicio.Text.Trim() != string.Empty)
                {
                    txtCantidad.Focus();
                }
            }
        }

        private void txtCantidad_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtCantidad.Text.Trim() != string.Empty)
                {
                    txtAncho.Focus();
                }
            }
        }

        private void txtAncho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtAncho.Text.Trim() != string.Empty)
                {
                    txtLargo.Focus();
                }
            }
        }

        private void txtLargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtLargo.Text.Trim() != string.Empty)
                {
                    btnIns.Focus();
                }
            }
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            InsertarLinea();
            TotalTot();
        }

        private void txtLargo_Leave(object sender, EventArgs e)
        {
            CalculoTotal();
        }

        private void timer1_Tick(object sender, EventArgs e)
        { 
            lblFecha.Text = DateTime.Now.ToString("d/M/yyyy   HH:mm:ss");
        }

        private void swtipe_CheckedChanged(object sender, EventArgs e)
        {
            if(swtipe.Checked == true)
            {
                lbltipe.Text = "Factura";
                btnguardar.Visible = true;
                label10.Visible = true;
                lblFac.Visible = true;
                lbl10.Visible = true;
                cbmNCF.Visible = true;
                lblNCF.Visible = true;
                cbmPago.Visible = true;
                label12.Visible = true;

            }
            else
            {
                lbltipe.Text = "Cotizacion";
                btnguardar.Visible = false;
                label10.Visible = false;
                lblFac.Visible = false;
                lbl10.Visible = false;
                cbmNCF.Visible = false;
                lblNCF.Visible = false;
                cbmPago.Visible = false;
                label12.Visible = false;
            }
        }
    }
}

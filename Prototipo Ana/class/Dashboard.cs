using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;

using MySql.Data.MySqlClient;
using Prototipo_Ana;

namespace Dashboard
{
    public struct Ingresos
    {
        public string Fecha { get; set; }
        public float Total { get; set; }
    }
    public class Dashboard 
    {
        

        private DateTime StartDate;
        private DateTime EndDate;
        private int NumberDays;

        public int NumClientes { get; private set; }
        public int NumMateriales { get; private set; }
        public List<KeyValuePair<string, int>> TopMateriales { get; private set; }
        public List<Ingresos> IngresosList { get; private set; }
        public int Facturas { get; private set; }
        public int Facturas_Pagar { get; private set; }
        public float IngresoActual { get; private set; }
        public float Deber { get; private set; }
        public float IngresosTotales { get; private set; }

        public Dashboard()
        {

        }

        private void GetNumbersItems()
        {
            using (MySqlConnection cnx = cnn.ObtenerConexion())
            {
                cnx.Open();

                // TRAER NUMERO DE CLIENTES
                MySqlCommand comandoNumClientes = cnn.CrearComando("NUMEROCLIENTES", cnx);
                object numClientesResult = comandoNumClientes.ExecuteScalar();
                NumClientes = numClientesResult != DBNull.Value ? Convert.ToInt32(numClientesResult) : 0;

                // Traer Numero De Materiales
                MySqlCommand comandoNumMaterial = cnn.CrearComando("NUMEROMATERIAL", cnx);
                object numMaterialResult = comandoNumMaterial.ExecuteScalar();
                NumMateriales = numMaterialResult != DBNull.Value ? Convert.ToInt32(numMaterialResult) : 0;

                // TRAER Numero de Facturas Pagadas
                MySqlCommand comandoFacturas = new MySqlCommand("SELECT COUNT(*) FROM HFacturas WHERE Estado_Pago = 'Pagada' AND Fecha_Emision BETWEEN @fromDate AND @ToDate", cnx);
                comandoFacturas.Parameters.AddWithValue("@fromDate", StartDate);
                comandoFacturas.Parameters.AddWithValue("@ToDate", EndDate);
                Facturas = Convert.ToInt32(comandoFacturas.ExecuteScalar());

                // Traer Numero De Facturas por pagar
                MySqlCommand comandoFacturas_Pagar = new MySqlCommand("SELECT COUNT(*) FROM HFacturas WHERE Estado_Pago = 'Pendiente' AND Fecha_Emision BETWEEN @fromDate AND @ToDate", cnx);
                comandoFacturas_Pagar.Parameters.AddWithValue("@fromDate", StartDate);
                comandoFacturas_Pagar.Parameters.AddWithValue("@ToDate", EndDate);
                Facturas_Pagar = Convert.ToInt32(comandoFacturas_Pagar.ExecuteScalar());

                // Traer Total por pagar
                MySqlCommand ComandoDeber = new MySqlCommand("SELECT Fecha_Emision, ROUND(SUM(Total), 2) FROM HFacturas WHERE Estado_Pago = 'Pendiente' AND Fecha_Emision BETWEEN @fromDate AND @ToDate", cnx);
                ComandoDeber.Parameters.AddWithValue("@fromDate", StartDate);
                ComandoDeber.Parameters.AddWithValue("@ToDate", EndDate);

                // Ejecutar la consulta y obtener el resultado como un MySqlDataReader
                using (MySqlDataReader reader = ComandoDeber.ExecuteReader())
                {
                    // Verificar si hay filas en el resultado
                    if (reader.Read())
                    {
                        // Obtener el valor del segundo campo (índice 1) del resultado
                        // Este campo corresponde al total redondeado
                        object valor = reader[1];

                        // Verificar si el valor no es DBNull
                        if (valor != DBNull.Value)
                        {
                            // Convertir el valor a double (o el tipo que corresponda)
                            double totalRedondeado = Convert.ToDouble(valor);
                            Deber = (float)totalRedondeado;
                            // Utilizar el total redondeado
                        }
                        else
                        {
                            Deber = (float)0;
                        }
                    }
                }

            }
        }

        private void GetOrdenAnalisis()
        {
            IngresosList = new List<Ingresos>();
            IngresosTotales = 0;
            IngresoActual = 0;

            using (MySqlConnection cnx = cnn.ObtenerConexion())
            {
                cnx.Open();

                // Sacar Total Actual
                MySqlCommand comandoTotalFacturas = new MySqlCommand("SELECT Fecha_Emision, ROUND(SUM(Total), 2) FROM HFacturas WHERE Fecha_Emision BETWEEN @fromDate AND @ToDate GROUP BY Fecha_Emision ORDER BY Fecha_Emision;", cnx);
                comandoTotalFacturas.Parameters.AddWithValue("@fromDate", StartDate);
                comandoTotalFacturas.Parameters.AddWithValue("@ToDate", EndDate);
                // Leer los resultados del comando
                using (MySqlDataReader reader = comandoTotalFacturas.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0) && !reader.IsDBNull(1))
                        {
                            DateTime fecha = reader.GetDateTime(0);
                            float total = reader.GetFloat(1);
                            IngresosTotales += total;
                            IngresosList.Add(new Ingresos
                            {
                                Fecha = fecha.ToString("dd MMM"),
                                Total = total
                            });
                        }
                    }
                    reader.Close();
                }

                // Sacar Total completo
                MySqlCommand comandoTotal_Facturas_Pagar = new MySqlCommand("SELECT Fecha_Emision, ROUND(SUM(Total), 2) FROM HFacturas WHERE Estado_Pago = 'Pagada' AND Fecha_Emision BETWEEN @fromDate AND @ToDate ORDER BY Fecha_Emision;", cnx);
                comandoTotal_Facturas_Pagar.Parameters.AddWithValue("@fromDate", StartDate);
                comandoTotal_Facturas_Pagar.Parameters.AddWithValue("@ToDate", EndDate);

                var resulttable = new List<KeyValuePair<DateTime, float>>();

                // Leer los resultados del segundo comando
                using (MySqlDataReader reader = comandoTotal_Facturas_Pagar.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0) && !reader.IsDBNull(1))
                        {
                            DateTime fecha = reader.GetDateTime(0);
                            float total = reader.GetFloat(1);
                            IngresoActual += total;
                            resulttable.Add(new KeyValuePair<DateTime, float>(fecha, total));
                        }
                    }
                    reader.Close();
                }

                if (NumberDays <= 1)
                {
                    foreach (var item in resulttable)
                    {
                        IngresosList.Add(new Ingresos
                        {
                            Fecha = item.Key.ToString("hh tt"),
                            Total = item.Value
                        });
                    }
                }

                // Agrupar resultados por día
               else if (NumberDays <= 30)
                {
                    IngresosList = (from orderList in resulttable
                                    group orderList by orderList.Key.ToString("dd MMM")
                                    into order
                                    select new Ingresos
                                    {
                                        Fecha = order.Key,
                                        Total = order.Sum(amount => amount.Value)
                                    }).ToList();

                }
                // Agrupar por semana
                else if (NumberDays <= 92)
                {
                    IngresosList = (from orderList in resulttable
                                    group orderList by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                        orderList.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                    into order
                                    select new Ingresos
                                    {
                                        Fecha = "Week " + order.Key.ToString(),
                                        Total = order.Sum(amount => amount.Value)
                                    }).ToList();
                }
                // Agrupar por mes
                else if (NumberDays <= (365 * 2))
                {
                    bool isYear = NumberDays <= 365 ? true : false;
                    IngresosList = (from orderList in resulttable
                                    group orderList by orderList.Key.ToString("MMM yyyy")
                                    into order
                                    select new Ingresos
                                    {
                                        Fecha = isYear ? order.Key.Substring(0, order.Key.IndexOf(" ")) : order.Key,
                                        Total = order.Sum(amount => amount.Value)
                                    }).ToList();
                }
                // Agrupar por año
                else
                {
                    IngresosList = (from orderList in resulttable
                                    group orderList by orderList.Key.ToString("yyyy")
                                    into order
                                    select new Ingresos
                                    {
                                        Fecha = order.Key,
                                        Total = order.Sum(amount => amount.Value)
                                    }).ToList();
                }
            }
        }


        public bool LoadTime(DateTime StartDate, DateTime EndDate)
        {
            EndDate = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day,
                EndDate.Hour, EndDate.Minute, 59);

            if(StartDate != this.StartDate ||  EndDate != this.EndDate)
            {
                this.StartDate = StartDate;
                this.EndDate = EndDate;
                this.NumberDays = (StartDate - EndDate).Days;

                GetNumbersItems();
                GetOrdenAnalisis();

                Console.WriteLine("Data actualizada: {0} - {1}", StartDate.ToString(), EndDate.ToString());
                return true;
            }
            else
            {
                Console.WriteLine("Data sin actualizar, mismo query: {0} - {1}", StartDate.ToString(), EndDate.ToString());
                return false;
            }
        }

    }
}


   



    







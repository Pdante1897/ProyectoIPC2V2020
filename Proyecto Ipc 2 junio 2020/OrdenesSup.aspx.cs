using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1
{
    public partial class OrdenesSup : System.Web.UI.Page
    {
        public int orden;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cadena;
            string tipo = (string)Session["tipo"];
            if (tipo.Equals("3"))
            {
                cadena = "select Orden.codigo_Orden as Num, empleado.nit as Empleado, orden.codigo_cliente as Nit, orden.estado as Estado from orden join Empleado on orden.codigo_empleado = Empleado.nit where Empleado.nit_jefe = '" + (string)Session["nomLog"] + "' or orden.codigo_empleado = '" + (string)Session["nomLog"] + "'";

            }
            else 
            {
                cadena = "select Orden.codigo_Orden as Num, empleado.nit as Empleado, orden.codigo_cliente as Nit, orden.estado as Estado from orden join Empleado on orden.codigo_empleado = Empleado.nit where Empleado.nit_jefe = '" + (string)Session["nomLog"] + "'";

            }
            string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(cadena, sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                GridView2.DataSource = dtbl;
                GridView2.DataBind();

                sqlCon.Close();
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
                selectOrdenS();
        }

        public void selectOrdenS() 
        {
            string jefe = "'"+(string)Session["nomLog"]+"'";
            string cadena;
            if ((string)Session["tipo"] == "3")
            {
                jefe = "NUll";
                cadena = ("select Orden.codigo_Orden, orden.estado from orden join Empleado on orden.codigo_empleado = Empleado.nit where orden.codigo_Orden = @ord and (Empleado.nit_jefe = " + jefe + " or Empleado.nit = " + (string)Session["nomLog"] + " or Empleado.nit_jefe = " + (string)Session["nomLog"] + ")");


            }
            else
            {
                cadena = ("select Orden.codigo_Orden, orden.estado from orden join Empleado on orden.codigo_empleado = Empleado.nit where orden.codigo_Orden = @ord and Empleado.nit_jefe = '" + (string)Session["nomLog"] + "'");

            }

            try
            {
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlParameter paror = new SqlParameter("@ord", Int32.Parse(TextBox1.Text));
                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.Add(paror);
                    SqlDataReader lector = sqlDa.ExecuteReader();
                    lector.Read();
                    {
                        Session["ordAp"]=lector.GetInt32(0);
                        Session["ordEs"] = lector.GetString(1);
                    }
                    lector.Close();
                    sqlCon.Close();
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Orden seleccionada!" + "');</script>");

                }
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Orden no encontrada en lista!" + "');</script>");
                orden=0;
            }
        }

        protected void terminarOrden(string vari)
        {
            string cadena = ("UPDATE orden SET estado = '"+vari+"' WHERE [codigo_Orden] = @orden");
            try
            {
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.AddWithValue("@orden", (Int32)Session["ordAp"]);
                    sqlDa.ExecuteNonQuery();
                    sqlCon.Close();
                }
                Session["ordAp"] = null; 
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error verificar datos" + "');</script>");

            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((string)Session["ordEs"]!="pagada"&& (string)Session["ordEs"] != "anulada" && (string)Session["ordEs"] != "espera")
            {
                terminarOrden("aprobada");
            }
            
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if ((string)Session["ordEs"] != "pagada")
            {
                try
                {
                    anularPagos();
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "nota generada" + "');</script>");

                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Orden sin pagos efectuados" + "');</script>");

                }

                terminarOrden("anulada");
            }
        }

        public void anularPagos() 
        {
            
            
            string cadena = ("select  sum(abono) as total from pago where codigo_orden = " + (int)Session["ordAp"]);
            double valor, valor2; 
            string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                SqlDataReader lector2 = sqlDa.ExecuteReader();
                lector2.Read();
                {
                    valor = lector2.GetDouble(0);
                }
                lector2.Close();
                sqlCon.Close();
            }

            string cadena2, cli;
            cadena2 = ("select sum(valor) as total, orden.codigo_cliente from pedido join orden on pedido.codigo_orden = orden.codigo_orden  where pedido.codigo_orden = " + (int)Session["ordAp"] + " group by orden.codigo_cliente");
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlDa = new SqlCommand(cadena2, sqlCon);
                SqlDataReader lector2 = sqlDa.ExecuteReader();
                lector2.Read();
                {
                    valor2 = lector2.GetDouble(0);
                    cli= lector2.GetString(1);
                }
                lector2.Close();
                sqlCon.Close();
            }
            nota(valor2-valor);
            AdFactura(cli);

        }

        public void nota(double valor) 
        {
            string fecha = DateTime.Now.ToString();
            double tasa = (float)Session["tasa"];
            CultureInfo cul = new CultureInfo("en-US");
            string cadena = ("insert into nota values(@orden, @mon, @fecha)");
            //try
            {
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.AddWithValue("@orden", (Int32)Session["ordAp"]);
                    sqlDa.Parameters.AddWithValue("@mon", valor);
                    sqlDa.Parameters.AddWithValue("@fecha", fecha);
                    sqlDa.ExecuteNonQuery();
                    sqlCon.Close();
                }


            }
            //catch (Exception)
            {

            }
        }

        public void AdFactura(string cli)
        {
            string fecha = DateTime.Now.ToString();
            double tasa = (float)Session["tasa"];
            CultureInfo cul = new CultureInfo("en-US");
            int orden = (Int32)Session["ordenP"];
            string cadena = ("insert into Factura values( 'A', @fecha, 'diaproma', @orden, @cli)");
            //try
            {
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.AddWithValue("@orden", (Int32)Session["ordenP"]);
                    sqlDa.Parameters.AddWithValue("@cli", cli);
                    sqlDa.Parameters.AddWithValue("@fecha", fecha);
                    sqlDa.ExecuteNonQuery();
                    sqlCon.Close();
                }


            }
            //catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error al generar recibo" + "');</script>");

            }
        }

    }
}
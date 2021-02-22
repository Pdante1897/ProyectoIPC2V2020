using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Proyecto1
{
    public partial class Pagos : System.Web.UI.Page
    {
        public string moneda;
        public double tasa, valor, restante;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            buscarorden();
        }
        protected void buscarorden()
        {
            float a = 1f;
            Session["moneda"]="$";
            Session["tasa"] =a;
            
            string prueba = a.ToString();
            string cadena = ("SELECT codigo_Orden, estado FROM orden where codigo_orden = @cod ");
            string estado;
            double a2 = 0;
            //try
            {
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlParameter paruser = new SqlParameter("@cod", TextBox1.Text);
                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.Add(paruser);
                    SqlDataReader lector2 = sqlDa.ExecuteReader();
                    lector2.Read();
                    {
                        Session["ordenP"] = lector2.GetInt32(0);
                        estado = lector2.GetString(1);
                        
                        Session["abono"] = a2;
                    }
                    lector2.Close();
                    sqlCon.Close();

                }
                if (estado.Equals("aprobada"))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Orden seleccionada!" + "');</script>");
                    mostrar();

                }
                else if (estado.Equals("pagada"))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "La orden ya fue pagada!" + "');</script>");
                    Session["ordenP"] = null;
                    TextBox1 = null;
                    GridView3.DataSource = null;
                    GridView3.DataBind();

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "La orden no esta aprobada!" + "');</script>");
                    Session["ordenP"] = null;
                    TextBox1 = null;
                    GridView3.DataSource = null;
                    GridView3.DataBind();
                }
            }
            //catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Cliente no encontrado!" + "');</script>");

            }
        }
        public void mostrar()
        {
            string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select producto.nombre, pedido.cantidad, pedido.valor from pedido join producto on Producto.codigo_producto = pedido.codigo_producto where codigo_orden = " + Session["ordenP"] + "", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                GridView3.DataSource = dtbl;
                GridView3.DataBind();

                sqlCon.Close();
            }
            

            string cadena;
            cadena = ("select sum(valor) as total from pedido where codigo_orden= " + Session["ordenP"]);
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                SqlDataReader lector2 = sqlDa.ExecuteReader();
                lector2.Read();
                {
                    valor = lector2.GetDouble(0);
                    Session["valor"] = lector2.GetDouble(0);
                    Session["resta"] = lector2.GetDouble(0);

                    Label17.Text= "Monto total: $"+valor.ToString("0.00");
                    
                }
                lector2.Close();
                sqlCon.Close();
            }

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            buscarMoneda();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            if (validarP())
            {
                
               
                realizarPago();
                MostrarAbono();
            }
            if ((double)Session["abono"] == (double)Session["valor"])
            {
                terminarOrden();
                DaFactura();

            }



        }

        protected void buscarMoneda()
        {
            string cadena;
            cadena = ("SELECT codigo_moneda, simbolo, tasa FROM moneda where codigo_moneda = @cod ");

           //try
            {
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlParameter paruser = new SqlParameter("@cod", TextBox6.Text);
                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.Add(paruser);
                    SqlDataReader lector2 = sqlDa.ExecuteReader();
                    lector2.Read();
                    {
                        Session["moneda"] = lector2.GetString(1);
                        tasa = lector2.GetFloat(2);
                        Session["tasa"] = lector2.GetFloat(2);
                    }
                    lector2.Close();
                    sqlCon.Close();
                    Label17.Text = "Monto total: "+ (string)Session["moneda"] + ((double)Session["valor"]* tasa).ToString("0.00");
                    MostrarAbono();
                }
            }
            //catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Moneda no encontrado!" + "');</script>");

            }


        }
        protected void realizarPago()
        {
            CultureInfo cul = new CultureInfo("en-US");
            double tasa = (float)Session["tasa"];
            string cadena = ("insert into Pago values (@abo, @ord)");
            try
            {
                double valor = (double.Parse(TextBox5.Text,cul) / tasa)-0.00001;
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.AddWithValue("@abo", valor.ToString("0.00",cul));
                    sqlDa.Parameters.AddWithValue("@ord", Session["ordenP"]);
                    sqlDa.ExecuteNonQuery();
                    sqlCon.Close();
                }
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Pago Realizado" + "');</script>");
                
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error verificar datos" + "');</script>");

            }
            aRecibo();

        }
        public void MostrarAbono()
        {
            string cadena = ("SELECT sum(abono) FROM Pago where codigo_orden = @cod ");
            double abono , valor;
            try
            {
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlParameter paruser = new SqlParameter("@cod", TextBox1.Text);
                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.Add(paruser);
                    SqlDataReader lector2 = sqlDa.ExecuteReader();
                    lector2.Read();
                    {
                        Session["abono"] = lector2.GetDouble(0);
                        Session["resta"] = (double)Session["valor"] - (double)Session["abono"];
                        abono = lector2.GetDouble(0);
                        valor = (double)Session["valor"];
                        Label19.Text = "Monto abonado: " + (string)Session["moneda"] + (abono * (float)Session["tasa"]).ToString("0.00");
                        Label20.Text = "Monto restante: " + (string)Session["moneda"] + ((double)Session["resta"] * (float)Session["tasa"]).ToString("0.00");
                        if (valor.ToString("0.00") == abono.ToString("0.00"))
                        {
                            terminarOrden();
                        }
                    }
                    lector2.Close();
                    sqlCon.Close();

                }
                
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Cliente no encontrado!" + "');</script>");
                Label19.Text = null;
                Label20.Text = null;

            }
        }
        public Boolean validarP()
        {
            float tasa = (float)Session["tasa"];

            CultureInfo cul = new CultureInfo("en-US");
            double variable = (double)Session["valor"];
            double variable2 = (double)Session["resta"];

            double valor = double.Parse(TextBox5.Text, cul) / tasa;
            if (Session["resta"] == null)
            {
                if ((double)Session["valor"] >= valor && valor > 0)
                {
                    return true;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Abono fuera de rango!" + "');</script>");

                    return false;
                }

            }
            else
            {
                if (((double)Session["resta"] >= valor) && valor > 0)
                {
                    return true;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Abono fuera de rango!" + "');</script>");

                    return false;
                }
            }
                
            
            
        }
        protected void terminarOrden()
        {
            int orden = (Int32)Session["ordenP"];
            string cadena = ("UPDATE orden SET estado = 'pagada' WHERE [codigo_Orden] = @orden");
            //try
            {
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.AddWithValue("@orden", (Int32)Session["ordenP"]);
                    sqlDa.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            //catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error verificar datos" + "');</script>");

            }


        }
        public void aRecibo() 
        {
            string cadena;
            cadena = ("select orden.codigo_cliente, orden.codigo_empleado from orden where codigo_Orden = @cod ");
            string cli, emp;
            //try
            {
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlParameter paruser = new SqlParameter("@cod", (Int32)Session["ordenP"]);
                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.Add(paruser);
                    SqlDataReader lector2 = sqlDa.ExecuteReader();
                    lector2.Read();
                    {
                        cli = lector2.GetString(0);
                        emp = lector2.GetString(1);
                    }
                    lector2.Close();
                    sqlCon.Close();
                    inRecibo(cli, emp);
                }
            }
            //catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error al guardar recibo !" + "');</script>");

            }
        }

        public void inRecibo(string cli, string emp) 
        {
            string fecha = DateTime.Now.ToString();
            double tasa = (float)Session["tasa"];
            CultureInfo cul = new CultureInfo("en-US");
            double valor = double.Parse(TextBox5.Text, cul) / tasa;
            int orden = (Int32)Session["ordenP"];
            string cadena = ("insert into recibo values(@orden, @cli, @emp, @val, @saldo, @det,@fecha )");
            //try
            {
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.AddWithValue("@orden", (Int32)Session["ordenP"]);
                    sqlDa.Parameters.AddWithValue("@cli", cli);
                    sqlDa.Parameters.AddWithValue("@emp", emp);
                    sqlDa.Parameters.AddWithValue("@val", (double)Session["valor"]);
                    sqlDa.Parameters.AddWithValue("@saldo", valor);
                    sqlDa.Parameters.AddWithValue("@det", (string)Session["moneda"]);
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

        public void DaFactura()
        {
            string cadena;
            cadena = ("select orden.codigo_cliente, orden.codigo_empleado from orden where codigo_Orden = @cod ");
            string cli, emp;
            //try
            {
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlParameter paruser = new SqlParameter("@cod", (Int32)Session["ordenP"]);
                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.Add(paruser);
                    SqlDataReader lector2 = sqlDa.ExecuteReader();
                    lector2.Read();
                    {
                        cli = lector2.GetString(0);
                        emp = lector2.GetString(1);
                    }
                    lector2.Close();
                    sqlCon.Close();
                    AdFactura(cli);
                }
            }
            //catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error al guardar recibo !" + "');</script>");

            }
        }
        public void AdFactura(string cli) 
        {
            string fecha = DateTime.Now.ToString();
            double tasa = (float)Session["tasa"];
            CultureInfo cul = new CultureInfo("en-US");
            double valor = double.Parse(TextBox5.Text, cul) / tasa;
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
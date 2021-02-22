using Proyecto1.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string fecha = DateTime.Now.ToString();
        protected Orden ord;
        protected LinkedList<Producto> pedido = new LinkedList<Producto>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Label17.Text = "Cliente: " + Session["nomCli"]+" Nit: "+ Session["nitC"];

            try
            {
                mostrar();
            }
            catch (Exception)
            {

            }
            

        }

        public void mostrarPrecios() 
        {
            string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT t1.codigo_producto, t1.nombre, t1.descripcion, T2.valor, t3.vigenciaI, t3.vigenciaF FROM Producto as T1 INNER JOIN preciolista as T2 ON T1.codigo_producto = T2.codigo_producto JOIN ListaCliente as T3   ON T2.codigo_precio = T3.codigo_lista WHERE T3.codigo_lista = t2.codigo_precio and t3.nit_cliente= '"+TextBox1.Text+"' and ( t3.vigenciaI<= '" + fecha + "') and ( t3.vigenciaF >= '" + fecha + "') ", sqlCon);
                DataTable dtbl = new DataTable();
                
                sqlDa.Fill(dtbl);
                GridView2.DataSource = dtbl;
                GridView2.DataBind();
                if (GridView2.Rows.Count == 0)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Cliente seleccionado sin lista de precios! Seleccione una lista" + "');</script>");
                }

                sqlCon.Close();
            }
        }

        protected Cliente cli;
        protected void Button1_Click1(object sender, EventArgs e)
        {
            mostrarPrecios();
            ord = new Orden();
            string cadena;
            cadena = ("Select nit_cliente, nombre, apellido, limite, dias_credito  from Cliente  where nit_cliente = @nit");

            try
            {
               
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlParameter paruser = new SqlParameter("@nit", TextBox1.Text);
                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.Add(paruser);
                    SqlDataReader lector = sqlDa.ExecuteReader();
                    lector.Read();
                    {
                        Label17.Text = "Cliente: "+lector.GetString(1)+' '+lector.GetString(2);
                        Session["nitC"] = lector.GetString(0);
                        cli = new Cliente();
                        cli.nit = lector.GetString(0);
                        cli.nombres = lector.GetString(1);
                        cli.apellidos = lector.GetString(2);
                        cli.limite = lector.GetFloat(3);
                        cli.dias = lector.GetInt32(4);
                        Session["nomCli"] = cli.nombres + " " + cli.apellidos;
                        ord.cliente = cli;
                        agregarOrden();
                    }
                    lector.Close();
                    sqlCon.Close();
                    Session["cadenaSql"] = ("SELECT t1.codigo_producto, t1.nombre, t1.descripcion, T2.valor, t3.vigenciaI, t3.vigenciaF FROM Producto as T1 INNER JOIN preciolista as T2 ON T1.codigo_producto = T2.codigo_producto JOIN ListaCliente as T3   ON T2.codigo_precio = T3.codigo_lista WHERE T3.codigo_lista = t2.codigo_precio and t3.nit_cliente= '" + (string)Session["nitC"] + "' and t1.codigo_producto = @pro and ( t3.vigenciaI <= '" + fecha + "') and ( t3.vigenciaF >= '" + fecha + "'); ");
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Cliente seleccionado!" + "');</script>");
                }
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Cliente no encontrado!" + "');</script>");
                TextBox1.Text = null;
                
            }
            buscarorden();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            prueba();
            mostrar();

            
            
        }

        public void prueba() {
            Producto prod = new Producto();
            

            //try
            {
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlParameter parpro = new SqlParameter("@pro", TextBox4.Text);
                    SqlCommand sqlDa = new SqlCommand((string)Session["cadenaSql"], sqlCon);
                    sqlDa.Parameters.Add(parpro);
                    SqlDataReader lector = sqlDa.ExecuteReader();
                    lector.Read();
                    {
                        prod.codigo = lector.GetInt32(0);
                        prod.nombre = lector.GetString(1);
                        prod.descripcion = lector.GetString(2);
                        prod.precio = lector.GetFloat(3);
                        prod.cantidad = Int32.Parse(TextBox5.Text);
                        prod.categoria = 1;
                        pedido.AddLast(prod);
                        AgregarPedido(prod);


                    }
                    lector.Close();
                    sqlCon.Close();
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Producto seleccionado!" + "');</script>");

                }
            }
            //catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Producto no encontrado en lista de precios!" + "');</script>");

            }
        }
        public void AgregarPedido(Producto prod) 
        {
            string cadena = ("insert into Pedido values (@orden, @prod, @cant, @valor )");
            try
            {
                int cantidad = Int32.Parse(TextBox5.Text);
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.AddWithValue("@orden", Session["ordenAc"]);
                    sqlDa.Parameters.AddWithValue("@prod", prod.codigo);
                    sqlDa.Parameters.AddWithValue("@cant", prod.cantidad);
                    sqlDa.Parameters.AddWithValue("@valor", cantidad*prod.precio);

                    sqlDa.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error verificar datos" + "');</script>");

            }
        }
        protected void buscarorden() 
        {
            string cadena;
            cadena = ("SELECT TOP 1 codigo_Orden FROM orden where codigo_cliente = @nit ORDER BY codigo_orden DESC ");

            try
            {
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlParameter paruser = new SqlParameter("@nit", (string)Session["nitC"]);
                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.Add(paruser);
                    SqlDataReader lector2 = sqlDa.ExecuteReader();
                    lector2.Read();
                    {
                        Session["ordenAc"] = lector2.GetInt32(0);
                    }
                    lector2.Close();
                    sqlCon.Close();

                }
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Cliente no encontrado!" + "');</script>");

            }
        }
        protected void agregarOrden()
        {
            string cadena = ("insert into Orden values (@emp, @cli, @pago, 'pendiente')");
            try
            {
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.AddWithValue("@emp", Session["nomlog"].ToString()) ;
                    sqlDa.Parameters.AddWithValue("@cli", Session["nitC"]);
                    sqlDa.Parameters.AddWithValue("@pago", 1);
                    sqlDa.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error verificar datos" + "');</script>");

            }


        }
        public void mostrar() 
        {
            if ((string)Session["nitC"]!=null)
            {
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select producto.nombre, pedido.cantidad, pedido.valor from pedido join producto on Producto.codigo_producto = pedido.codigo_producto where codigo_orden = " + Session["ordenAc"] + "", sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    GridView3.DataSource = dtbl;
                    GridView3.DataBind();

                    sqlCon.Close();
                }
            }
            
        }

        protected void cerrarOrden()
        {
            string cadena = ("UPDATE orden SET estado = 'cerrada' WHERE [codigo_Orden] = @orden");
            try
            {
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.AddWithValue("@orden", Session["ordenAc"]);
                    sqlDa.ExecuteNonQuery();
                    sqlCon.Close();
                }
                TextBox1.Text = null;
                Session["ordenAc"] = null;
                Session["nitC"] = null;
                Session["nomCli"] = null;
                Response.Redirect("inicio");
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error verificar datos" + "');</script>");

            }


        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            cerrarOrden();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Session["cadenaSql"] = ("SELECT t1.codigo_producto, t1.nombre, t1.descripcion, T2.valor, DATEPART(MM, t3.fecha_inicio) as mes_inicio, DATEPART(YY, t3.fecha_inicio) as anio_inicio,DATEPART(MM, t3.fecha_fin) as mes_fin, DATEPART(YY, t3.fecha_fin) as mes_fin FROM Producto as T1 INNER JOIN preciolista as T2   ON T1.codigo_producto = T2.codigo_producto LEFT JOIN precio as T3    ON T2.codigo_precio = T3.codigo_precio WHERE t2.codigo_precio = " + TextBox6.Text + " and t1.codigo_producto = @pro; ");
            string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT t1.codigo_producto, t1.nombre, t1.descripcion, T2.valor FROM Producto as T1 INNER JOIN preciolista as T2 ON T1.codigo_producto = T2.codigo_producto LEFT JOIN precio as T3   ON T2.codigo_precio = T3.codigo_precio WHERE t2.codigo_precio = "+TextBox6.Text+"  ", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                GridView2.DataSource = dtbl;
                GridView2.DataBind();

                sqlCon.Close();
            }
        }
    }
}
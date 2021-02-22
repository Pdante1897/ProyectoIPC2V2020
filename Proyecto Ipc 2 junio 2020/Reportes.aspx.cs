using iTextSharp.text;
using iTextSharp.text.pdf;
using Proyecto1.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
            

        }

        public void generarPdf(string nombre, string detalles) 
        {
            FileStream archivo = new FileStream(Server.MapPath("~/Pdfs/"+nombre+".pdf"),FileMode.Create);
            Document doc = new Document(iTextSharp.text.PageSize.LETTER,10,10,10,10);
            PdfWriter wri = PdfWriter.GetInstance(doc, archivo);
            doc.Open();
            doc.Add(new Paragraph(detalles));
            doc.Close();
        }

        public string obtenerListaP(string fechaI, string fechaF, string nit) 
        {
            string cadena;
            cadena = ("select precio.codigo_precio, precio.nombre from ListaCliente join precio on precio.codigo_precio= ListaCliente.codigo_lista where listaCliente.nit_cliente= @nit and ( ListaCliente.vigenciaI >= '" + fechaI + "') and ( listacliente.vigenciaF <= '" + fechaF+"')");
            string retornar=" ";
            try
            {

                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlParameter paruser = new SqlParameter("@nit", nit);
                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.Add(paruser);
                    SqlDataReader lector = sqlDa.ExecuteReader();
                    lector.Read();
                    {
                        retornar = "Lista: "+ lector.GetInt32(0) +"  nombre: "+ lector.GetString(1);
                        

                    }
                    lector.Close();
                    sqlCon.Close();
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Cliente seleccionado!" + "');</script>");
                }
                return retornar;
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Cliente no encontrado!" + "');</script>");
                return null;
            }
        }

        public string obtenerCli(string nit)
        {
            Cliente cli = new Cliente();
            string cadena;
            cadena = ("Select nit_cliente, nombre, apellido, direccion from Cliente  where nit_cliente = @nit");

            try
            {

                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlParameter paruser = new SqlParameter("@nit", nit);
                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.Add(paruser);
                    SqlDataReader lector = sqlDa.ExecuteReader();
                    lector.Read();
                    {
                        Session["nitC"] = lector.GetString(0);
                        cli.nit = lector.GetString(0);
                        cli.nombres = lector.GetString(1);
                        cli.apellidos = lector.GetString(2);
                        cli.direccion = lector.GetString(3);

                    }
                    lector.Close();
                    sqlCon.Close();
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Cliente seleccionado!" + "');</script>");
                }
                return "nit: "+cli.nit+" nombre: "+cli.nombres + " " + cli.apellidos + " direccion: " + cli.direccion; 
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Cliente no encontrado!" + "');</script>");
                return null;
            }
        }
        public string obtenerProd(string fechaI, string  fechaF, string nit) 
        {
            string retornar="De: "+fechaI+ "  Hasta: " + fechaF +'\n';
            string cadena = ("Select producto.nombre, pedido.cantidad, pedido.valor from pedido join producto on Producto.codigo_producto = pedido.codigo_producto join orden on orden.codigo_Orden = pedido.codigo_orden join Factura on factura.codigo_orden= Orden.codigo_Orden where orden.codigo_cliente='" + nit + "' and ( factura.fecha >= '" + fechaI + "') and ( factura.fecha  <= '" + fechaF+"')");
            string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";
            List<Producto> listaP = new List<Producto>();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlParameter paruser = new SqlParameter("@nit", nit);
                SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                sqlDa.Parameters.Add(paruser);
                SqlDataReader lector = sqlDa.ExecuteReader();
                while (lector.Read()) 
                {
                    Producto pro = new Producto();
                    pro.nombre = lector.GetString(0);
                    pro.cantidad = lector.GetInt32(1);
                    pro.precio = lector.GetFloat(2);

                    listaP.Add(pro);
                }
            }

            foreach (var item in listaP)
            {
                retornar = retornar + "|Producto: "+item.nombre+"    Precio: "+item.precio+"    Cantidad: "+item.cantidad+ '\n' ;
            }

            string cadena2 = ("Select sum(pedido.valor) from pedido join producto on Producto.codigo_producto = pedido.codigo_producto join orden on orden.codigo_Orden = pedido.codigo_orden join Factura on factura.codigo_orden= Orden.codigo_Orden where orden.codigo_cliente='" + nit + "' and ( factura.fecha >= '" + fechaI + "') and ( factura.fecha  <= '" + fechaF + "')");
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlParameter paruser = new SqlParameter("@nit", nit);
                SqlCommand sqlDa = new SqlCommand(cadena2, sqlCon);
                sqlDa.Parameters.Add(paruser);
                SqlDataReader lector = sqlDa.ExecuteReader();
                lector.Read();
                {
                    retornar = retornar + "sumatoria: " + lector.GetDouble(0).ToString("0.00");
                }

                return retornar;
            }
        }

        public string obtenerPago(string fechaI, string fechaF, string nit)
        {
            string retornar = "De: " + fechaI + "  Hasta: " + fechaF + '\n';
            string cadena = ("select recibo.fecha, recibo.codigo_orden, recibo.detalle, moneda.tasa, recibo.saldoP  from pago join recibo on pago.codigo_orden = recibo.codigo_orden join moneda on moneda.simbolo=Recibo.detalle where recibo.codigo_cliente ='" + nit + "' and ( recibo.fecha >= '" + fechaI + "') and ( recibo.fecha  <= '" + fechaF + "')");
            string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";
            List<Recibo> listaR = new List<Recibo>();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlParameter paruser = new SqlParameter("@nit", nit);
                SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                sqlDa.Parameters.Add(paruser);
                SqlDataReader lector = sqlDa.ExecuteReader();
                while (lector.Read())
                {
                    Recibo re = new Recibo();
                    re.fecha = lector.GetDateTime(0).ToString();
                    re.orden = lector.GetInt32(1);
                    re.moneda = lector.GetString(2);
                    re.tasa = lector.GetFloat(3);
                    re.monto = lector.GetFloat(4);

                    listaR.Add(re);
                }
            }

            foreach (var item in listaR)
            {
                retornar = retornar + "|fecha: " + item.fecha + "    orden: " + item.orden + "    moneda: " + item.moneda + "    tasa: " + item.tasa + "    monto: " + item.monto + '\n';
            }

            string cadena2 = ("select sum(recibo.saldoP) from pago join recibo on pago.codigo_orden = recibo.codigo_orden join moneda on moneda.simbolo = Recibo.detalle where recibo.codigo_cliente = '" + nit + "' and(recibo.fecha >= '" + fechaI + "') and(recibo.fecha <= '" + fechaF + "')");
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlParameter paruser = new SqlParameter("@nit", nit);
                SqlCommand sqlDa = new SqlCommand(cadena2, sqlCon);
                sqlDa.Parameters.Add(paruser);
                SqlDataReader lector = sqlDa.ExecuteReader();
                lector.Read();
                {
                    retornar = retornar + "sumatoria: " + lector.GetDouble(0).ToString("0.00");
                }

                return retornar;
            }
        }

        public string obtenerNota(string fechaI, string fechaF, string nit)
        {
            string retornar = "De: " + fechaI + "  Hasta: " + fechaF + '\n';
            string cadena = ("select nota.fecha, nota.codigo_orden, nota.monto from nota join orden on orden.codigo_orden = nota.codigo_orden where orden.codigo_cliente = '" + nit + "' and ( nota.fecha >= '" + fechaI + "') and ( nota.fecha  <= '" + fechaF + "')");
            string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";
            List<Recibo> listaR = new List<Recibo>();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlParameter paruser = new SqlParameter("@nit", nit);
                SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                sqlDa.Parameters.Add(paruser);
                SqlDataReader lector = sqlDa.ExecuteReader();
                while (lector.Read())
                {
                    Recibo re = new Recibo();
                    re.fecha = lector.GetDateTime(0).ToString();
                    re.orden = lector.GetInt32(1);
                    re.monto = lector.GetFloat(2);

                    listaR.Add(re);
                }
            }

            foreach (var item in listaR)
            {
                retornar = retornar + "|fecha: " + item.fecha + "    orden: " + item.orden + "    monto: " + item.monto + '\n';
            }

            string cadena2 = ("select  sum(nota.monto) from nota join orden on orden.codigo_orden = nota.codigo_orden where orden.codigo_cliente = '" + nit + "' and ( nota.fecha >= '" + fechaI + "') and ( nota.fecha  <= '" + fechaF + "')");
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlParameter paruser = new SqlParameter("@nit", nit);
                SqlCommand sqlDa = new SqlCommand(cadena2, sqlCon);
                sqlDa.Parameters.Add(paruser);
                SqlDataReader lector = sqlDa.ExecuteReader();
                lector.Read();
                {
                    retornar = retornar + "sumatoria: " + lector.GetDouble(0).ToString("0.00");
                }

                return retornar;
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string cadena = "Ventas por Cliente " + '\n' +
                "----------------------------------" + '\n' +
                obtenerListaP(TextBox4.Text, TextBox5.Text, TextBox1.Text) + '\n' +
                "----------------------------------" + '\n' +
                obtenerProd(TextBox4.Text, TextBox5.Text, TextBox1.Text) + '\n' +
                "----------------------------------" + '\n' +
                "Detalle de pago" + '\n'+
                obtenerPago(TextBox4.Text, TextBox5.Text, TextBox1.Text) + '\n'+
                "----------------------------------" + '\n' +
                "Detalle de Notas de credito por anulacion" + '\n' +
                obtenerNota(TextBox4.Text, TextBox5.Text, TextBox1.Text) + '\n';

            generarPdf("hola mundo", cadena);

            Response.ContentType = TextBox1.Text+"/pdf";
            Response.TransmitFile(Server.MapPath("~/Pdfs/"+TextBox1.Text+".pdf"));
        }
    }
}
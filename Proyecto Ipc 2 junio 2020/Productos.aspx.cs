using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Proyecto1.Clases;

namespace Proyecto1
{
    public partial class Productos : System.Web.UI.Page
    {
        CultureInfo cul = new CultureInfo("en-US");

        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT t1.codigo_producto, t1.nombre, t1.descripcion, T2.valor, t3.fecha_inicio, t3.fecha_fin FROM Producto as T1 INNER JOIN preciolista as T2 ON T1.codigo_producto = T2.codigo_producto LEFT JOIN precio as T3   ON T2.codigo_precio = T3.codigo_precio WHERE T3.codigo_precio = t2.codigo_precio; ", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                GridView2.DataSource = dtbl;
                GridView2.DataBind();
                
                sqlCon.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(FileUpload2.FileName);
            Console.WriteLine(ext);
            if (FileUpload2.HasFile)
            {
                if (ext.Equals(".xml"))
                {
                    FileUpload2.SaveAs(Server.MapPath("~/ArchivosXml/Categorias.xml"));
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Se subio con exito" + "');</script>");
                    //try
                    {
                        CargarCategorias();
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Se cargaron los datos con exito" + "');</script>");

                    }
                    //catch (Exception)
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error al cargar datos" + "');</script>");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error! El archivo debe ser tipo XML" + "');</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error! Seleccione un archivo XML" + "');</script>");
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(FileUpload3.FileName);
            Console.WriteLine(ext);
            if (FileUpload3.HasFile)
            {
                if (ext.Equals(".xml"))
                {
                    FileUpload3.SaveAs(Server.MapPath("~/ArchivosXml/Productos.xml"));
                    try
                    {
                        CargarProductos();
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Se cargaron los datos con exito" + "');</script>");

                    }
                    catch (Exception)
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error al cargar datos" + "');</script>");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error! El archivo debe ser tipo XML" + "');</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error! Seleccione un archivo XML" + "');</script>");
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(FileUpload4.FileName);
            Console.WriteLine(ext);
            if (FileUpload4.HasFile)
            {
                if (ext.Equals(".xml"))
                {
                    FileUpload4.SaveAs(Server.MapPath("~/ArchivosXml/Precios.xml"));
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Se subio con exito" + "');</script>");
                    //try
                    {
                        CargarPrecios();
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Se cargaron los datos con exito" + "');</script>");

                    }
                    //catch (Exception)
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error al cargar datos" + "');</script>");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error! El archivo debe ser tipo XML" + "');</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error! Seleccione un archivo XML" + "');</script>");
            }
        }
        public void CargarCategorias()
        {
            string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";
            SqlConnection cone = new SqlConnection(connectionString);
            XmlDocument archivo = new XmlDocument();
            archivo.Load(Server.MapPath("~/ArchivosXml/Categorias.xml"));
            cone.Open();
            int numero = 0;
            foreach (XmlElement item in archivo.DocumentElement)
            {
                Categoria cat = new Categoria();
                for (int i = 0; i < item.ChildNodes.Count; i++)
                {
                    string valor = item.ChildNodes[i].InnerText.Trim();

                    switch (item.ChildNodes[i].Name.ToLower())
                    {
                        case "codigo":
                            cat.codigo = Int32.Parse(valor);
                            break;
                        case "nombre":
                            cat.nombre = valor;
                            break;
                        default:
                            numero++;
                            Console.WriteLine(numero);
                            break;
                    }
                }

                
                    SqlCommand cmd = new SqlCommand(String.Format($"insert into Categoria values ({cat.codigo},'{cat.nombre}')"), cone);
                    cmd.ExecuteNonQuery();
                

            }
            cone.Close();
        }
        public void CargarProductos()
        {
            string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";
            SqlConnection cone = new SqlConnection(connectionString);
            XmlDocument archivo = new XmlDocument();
            archivo.Load(Server.MapPath("~/ArchivosXml/Productos.xml"));
            cone.Open();
            int numero = 0;
            foreach (XmlElement item in archivo.DocumentElement)
            {
                Producto pro = new Producto();
                for (int i = 0; i < item.ChildNodes.Count; i++)
                {
                    string valor = item.ChildNodes[i].InnerText.Trim();

                    switch (item.ChildNodes[i].Name.ToLower())
                    {
                        case "codigo":
                            pro.codigo = Int32.Parse(valor);
                            break;
                        case "nombre":
                            pro.nombre = valor;
                            break;
                        case "descripcion":
                            pro.descripcion = valor;
                            break;
                        case "categoria":
                            pro.categoria= Int32.Parse(valor);
                            break;
                        default:
                            numero++;
                            Console.WriteLine(numero);
                            break;
                    }
                }


                SqlCommand cmd = new SqlCommand(String.Format($"insert into Producto values ({pro.codigo},'{pro.nombre}',{pro.categoria},'{pro.descripcion}')"), cone);
                cmd.ExecuteNonQuery();


            }
            cone.Close();
        }
        public void CargarPrecios()
        {
            string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";
            SqlConnection cone = new SqlConnection(connectionString);
            XmlDocument archivo = new XmlDocument();
            archivo.Load(Server.MapPath("~/ArchivosXml/Precios.xml"));
            cone.Open();
            int numero = 0;
            foreach (XmlElement item in archivo.DocumentElement)
            {
                Precio pre = new Precio();
                for (int i = 0; i < item.ChildNodes.Count; i++)
                {
                    string valor = item.ChildNodes[i].InnerText.Trim();

                    switch (item.ChildNodes[i].Name.ToLower())
                    {
                        case "codigo":
                            pre.codigo = Int32.Parse(valor);
                            break;
                        case "nombre":
                            pre.nombre = valor;
                            break;
                        case "fecha_inicio":
                            pre.fechaI = valor;
                            break;
                        case "fecha_fin":
                            pre.fechaF = valor;
                            break;
                        case "detalle":

                            if (pre.fechaF==null||pre.fechaI==null)
                            {
                                SqlCommand cmd1 = new SqlCommand(String.Format($"insert into Precio values ({pre.codigo},'{pre.nombre}', NULL, NULL)"), cone);
                                cmd1.ExecuteNonQuery();

                            }
                            else
                            {
                                SqlCommand cmd2 = new SqlCommand(String.Format($"insert into Precio values ({pre.codigo},'{pre.nombre}','{pre.fechaI}','{pre.fechaF}')"), cone);
                                cmd2.ExecuteNonQuery();
                            }
                            XmlDataDocument detalle = new XmlDataDocument();
                            detalle.InnerXml = item.ChildNodes[i].OuterXml;
                            foreach (XmlElement item2 in detalle.DocumentElement)
                            {
                                Precio det = new Precio();
                                for (int j = 0; j < item2.ChildNodes.Count; j++)
                                {
                                    string valor2 = item2.ChildNodes[j].InnerText.Trim();

                                    switch (item2.ChildNodes[j].Name.ToLower())
                                    {
                                        case "codigo_producto":
                                            det.producto = Int32.Parse(valor2);
                                            break;
                                        case "valor":
                                            det.precio = double.Parse(valor2,cul);
                                            break;
                                        default:
                                            numero++;
                                            Console.WriteLine(numero);
                                            break;
                                    }
                                    if ((det.producto != 0 && det.precio != 0))
                                    {
                                        string precio = det.precio.ToString("0.00", cul);
                                        SqlCommand cmd2 = new SqlCommand(String.Format($"insert into PrecioLista values ({pre.codigo}, {det.producto}, {precio})"), cone);
                                        cmd2.ExecuteNonQuery();
                                       
                                    }
                                    
                                }
                            }
                            break;
                        default:
                            numero++;
                            Console.WriteLine(numero);
                            break;
                    }
                }


                


            }
            cone.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(FileUpload5.FileName);
            Console.WriteLine(ext);
            if (FileUpload5.HasFile)
            {
                if (ext.Equals(".xml"))
                {
                    FileUpload5.SaveAs(Server.MapPath("~/ArchivosXml/Monedas.xml"));
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Se subio con exito" + "');</script>");
                    //try
                    {
                        CargarMonedas();
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Se cargaron los datos con exito" + "');</script>");

                    }
                    //catch (Exception)
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error al cargar datos" + "');</script>");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error! El archivo debe ser tipo XML" + "');</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error! Seleccione un archivo XML" + "');</script>");
            }
        }

        public void CargarMonedas() 
        {
            string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";
            SqlConnection cone = new SqlConnection(connectionString);
            XmlDocument archivo = new XmlDocument();
            archivo.Load(Server.MapPath("~/ArchivosXml/Monedas.xml"));
            cone.Open();
            int numero = 0;
            foreach (XmlElement item in archivo.DocumentElement)
            {
                Moneda mo = new Moneda();
                for (int i = 0; i < item.ChildNodes.Count; i++)
                {
                    string valor = item.ChildNodes[i].InnerText.Trim();

                    switch (item.ChildNodes[i].Name.ToLower())
                    {
                        case "nombre":
                            mo.nombre = valor;
                            break;
                        case "simbolo":
                            mo.simbolo = char.Parse(valor);
                            break;
                        case "tasa":
                            mo.tasa = double.Parse(valor,cul);
                            break;
                        default:
                            numero++;
                            Console.WriteLine(numero);
                            break;
                    }
                }

                string tasa = mo.tasa.ToString("0.00",cul);
                SqlCommand cmd = new SqlCommand(String.Format($"insert into Moneda values ('{mo.nombre}','{mo.simbolo}',{tasa})"), cone);
                cmd.ExecuteNonQuery();


            }
            cone.Close();
        }
    }
}
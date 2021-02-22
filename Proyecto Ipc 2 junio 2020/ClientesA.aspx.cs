using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;
using System.Xml;
using Proyecto1.Clases;

namespace Proyecto1
{
    public partial class ClientesA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Cliente", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                GridView2.DataSource = dtbl;
                GridView2.DataBind();
            }
        }
        protected void basedeDatos()
        {
            string ape;
            if (TextBox3.Text.Equals(""))
            {
                ape = "NULL";
            }
            else
            {
                ape = "'" + TextBox3.Text + "'";
            }
            string cadena;
            cadena = ("insert into Cliente values (@nit, @nom, " + ape + ", @fecha, @dir, @tel, @cel, @email, @ciu, @dep, @lim, @dias)");

            //try
            {
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.AddWithValue("@nit", TextBox1.Text);
                    sqlDa.Parameters.AddWithValue("@nom", TextBox2.Text);
                    sqlDa.Parameters.AddWithValue("@fecha", TextBox4.Text);
                    sqlDa.Parameters.AddWithValue("@dir", TextBox5.Text);
                    sqlDa.Parameters.AddWithValue("@tel", TextBox6.Text);
                    sqlDa.Parameters.AddWithValue("@cel", TextBox7.Text);
                    sqlDa.Parameters.AddWithValue("@email", TextBox8.Text);
                    sqlDa.Parameters.AddWithValue("@ciu", TextBox9.Text);
                    sqlDa.Parameters.AddWithValue("@dep", TextBox10.Text);
                    sqlDa.Parameters.AddWithValue("@lim", TextBox11.Text);
                    sqlDa.Parameters.AddWithValue("@dias", TextBox12.Text);

                    sqlDa.ExecuteNonQuery();
                    sqlCon.Close();
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Se ha registrado correctamente!" + "');</script>");

                }
            }
            //catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error verificar datos" + "');</script>");

            }

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            basedeDatos();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(FileUpload1.FileName);
            Console.WriteLine(ext);
            if (FileUpload1.HasFile)
            {
                if (ext.Equals(".xml"))
                {
                    FileUpload1.SaveAs(Server.MapPath("~/ArchivosXml/clientes.xml"));
                   // try
                    {
                        CargarClientes();
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Se cargaron los datos con exito" + "');</script>");

                    }
                   // catch (Exception)
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
        public void CargarClientes()
        {
            string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";
            SqlConnection cone = new SqlConnection(connectionString);
            XmlDocument archivo = new XmlDocument();
            archivo.Load(Server.MapPath("~/ArchivosXml/clientes.xml"));
            cone.Open();
            int numero = 0;
            foreach (XmlElement item in archivo.DocumentElement)
            {
                Cliente cl = new Cliente();
                for (int i = 0; i < item.ChildNodes.Count; i++)
                {
                    string valor = item.ChildNodes[i].InnerText.Trim();
                    switch (item.ChildNodes[i].Name.ToLower())
                    {
                        case "nit":
                            cl.nit = valor;
                            break;
                        case "nombres":
                            cl.nombres = valor;
                            break;
                        case "apellidos":
                            cl.apellidos = valor;
                            break;
                        case "nacimiento":
                            cl.fecha = valor;
                            break;
                        case "direccion":
                            cl.direccion = valor;
                            break;
                        case "telefono":
                            cl.telefono = valor;
                            break;
                        case "celular":
                            cl.celular = valor;
                            break;
                        case "email":
                            cl.email = valor;
                            break;
                        case "ciudad":
                            cl.ciudad = int.Parse(valor);
                            break;
                        case "depto":
                            cl.departamento= int.Parse(valor);
                            break;
                        case "limite_credito":
                            cl.limite = double.Parse(valor);
                            break;
                        case "dias_credito":
                            cl.dias = int.Parse(valor);
                            break;
                        default:
                            numero++;
                            Console.WriteLine(numero);
                            break;
                    }
                }
                if (cl.apellidos == "null"|| cl.apellidos.Equals(""))
                {
                    SqlCommand cmd = new SqlCommand(String.Format($"insert into Cliente values ('{cl.nit}','{cl.nombres}', NULL,'{cl.fecha}','{cl.direccion}','{cl.telefono}','{cl.celular}','{cl.email}',{cl.ciudad},'{cl.departamento}',{cl.limite},{cl.dias})"), cone);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(String.Format($"insert into Cliente values ('{cl.nit}','{cl.nombres}', '{cl.apellidos}','{cl.fecha}','{cl.direccion}','{cl.telefono}','{cl.celular}','{cl.email}',{cl.ciudad},'{cl.departamento}',{cl.limite},{cl.dias})"), cone);
                    cmd.ExecuteNonQuery();
                    cl.apellidos = null;
                }
            }
            cone.Close();
        }

        public void CargarDepartamentos()
        {
            string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";
            SqlConnection cone = new SqlConnection(connectionString);
            XmlDocument archivo = new XmlDocument();
            archivo.Load(Server.MapPath("~/ArchivosXml/Departamentos.xml"));
            cone.Open();
            int numero = 0;
            foreach (XmlElement item in archivo.DocumentElement)
            {
                Departamento dep = new Departamento();
                for (int i = 0; i < item.ChildNodes.Count; i++)
                {
                    string valor = item.ChildNodes[i].InnerText.Trim();

                    switch (item.ChildNodes[i].Name.ToLower())
                    {
                        case "codigo":
                            dep.codigo = Int32.Parse(valor);
                            break;
                        case "nombre":
                            dep.nombre = valor;
                            break;
                        default:
                            numero++;
                            Console.WriteLine(numero);
                            break;
                    }
                }
                SqlCommand cmd = new SqlCommand(String.Format($"insert into Departamento values ({dep.codigo},'{dep.nombre}')"), cone);
                cmd.ExecuteNonQuery();
            }
            cone.Close();
        }
        public void CargarCiudades()
        {
            string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";
            SqlConnection cone = new SqlConnection(connectionString);
            XmlDocument archivo = new XmlDocument();
            archivo.Load(Server.MapPath("~/ArchivosXml/Ciudades.xml"));
            cone.Open();
            int numero = 0;
            foreach (XmlElement item in archivo.DocumentElement)
            {
                Ciudad ciu = new Ciudad();
                for (int i = 0; i < item.ChildNodes.Count; i++)
                {
                    string valor = item.ChildNodes[i].InnerText.Trim();

                    switch (item.ChildNodes[i].Name.ToLower())
                    {
                        case "codigo":
                            ciu.codigo = Int32.Parse(valor);
                            break;
                        case "nombre":
                            ciu.nombre = valor;
                            break;
                        case "codigo_departamento":
                            ciu.dep = Int32.Parse(valor);
                            break;
                        default:
                            numero++;
                            Console.WriteLine(numero);
                            break;
                    }
                }


                SqlCommand cmd = new SqlCommand(String.Format($"insert into Municipio values ({ciu.codigo},'{ciu.nombre}',{ciu.dep})"), cone);
                cmd.ExecuteNonQuery();


            }
            cone.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(FileUpload2.FileName);
            Console.WriteLine(ext);
            if (FileUpload2.HasFile)
            {
                if (ext.Equals(".xml"))
                {
                    FileUpload2.SaveAs(Server.MapPath("~/ArchivosXml/Departamentos.xml"));
                    try
                    {
                        CargarDepartamentos();
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(FileUpload3.FileName);
            Console.WriteLine(ext);
            if (FileUpload3.HasFile)
            {
                if (ext.Equals(".xml"))
                {
                    FileUpload3.SaveAs(Server.MapPath("~/ArchivosXml/Ciudades.xml"));
                    try
                    {
                        CargarCiudades();
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

        protected void Button5_Click(object sender, EventArgs e)
        {
            string cadena;
            cadena = ("insert into ListaCliente values (@nit, @codL, @vigI, @vigF)");

            //try
            {
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.AddWithValue("@nit", TextBox13.Text);
                    sqlDa.Parameters.AddWithValue("@codL", TextBox14.Text);
                    sqlDa.Parameters.AddWithValue("@vigI", TextBox15.Text);
                    sqlDa.Parameters.AddWithValue("@vigF", TextBox16.Text);
                    sqlDa.ExecuteNonQuery();
                    sqlCon.Close();
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Se ha registrado correctamente!" + "');</script>");

                }
            }
            //catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error verificar datos" + "');</script>");

            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(FileUpload4.FileName);
            Console.WriteLine(ext);
            if (FileUpload4.HasFile)
            {
                if (ext.Equals(".xml"))
                {
                    FileUpload4.SaveAs(Server.MapPath("~/ArchivosXml/listaC.xml"));
                    // try
                    {
                        CargarListas();
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Se cargaron los datos con exito" + "');</script>");

                    }
                    // catch (Exception)
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
        
        public void CargarListas() 
        {
            string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";
            SqlConnection cone = new SqlConnection(connectionString);
            XmlDocument archivo = new XmlDocument();
            archivo.Load(Server.MapPath("~/ArchivosXml/listaC.xml"));
            cone.Open();
            int numero = 0;
            foreach (XmlElement item in archivo.DocumentElement)
            {
                Lista Lc = new Lista();
                for (int i = 0; i < item.ChildNodes.Count; i++)
                {
                    string valor = item.ChildNodes[i].InnerText.Trim();
                    switch (item.ChildNodes[i].Name.ToLower())
                    {
                        case "cliente":
                            Lc.cliente = valor;
                            break;
                        case "codigo_lista":
                            Lc.codigoL = Int32.Parse(valor);
                            break;
                        case "vigencia_inicio":
                            Lc.vigI = valor;
                            break;
                        case "vigencia_final":
                            Lc.vigF = valor;
                            break;
                        default:
                            numero++;
                            Console.WriteLine(numero);
                            break;
                    }
                }
                SqlCommand cmd = new SqlCommand(String.Format($"insert into ListaCliente values ('{Lc.cliente}',{Lc.codigoL}, '{Lc.vigI}','{Lc.vigF}')"), cone);
                cmd.ExecuteNonQuery();
            }
            cone.Close();
        }
    }
}
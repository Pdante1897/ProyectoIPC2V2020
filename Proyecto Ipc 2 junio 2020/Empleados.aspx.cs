using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Proyecto1.Clases;

namespace Proyecto1
{
    public partial class Empleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Empleado", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                GridView2.DataSource = dtbl;
                GridView2.DataBind();
            }
        }

        

        protected void basedeDatos()
        {
            string nitJ;
            if (TextBox10.Text.Equals(""))
            {
                nitJ = "NULL";
            }
            else
            {
                nitJ = "'"+TextBox10.Text+"'";
            }
            string cadena;
            cadena = ("insert into Empleado values (@nit, @nom, @ape, @fecha, @dir, @tel, @cel, @email, @pues, @pass, "+ nitJ +")");

            try
            {
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.AddWithValue("@nit", TextBox1.Text);
                    sqlDa.Parameters.AddWithValue("@nom", TextBox2.Text);
                    sqlDa.Parameters.AddWithValue("@ape", TextBox3.Text);
                    sqlDa.Parameters.AddWithValue("@fecha", TextBox4.Text);
                    sqlDa.Parameters.AddWithValue("@dir", TextBox5.Text);
                    sqlDa.Parameters.AddWithValue("@tel", TextBox6.Text);
                    sqlDa.Parameters.AddWithValue("@cel", TextBox7.Text);
                    sqlDa.Parameters.AddWithValue("@email", TextBox8.Text);
                    sqlDa.Parameters.AddWithValue("@pues", TextBox9.Text);
                    sqlDa.Parameters.AddWithValue("@pass", TextBox11.Text);
                    sqlDa.ExecuteNonQuery();
                    sqlCon.Close();
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Se ha registrado correctamente!" + "');</script>");

                }
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error verificar datos" + "');</script>");
                
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
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
                    FileUpload1.SaveAs(Server.MapPath("~/ArchivosXml/Empleados.xml"));
                    //try
                    {
                        CargarEmpleados();
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
        public void CargarEmpleados()
        {
            string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";
            SqlConnection cone = new SqlConnection(connectionString);
            XmlDocument archivo = new XmlDocument();
            archivo.Load(Server.MapPath("~/ArchivosXml/Empleados.xml"));
            cone.Open();
            int numero = 0;
            foreach (XmlElement item in archivo.DocumentElement)
            {
                Empleado em = new Empleado();
                for (int i = 0; i < item.ChildNodes.Count; i++)
                {
                    string valor = item.ChildNodes[i].InnerText.Trim();

                    switch (item.ChildNodes[i].Name.ToLower())
                    {
                        case "nit":
                            em.nit = valor;
                            break;
                        case "nombres":
                            em.nombres = valor;
                            break;
                        case "apellidos":
                            em.apellidos = valor;
                            break;
                        case "nacimiento":
                            em.fecha = valor;
                            break;
                        case "direccion":
                            em.direccion = valor;
                            break;
                        case "telefono":
                            em.telefono = valor;
                            break;
                        case "celular":
                            em.celular = valor;
                            break;
                        case "email":
                            em.email = valor;
                            break;
                        case "codigo_puesto":
                            em.puesto = int.Parse(valor);
                            break;
                        case "pass":
                            em.pass = valor;
                            break;
                        case "codigo_jefe":
                            em.nitJefe = valor;
                            break;
                        default:
                            numero++;
                            Console.WriteLine(numero);
                            break;
                    }
                }

                if (em.nitJefe == "null" || em.nitJefe.Equals(""))
                {
                    SqlCommand cmd = new SqlCommand(String.Format($"insert into Empleado values ('{em.nit}','{em.nombres}', '{em.apellidos}','{em.fecha}','{em.direccion}','{em.telefono}','{em.celular}','{em.email}',{em.puesto},'{em.pass}', NULL)"), cone);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(String.Format($"insert into Empleado values ('{em.nit}','{em.nombres}', '{em.apellidos}','{em.fecha}','{em.direccion}','{em.telefono}','{em.celular}','{em.email}',{em.puesto},'{em.pass}','{em.nitJefe}' )"), cone);
                    cmd.ExecuteNonQuery();
                    em.nitJefe = null;
                }
                
            }
            cone.Close();
        }
    }
}
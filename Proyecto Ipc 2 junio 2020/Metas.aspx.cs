using Proyecto1.Clases;
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

namespace Proyecto1
{
    public partial class Metas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select codigo_meta, nit_empleado, DATEPART(MM, mes) as mes, DATEPART(YY, mes) as anio from meta", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                GridView2.DataSource = dtbl;
                GridView2.DataBind();
                SqlDataAdapter sqlDa2 = new SqlDataAdapter("select ListaMeta.codigo_listaM as id, ListaMeta.codigo_meta , producto.nombre, listameta.valor from ListaMeta join Producto on ListaMeta.codigo_producto = producto.codigo_producto", sqlCon);
                DataTable dtbl2 = new DataTable();
                sqlDa2.Fill(dtbl2);
                GridView3.DataSource = dtbl2;
                GridView3.DataBind();
                sqlCon.Close();
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
                    FileUpload3.SaveAs(Server.MapPath("~/ArchivosXml/Metas.xml"));
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Se subio con exito" + "');</script>");
                    //try
                    {
                        CargarMetas();
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
        public void CargarMetas()
        {
            string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";
            SqlConnection cone = new SqlConnection(connectionString);
            XmlDocument archivo = new XmlDocument();
            archivo.Load(Server.MapPath("~/ArchivosXml/Metas.xml"));
            cone.Open();
            int numero = 0;
            foreach (XmlElement item in archivo.DocumentElement)
            {
                Meta meta = new Meta();
                for (int i = 0; i < item.ChildNodes.Count; i++)
                {
                    string valor = item.ChildNodes[i].InnerText.Trim();

                    switch (item.ChildNodes[i].Name.ToLower())
                    {
                        case "nit_empleado":
                            meta.nitE = valor;
                            break;
                        case "mes_meta":
                            meta.mes = "1/"+valor;
                            break;
                        case "detalle":
                            SqlCommand cmd = new SqlCommand(String.Format($"insert into Meta values ('{meta.nitE}','{meta.mes}')"), cone);
                            cmd.ExecuteNonQuery();
                            XmlDataDocument detalle = new XmlDataDocument();
                            detalle.InnerXml = item.ChildNodes[i].OuterXml;
                            foreach (XmlElement item2 in detalle.DocumentElement)
                            {
                                Meta det = new Meta();
                                for (int j = 0; j < item2.ChildNodes.Count; j++)
                                {
                                    string valor2 = item2.ChildNodes[j].InnerText.Trim();

                                    switch (item2.ChildNodes[j].Name.ToLower())
                                    {
                                        case "codigo_producto":
                                            det.producto = Int32.Parse(valor2);
                                            break;
                                        case "meta_venta":
                                            det.metaV = double.Parse(valor2);
                                            break;
                                        default:
                                            numero++;
                                            Console.WriteLine(numero);
                                            break;
                                    }
                                    if ((det.producto!=0 && det.metaV!=0))
                                    {
                                        int codigo = codigoM(meta.nitE, meta.mes);
                                        SqlCommand cmd2 = new SqlCommand(String.Format($"insert into ListaMeta values ({codigo}, {det.producto}, {det.metaV})"), cone);
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

        protected int codigoM(string nit, string mes)
        {
            string cadena; 
            int codigo;
            cadena = ("Select codigo_meta from meta where nit_empleado = @nit AND mes = @mes");

            try
            {
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlParameter parmeta = new SqlParameter("@nit", nit);
                    SqlParameter parmes = new SqlParameter("@mes", mes);

                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.Add(parmeta);
                    sqlDa.Parameters.Add(parmes);

                    SqlDataReader lector = sqlDa.ExecuteReader();
                    lector.Read();
                    {
                        codigo = lector.GetInt32(0);
                    }
                    lector.Close();
                    sqlCon.Close();
                    return codigo;
                }
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error" + "');</script>");
                return 0;
            }

        }

    }
}
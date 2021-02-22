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
    public partial class Ordenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["tipo"] != "1")
            {
                Response.Redirect("OrdenesSup.aspx");

            }
            string cadena;
            cadena = "select Orden.codigo_Orden as Num, empleado.nit as Empleado, orden.codigo_cliente as Nit, orden.estado as Estado from orden join Empleado on orden.codigo_empleado = Empleado.nit where orden.codigo_empleado = '" + (string)Session["nomLog"] + "'";
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
    }
}
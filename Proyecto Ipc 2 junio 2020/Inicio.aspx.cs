using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidarS();
            
        }
        protected void ValidarS()
        {
            if ((string)Session["nomLog"] == null)
            {
                Response.Redirect("Login.aspx");

            }
            else
            {
                basedeDatos();
            }
        }
        protected void basedeDatos()
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlParameter paruser = new SqlParameter("@user", (string)Session["nomLog"]);
                    SqlCommand sqlDa = new SqlCommand("Select nit, nombres, apellidos, nombre from Empleado right join Puesto on Empleado.codigo_puesto = Puesto.codigo_puesto where nit = @user",sqlCon);
                    sqlDa.Parameters.Add(paruser);
                    SqlDataReader lector = sqlDa.ExecuteReader();
                    lector.Read();
                    Label1.Text = lector.GetString(3)+": "+lector.GetString(1) + " " + lector.GetString(2);
                    Label4.Text = "Nit: " + lector.GetString(0);
                    lector.Close();
                    sqlCon.Close();
                }
            }
            catch (Exception)
            {
                
            }

        }
    }
}
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
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string user; 
        public int empleado;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (basedeDatos())
            {

                switch (empleado)
                {
                    case 1:
                        Session["tipo"] = "1";

                        Response.Redirect("Inicio.aspx");
                        
                        break;
                    case 2:
                        Session["tipo"] = "2";
                        Response.Redirect("Inicio.aspx");
                        
                        break;

                    case 3:
                        Session["tipo"] = "3";
                        Response.Redirect("Inicio.aspx");
                        
                        break;
                    case 4:
                        Session["tipo"] = "4";
                        Session["nomLog"] = "Admin";
                        Response.Redirect("Administrador.aspx");
                        
                        break;
                    default:
                        break;
                }
                if (user.Equals("Admin"))
                {
                    
                }
                else
                {
                    Response.Redirect("Inicio.aspx");
                    
                }
                
            }
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Usuario o contrasenia erronea!", true);

        }
        protected Boolean basedeDatos() 
        {
            string cadena;
            cadena = ("Select nit, codigo_puesto  from Empleado  where nit = @user AND pass = @pass");
            
            try
            {
                string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlParameter paruser = new SqlParameter("@user", TextBox1.Text);
                    SqlParameter parpass = new SqlParameter("@pass", TextBox2.Text);
                    SqlCommand sqlDa = new SqlCommand(cadena, sqlCon);
                    sqlDa.Parameters.Add(paruser);
                    sqlDa.Parameters.Add(parpass);
                    SqlDataReader lector = sqlDa.ExecuteReader();
                    lector.Read();
                    {
                        empleado = lector.GetInt32(1);
                        Session["nomLog"] = lector.GetString(0);
                    }
                    lector.Close();
                    sqlCon.Close();
                    return true;
                }
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(),"MessageBox","<script language='javascript'>alert('" + "Usuario o Contrasenia incorrectas!" + "');</script>");
                TextBox1.Text = null;
                TextBox2.Text = null;
                return false;
            }
            
        }
        
    }
}
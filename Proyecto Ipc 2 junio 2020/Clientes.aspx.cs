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
    public partial class Clientes : System.Web.UI.Page
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
            cadena = ("insert into Cliente values (@nit, @nom, " + ape + ", @fecha, @dir, @tel, @cel, @email, @ciu, @dep, @lim, @dias )");

            try
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
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Error verificar datos" + "');</script>");

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            basedeDatos();

        }
    }
}
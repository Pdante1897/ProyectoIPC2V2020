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
    public partial class Recibos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-KTTU0OF; Initial Catalog = Diaproma; Integrated Security=True;";

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select * from recibo", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                GridView2.DataSource = dtbl;
                GridView2.DataBind();
                SqlDataAdapter sqlDa2 = new SqlDataAdapter("select * from nota", sqlCon);
                DataTable dtbl2 = new DataTable();
                sqlDa2.Fill(dtbl2);
                GridView3.DataSource = dtbl2;
                GridView3.DataBind();
                sqlCon.Close();
            }
        }
    }
}
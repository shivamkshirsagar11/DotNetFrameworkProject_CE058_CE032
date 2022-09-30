using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
namespace ExpenseTracker
{
    public partial class History : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString
            };
            try
            {
                using (con)
                {
                    string q = "select userid, dateforref, dateadded from dbo.centralidcluster where userid = '" + Session["userId"] + "'";

                    GridView gw = new GridView();
                    gw.ID = "gv456546";
                    gw.AutoGenerateColumns = true;
                    Panel.Controls.Add(gw);
                    SqlCommand cmd = new SqlCommand(q, con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    History1.DataSource = dr;
                    History1.DataBind();
                    gw.DataSource = dr;
                    gw.DataBind();
                   
                    //History1.DataSource = dr;
                    //History1.DataBind();

                    dr.Close();
                }
            }
            catch(Exception exp)
            {
                Response.Write(exp.Message);
            }
            finally
            {
                con.Close();
            }

        }
    }
}
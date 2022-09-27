using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace ExpenseTracker
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loginerr.Text = (string) Session["cmnMsg"];

        }

        protected void Btnclick(object sender, EventArgs e)
        {
            string un = uname.Text;
            string psw = pass.Text;
            SqlConnection con = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString
            };

            try
            {
                using (con)
                {
                    string q = "select * from dbo.login where uname = '" + un + "' and pass = '" + psw + "'";
                
                    SqlCommand cmd = new SqlCommand(q, con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            loginerr.Text = "";
                            Response.Redirect("Home.aspx");
                        }
                    }
                    else
                    {
                       loginerr.Text = "No user found!";
                    }
                    dr.Close();
                    con.Close();
                }

            }
            catch (Exception exp)
            {
                Response.Write("Error: " + exp.Message);
            }
             
        }
    }
}